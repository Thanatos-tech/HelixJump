using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private Vector3 CalculatedForce => _jumpForce * Vector3.up;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(CalculatedForce, ForceMode.Impulse);
        }
    }
}