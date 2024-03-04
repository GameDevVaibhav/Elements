using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer;

    private CinemachineBasicMultiChannelPerlin cbmp;
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        StopShake();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            ShakeCamera();
        }
        if (timer > 0)
        {
            timer-= Time.deltaTime;

            if(timer <= 0)
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera()
    {
        cbmp=vCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cbmp.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }

    public void StopShake()
    {
        cbmp = vCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cbmp.m_AmplitudeGain = 0f;
        timer = 0f;

    }
}
