using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] float delayLoadingTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        explosion.Play();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<PlayerControl>().enabled = false;
        Invoke("reloadScene", delayLoadingTime);
    }
    void reloadScene()
    {
        int curIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curIdx);
    }
}
