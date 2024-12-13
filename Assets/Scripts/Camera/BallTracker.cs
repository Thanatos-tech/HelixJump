using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _lowestBallPosition;

    private void Start()
    {
        _ball= FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        TrackBall();
    }

    private void Update()
    {
        if(_ball.transform.position.y < _lowestBallPosition.y)
        {
            TrackBall();
            _lowestBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;

        _cameraPosition = _lowestBallPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}