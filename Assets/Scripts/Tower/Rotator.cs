using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }
    }
}