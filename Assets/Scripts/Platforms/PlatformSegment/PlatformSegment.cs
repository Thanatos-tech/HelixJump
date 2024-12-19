using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Platform _platformParent;

    public ParticleSystem ParticleSystem => _particleSystem;
    public Platform PlatformParent => _platformParent;
}