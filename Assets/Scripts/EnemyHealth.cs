using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        print(this.name + "  is hit by  " + other.name);
        Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
