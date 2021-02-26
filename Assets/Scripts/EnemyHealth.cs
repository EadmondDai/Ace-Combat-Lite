using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject spawnParent;
    [SerializeField] int enemyHealth = 5;
    [Range(0, 5000)] [SerializeField] int score = 500;

    private ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //gameObject.AddComponent<Rigidbody>();
        //var rigidBody = FindObjectOfType<Rigidbody>();
        //rigidBody.useGravity = false;
        //rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    //void OnParticleCollision(GameObject other)
    //{
    //    enemyHealth--;
    //    if (enemyHealth > 0)
    //    {
    //        GameObject hitVFS = Instantiate(hitEffect, transform.position, transform.rotation);
    //    }
    //    else
    //    {
    //        scoreBoard.IncreaseScore(score);

    //        GameObject newObj = Instantiate(deathVFX, transform.position, transform.rotation);
    //        newObj.transform.parent = spawnParent.transform;
    //        newObj.AddComponent<SelfDestruct>();
    //        Destroy(this.gameObject);
    //    };
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Laser") return;

        enemyHealth--;
        if (enemyHealth > 0)
        {
            GameObject hitVFS = Instantiate(hitEffect, transform.position, transform.rotation);
        }
        else
        {
            scoreBoard.IncreaseScore(score);

            GameObject newObj = Instantiate(deathVFX, transform.position, transform.rotation);
            newObj.transform.parent = spawnParent.transform;
            newObj.AddComponent<SelfDestruct>();
            Destroy(this.gameObject);
        };
    }

}
