﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerControl : MonoBehaviour
{
    [Header("Ship control settings")]
    [Tooltip("Controls how fast the ship moves")]
    [Range(0, 100)][SerializeField] float moveSpeed;
    [Tooltip("Controls how far can the ship move")]
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    
    [Tooltip("Control how the ship roate based on the screen position")]
    [SerializeField] float pitchFactor = 2.0f;
    [SerializeField] float yawFactor = -2;

    [Tooltip("Controls how fast the ship reacts to the input")]
    [SerializeField] float controlPitchFactor = -100f;
    [SerializeField] float controlRollFactor = -5;

    //[Tooltip("Your friendly enemy killing neibhbor")]
    //[SerializeField] GameObject[] lasers;

    [SerializeField] GameObject laserObj;
    [SerializeField] GameObject[] fireingPosition;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] float firingSpeedFactor = 200.0f;

    private float nextFireTime = 0;
    protected float xMove, yMove;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        float deltaTime = Time.deltaTime;

        handleTransition(xMove, yMove, deltaTime);
        handleRotation(xMove, yMove);
        handleFireing();
    }

    private void handleFireing()
    {
        //// If press down fire then shooting is enabled.
        //if (Input.GetButton("Fire1"))
        //{
        //    toggleLaser(true);
        //}
        //else
        //{
        //    toggleLaser(false);
        //}

        if (Input.GetButton("Fire1"))
        {
            if(nextFireTime <= Time.time)
            {
                nextFireTime = Time.time + firingRate;
                foreach(GameObject lazerSpawnObj in fireingPosition)
                {
                    Vector3 forwardVector = lazerSpawnObj.transform.forward;
                    var laser = Instantiate(laserObj, lazerSpawnObj.transform.position, lazerSpawnObj.transform.rotation);
                    laser.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
                    //Vector3 curSpeed = lazerSpawnObj.GetComponent<Rigidbody>().velocity;
                    laser.GetComponent<Rigidbody>().velocity = forwardVector * firingSpeedFactor;
                }
            }
        }
    }

    private void toggleLaser(bool active)
    {
        // Don't use this unless particle collision problem is solved.
        //foreach (GameObject laser in lasers)
        //{
        //    var particleSystem = laser.GetComponent<ParticleSystem>();
        //    //particleSystem.startSpeed = particleSystem.startSpeed + gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        //    var emmisionSystem = particleSystem.emission;
        //    emmisionSystem.enabled = active;
        //}
    }

    private void handleRotation(float xMove, float yMove)
    {
        float positionPitch = transform.localPosition.y * pitchFactor;
        float controlPitch = yMove * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xMove * controlRollFactor;
        transform.localRotation = Quaternion.Euler(positionPitch + controlPitch, yaw, roll);
    }

    private void handleTransition(float xMove, float yMove, float deltaTime)
    {
        Vector3 myLocalPos = transform.localPosition;
        transform.localPosition = new Vector3(
            Mathf.Clamp(myLocalPos.x + xMove * moveSpeed * deltaTime, -xRange, xRange),
            Mathf.Clamp(myLocalPos.y + yMove * moveSpeed * deltaTime, -yRange, yRange),
            myLocalPos.z);
    }


}
