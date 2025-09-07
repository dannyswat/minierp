namespace MiniERP.Core.Roles;

using System;
using System.Collections.Generic;
using MiniERP.Core.Entities;

public class Role : AggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<RolePermission> Permissions { get; set; } = [];

    public bool IsSystemRole { get; set; } = false;
}

public class RolePermission : Entity
{
    public int RoleId { get; set; }

    public required string Permission { get; set; }
}