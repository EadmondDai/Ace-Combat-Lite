using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(0, 100)][SerializeField] float moveSpeed;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    private Vector3 defualtRelatPos;
    [SerializeField] float pitchFactor = 2.0f;
    [SerializeField] float controlPitchFactor = -100f;
    [SerializeField] float yawFactor = -2;
    [SerializeField] float controlRollFactor = -5;

    protected float xMove, yMove;

    // Start is called before the first frame update
    void Start()
    {
        defualtRelatPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        float deltaTime = Time.deltaTime;

        handleTransition(xMove, yMove, deltaTime);
        handleRotation(xMove, yMove);
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
            Mathf.Clamp(myLocalPos.y + yMove * moveSpeed * deltaTime, -yRange + defualtRelatPos.y, yRange + defualtRelatPos.y),
            myLocalPos.z);
    }
}
