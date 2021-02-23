using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(0, 100)][SerializeField] float moveSpeed;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    private float defaultRelativeY;
    [Range(0, 90)][SerializeField] float turningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        defaultRelativeY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        float deltaTime = Time.deltaTime;

        Vector3 myLocalPos = transform.localPosition;
        transform.localPosition = new Vector3(
            Mathf.Clamp(myLocalPos.x + xMove * moveSpeed * deltaTime, -xRange, xRange), 
            Mathf.Clamp(myLocalPos.y + yMove * moveSpeed * deltaTime, -yRange + defaultRelativeY, yRange + defaultRelativeY),
            myLocalPos.z);
    }
}
