public interface ITowerConfig
{
    public int LevelCount { get; }
    public Beam Beam { get; }
    public StartPlatform StartPlatform { get; }
    public Platform[] Platforms { get; }
    public EndPlatform EndPlatform { get; }
    public float AdditionalScaleBeforeStart { get; }
    public float UpperAdditionalScale { get; }
    public float BeamScale { get; }
}