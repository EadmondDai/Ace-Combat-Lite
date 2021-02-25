using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject spawnParent;

    void OnParticleCollision(GameObject other)
    {
        GameObject newObj = Instantiate(deathVFX, transform.position, transform.rotation);
        newObj.transform.parent = spawnParent.transform;
        newObj.AddComponent<SelfDestruct>();
        Destroy(this.gameObject);
    }
}
