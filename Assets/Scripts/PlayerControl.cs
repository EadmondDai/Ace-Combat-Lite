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
    [Range(0, 4)][SerializeField] float pitchFactor = 2.0f;

    protected float xMove = 0;
    protected float yMove = 0;

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
        float pitch = transform.localPosition.y * pitchFactor;
        float yaw = 0;
        float roll = 0;
        print(" local pos ????????? " + transform.localPosition.y);
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
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
