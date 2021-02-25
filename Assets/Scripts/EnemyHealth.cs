using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject spawnParent;
    [SerializeField] int enemyHealth = 3;
    [Range(0, 5000)] [SerializeField] int score = 500;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        if (enemyHealth > 0) return;

        scoreBoard.IncreaseScore(score);

        GameObject newObj = Instantiate(deathVFX, transform.position, transform.rotation);
        newObj.transform.parent = spawnParent.transform;
        newObj.AddComponent<SelfDestruct>();
        Destroy(this.gameObject);
    }
}
