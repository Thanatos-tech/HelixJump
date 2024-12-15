using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private SixtyDegSegmentEffect _sixtyDegSegmentEffect;
    [SerializeField] private NinetyDegSegmentEffect _ninetyDegSegmentEffect;

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();

        foreach(var segment in segments)
        {
            if (segment.TryGetComponent(out NinetyDegSegment ninetyDegSegment)
                || segment.TryGetComponent(out SixtyDegSegment sixtyDegSegment))
            {
                CreateParticle(segment);
            }
            Destroy(segment.gameObject);
        }
    }

    public void CreateParticle(PlatformSegment segment)
    {
        ParticleSystem particleSystem =
            (segment.TryGetComponent(out NinetyDegSegment ninetyDegSegment)
                ? Instantiate(_ninetyDegSegmentEffect, segment.transform.position, segment.transform.rotation).GetComponent<ParticleSystem>()
                : (segment.TryGetComponent(out SixtyDegSegment sixtyDegSegment)
                    ? Instantiate(_sixtyDegSegmentEffect, segment.transform.position, segment.transform.rotation).GetComponent<ParticleSystem>()
                    : null));

        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = Vector3.zero;
        emitParams.rotation3D = segment.transform.rotation.eulerAngles;
        particleSystem.Emit(emitParams, 1);
    }
}