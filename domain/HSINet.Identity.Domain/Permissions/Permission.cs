﻿namespace HSINet.Identity.Domain.Permissions;

public class Permission
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
