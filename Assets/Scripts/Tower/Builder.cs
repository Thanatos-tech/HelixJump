using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;
using VContainer;
using Random = UnityEngine.Random;

public class Builder : MonoBehaviour
{
    private ITowerConfig _towerConfig;

    [Inject]
    public void Construct(ITowerConfig towerConfig)
    {
        _towerConfig = towerConfig;
    }

    public void Awake()
    {
        Build();
    }

    public async void Build()
    {
        var beam = Instantiate(_towerConfig.Beam.gameObject, transform);
        beam.transform.localScale = new Vector3(1, _towerConfig.BeamScale, 1);

        var spawnPoint = new Vector3(beam.transform.position.x, beam.transform.localScale.y - _towerConfig.AdditionalScaleBeforeStart, beam.transform.position.z);

        GeneratePlatform(_towerConfig.StartPlatform, ref spawnPoint, beam.transform);
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f));

        for (int i = 0; i < _towerConfig.LevelCount; i++)
        {
            GeneratePlatform(_towerConfig.Platforms[Random.Range(0, _towerConfig.Platforms.Length)], ref spawnPoint, beam.transform);
            await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
        }

        GeneratePlatform(_towerConfig.EndPlatform, ref spawnPoint, beam.transform);
    }

    private void GeneratePlatform(Platform platform, ref Vector3 spawnPoint, Transform parent)
    {
        var generatedPlatform = Instantiate(platform, spawnPoint, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        generatedPlatform.transform.DOScaleX(1, 0.6f).From(0.4f).SetEase(Ease.InCirc);
        generatedPlatform.transform.DOScaleY(0.5f, 0.6f).From(0.1f).SetEase(Ease.InCirc);
        generatedPlatform.transform.DOScaleZ(1, 0.6f).From(0.4f).SetEase(Ease.InCirc);
        spawnPoint.y -= 1;
    }
}