using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    [SerializeField] float collisionEnableDelay = 0.2f;
    [SerializeField] float liveTime = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject hitSpawnParent;
    [SerializeField] float selfDestroyDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("enableCollision", collisionEnableDelay);
        Invoke("die", liveTime);
        hitSpawnParent = GameObject.FindGameObjectWithTag("HitParent");
    }

    void die()
    {
        Destroy(gameObject);
    }

    void enableCollision()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        print(name + "  hit  " + collision.gameObject.name);
        var hitVFS = Instantiate(hitEffect, transform.position, transform.rotation);
        hitEffect.transform.parent = hitSpawnParent.transform;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Invoke("die", selfDestroyDelay);
    }
}
