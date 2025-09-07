using System.Collections.Generic;

namespace MiniERP.Core;

public class Modules
{
    private static readonly Modules Instance = new();
    private readonly List<IModule> modules = [];

    private void RegisterModule(IModule module)
    {
        modules.Add(module);
    }

    public static void Register(IModule module)
    {
        Instance.RegisterModule(module);
    }
}