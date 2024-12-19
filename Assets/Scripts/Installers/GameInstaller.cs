using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private TowerConfig _towerConfig;
    public void Install(IContainerBuilder builder)
    {
        builder.RegisterInstance<ITowerConfig>(_towerConfig);
    }
}
