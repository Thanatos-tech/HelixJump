using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower/TowerConfig")]
public class TowerConfig : ScriptableObject, ITowerConfig
{
    [SerializeField] private int _levelCount;
    [SerializeField] private Beam _beam;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private EndPlatform _endPlatform;
    [SerializeField] private float _additionalScaleBeforeStart;
    [SerializeField] private float _upperAdditionalScale;

    public int LevelCount => _levelCount;
    public Beam Beam => _beam;
    public StartPlatform StartPlatform => _startPlatform;
    public Platform[] Platforms => _platforms;
    public EndPlatform EndPlatform => _endPlatform;
    public float AdditionalScaleBeforeStart => _additionalScaleBeforeStart;
    public float UpperAdditionalScale => _upperAdditionalScale;
    public float BeamScale => _additionalScaleBeforeStart / 2f + _upperAdditionalScale + _levelCount / 2f;
}
