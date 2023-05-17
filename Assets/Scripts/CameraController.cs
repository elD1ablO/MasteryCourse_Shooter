using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private float mouseLookSensitivity;

    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (!Input.GetKeyDown(KeyCode.RightAlt))
        {
            var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;

            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);

        }
    }
}
