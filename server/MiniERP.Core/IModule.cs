using System.Collections.Generic;
using MiniERP.Core.Roles;

namespace MiniERP.Core;

public interface IModule
{
    IEnumerable<Permission>  GetAllPermissions();
}