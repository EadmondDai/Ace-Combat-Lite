using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(0, 100)][SerializeField] float moveSpeed;
    [Range(0, 90)][SerializeField] float turningSpeed;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        float deltaTime = Time.deltaTime;

        Vector3 myLocalPos = transform.localPosition;
        transform.localPosition = new Vector3(
            myLocalPos.x + xMove * moveSpeed * deltaTime, 
            myLocalPos.y + yMove * moveSpeed * deltaTime, 
            myLocalPos.z);
    }
}
