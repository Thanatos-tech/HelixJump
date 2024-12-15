using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Builder : MonoBehaviour
{
    [SerializeField] private TowerConfig _towerConfig;

    private void Awake()
    {
        StartCoroutine(Build());
    }

    private IEnumerator Build()
    {
        GameObject beam = Instantiate(_towerConfig._beam.gameObject, transform);
        beam.transform.localScale = new Vector3(1, _towerConfig.BeamScale, 1);

        Vector3 spawnPoint = new Vector3(beam.transform.position.x, beam.transform.localScale.y - _towerConfig._additionalScaleBeforeStart, beam.transform.position.z);

        GeneratePlatform(_towerConfig._startPlatform, ref spawnPoint, beam.transform);
        yield return new WaitForSeconds(0.4f);

        for (int i = 0; i < _towerConfig._levelCount; i++)
        {
            GeneratePlatform(_towerConfig._platforms[Random.Range(0, _towerConfig._platforms.Length)], ref spawnPoint, beam.transform);
            yield return new WaitForSeconds(0.4f);
        }

        GeneratePlatform(_towerConfig._endPlatform, ref spawnPoint, beam.transform);
    }

    private void GeneratePlatform(Platform platform, ref Vector3 spawnPoint, Transform parent)
    {
        Platform generatedPlatform = Instantiate(platform, spawnPoint, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        generatedPlatform.transform.DOScaleX(1, 0.6f).From(0.4f).SetEase(Ease.InCirc);
        generatedPlatform.transform.DOScaleY(0.5f, 0.6f).From(0.1f).SetEase(Ease.InCirc);
        generatedPlatform.transform.DOScaleZ(1, 0.6f).From(0.4f).SetEase(Ease.InCirc);
        spawnPoint.y -= 1;
    }
}