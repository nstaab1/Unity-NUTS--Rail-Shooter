using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    [Header("General Settings")]
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 5f;
    [Tooltip("In m/s")][SerializeField] float speed = 10f;
    [Header("Position Settings")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 6f;
    [Header("Control Settings")]
    [SerializeField] float controlPitchFactor = -8f;
    [SerializeField] float controlRollFactor = -55f;
    [SerializeField] GameObject[] guns;

    AudioSource machineGun;

    bool controlsDisabled = false;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        machineGun = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controlsDisabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }   
    }

    

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange), transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange), transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
            if(!machineGun.isPlaying)
            {
                machineGun.Play();
            }
            
        } else
        {
            DeactivateGuns();
            machineGun.Stop();
        }
    }

    private void ActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }

    void DisableControls() // Called by string refrence in CollisionHandler
    {
        controlsDisabled = true;
    }
}
