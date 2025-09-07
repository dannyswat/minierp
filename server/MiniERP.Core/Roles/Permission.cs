namespace MiniERP.Core.Roles;

public record Permission(
    string Name,
    string Description,
    string? ParentName = null,
    bool GrantedByDefault = false);