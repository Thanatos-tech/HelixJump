using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private Beam _beam;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private EndPlatform _endPlatform;

    private float _additionalScaleBeforeStart = 3f;
    private float _startAdditionalScale = 0.5f;
    public float BeamScale => _additionalScaleBeforeStart / 2f + _startAdditionalScale + _levelCount / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam.gameObject, transform);
        beam.transform.localScale = new Vector3(1, BeamScale, 1);

        Vector3 spawnPoint = new Vector3(beam.transform.position.x, beam.transform.localScale.y - _additionalScaleBeforeStart, beam.transform.position.z);

        GeneratePlatform(_startPlatform, ref spawnPoint, beam.transform);
        for(int i = 0; i < _levelCount; i++)
        {
            GeneratePlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPoint, beam.transform);
        }
        GeneratePlatform(_endPlatform, ref spawnPoint, beam.transform);
    }

    private void GeneratePlatform(Platform platform, ref Vector3 spawnPoint, Transform parent)
    {
        Instantiate(platform, spawnPoint, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPoint.y -= 1;
    }
}