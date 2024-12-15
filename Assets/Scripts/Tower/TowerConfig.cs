using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower/TowerConfig")]
public class TowerConfig : ScriptableObject
{
    [SerializeField] public int _levelCount;
    [SerializeField] public Beam _beam;
    [SerializeField] public StartPlatform _startPlatform;
    [SerializeField] public Platform[] _platforms;
    [SerializeField] public EndPlatform _endPlatform;
    [SerializeField] public float _additionalScaleBeforeStart;
    [SerializeField] public float _startAdditionalScale;
    public float BeamScale => _additionalScaleBeforeStart / 2f + _startAdditionalScale + _levelCount / 2f;
}
