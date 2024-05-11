﻿using HSINet.Identity.Api.AuthorisationCodes.Get;
using HSINet.Identity.Domain;
using HSINet.Identity.Domain.Exceptions;
using MediatR;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HSINet.Identity.Api.Tokens.Post;

public class Handler(ApplicationSettings applicationSettings, IMediator mediator, TimeProvider timeProvider) 
    : IRequestHandler<Request, Response>
{
    private string? CreateToken(SessionData sessionData)
    {
        var key = new SymmetricSecurityKey(
        Convert.FromBase64String(applicationSettings.TokenKey
                ?? throw new ConfigurationMissingException(nameof(applicationSettings.TokenKey))));
        var encryptionKey = new SymmetricSecurityKey(
            Convert.FromBase64String(applicationSettings.EncryptionKey
                ?? throw new ConfigurationMissingException(nameof(applicationSettings.EncryptionKey))
            ));

        var localNow = timeProvider.GetLocalNow();

        return new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Audience = applicationSettings.Audiences.FirstOrDefault(),
            Issuer = applicationSettings.Issuers.FirstOrDefault(),
            IssuedAt = localNow.DateTime,
            NotBefore = localNow.DateTime,
            Expires = localNow.DateTime.AddMinutes(applicationSettings.SessionValidityPeriodInMinutes),
            Subject = new ClaimsIdentity(new List<Claim> { 
                //new Claim("Session-Id", sessionData.SessionId.ToString()) 
            }),
            SigningCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha512),
            CompressionAlgorithm = CompressionAlgorithms.Deflate,
            EncryptingCredentials = new EncryptingCredentials(encryptionKey,
                SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes256CbcHmacSha512)
        });
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var client = await mediator.Send(
            new Clients.Query { 
                Reference = request.ClientId 
            }, cancellationToken) ?? throw new NullReferenceException("Client not found");

        if(!string.IsNullOrWhiteSpace(client.Secret) && client.Secret != request.ClientSecret)
        {
            throw new UnauthorizedAccessException("Client secret is invalid");
        }

        var utcNow = timeProvider.GetUtcNow();

        var authorisation = await mediator.Send(new Query { Code = request.Code }, cancellationToken) 
            ?? throw new UnauthorizedAccessException("Authorisation code invalid");

        if(authorisation.ValidFrom > utcNow || authorisation.Expires < utcNow)
        {
            throw new UnauthorizedAccessException("Authorisation code invalid or expired");
        }

        var accessToken = new Domain.AccessTokens.AccessToken {
            Expires = utcNow.AddSeconds(3600),
            Type = "Client",
            Key = CreateToken(new SessionData
            {
                Authorisation = authorisation,
                Client = client
            }),
            RefreshToken = ""
        };

        client.ClientAccessTokens.Add(new Domain.Clients.ClientAccessToken
        {
            AccessToken = accessToken
        });

        utcNow = timeProvider.GetUtcNow();

        return new Response
        {
            AccessToken = accessToken.Key,
            Expires = accessToken.Expires.Subtract(utcNow).Seconds,
            TokenType = accessToken.Type,
            RefreshToken = accessToken.RefreshToken
        };
    }
}
