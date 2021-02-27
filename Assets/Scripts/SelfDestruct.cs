using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SelfDestruct : MonoBehaviour
{
    private float liveTime;

    // Start is called before the first frame update
    void Start()
    {
        var particleSystem = this.GetComponent<ParticleSystem>();
        liveTime = particleSystem.duration;
        Invoke("suicide", liveTime);
    }

    void suicide()
    {
        Destroy(gameObject);
    }
}
