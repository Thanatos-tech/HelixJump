using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera VirtualCamera => transform.GetComponent<CinemachineVirtualCamera>();

    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();

        VirtualCamera.m_LookAt = _ball.transform;
        VirtualCamera.m_Follow = _ball.transform;
    }
}
