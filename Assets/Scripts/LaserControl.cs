using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class LaserControl : MonoBehaviour
{
    [SerializeField] float collisionEnableDelay = 0.2f;
    [SerializeField] float liveTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("enableCollision", collisionEnableDelay);
        Invoke("die", liveTime);
    }

    void die()
    {
        Destroy(gameObject);
    }

    void enableCollision()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        die();
    }
}
