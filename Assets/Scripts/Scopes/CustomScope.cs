using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public abstract class CustomScope : LifetimeScope
{
    [SerializeField] private List<GameInstaller> _servicesInstallers;

    protected override void Configure(IContainerBuilder builder)
    {
        _servicesInstallers.ForEach(service  => service.Install(builder));
    }
}
