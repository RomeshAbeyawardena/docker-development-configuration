FROM mcr.microsoft.com/mssql/server:2019-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password123

EXPOSE 1433