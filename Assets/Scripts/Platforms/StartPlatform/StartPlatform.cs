using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Beam _beam;

    private void Awake()
    {
        var ball = Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
        ball.transform.LookAt(_beam.transform);
    }
}