using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {
            platformSegment.PlatformParent.Break();
        }
    }
}