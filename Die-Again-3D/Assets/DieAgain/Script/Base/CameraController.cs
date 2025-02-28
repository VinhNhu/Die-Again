using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;

    public void SetFollowCam(Transform pos)
    {
        cinemachine.Follow = pos;
    }

}
