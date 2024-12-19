using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformSegment[] _platformSegments;
    public void Break()
    {
        foreach(var segment in _platformSegments)
        {
            if(segment.ParticleSystem != null)
            {
                CreateParticle(segment);
            }

            Destroy(segment.gameObject);
        }
    }

    public void CreateParticle(PlatformSegment segment)
    {
        var particleSystem = Instantiate(segment.ParticleSystem, segment.transform.position, segment.transform.rotation).GetComponent<ParticleSystem>();

        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = Vector3.zero;
        emitParams.rotation3D = segment.transform.rotation.eulerAngles;

        particleSystem.Emit(emitParams, 1);
    }
}