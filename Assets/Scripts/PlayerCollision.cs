using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] float delayLoadingTime = 1.0f;
    [SerializeField] float enableCollisionDelay = 1.0f;
    private bool isCollisionEnabled = false;

    private void Start()
    {
        Invoke("enableCollisoin", enableCollisionDelay);
    }

    void enableCollisoin()
    {
        isCollisionEnabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollisionEnabled) return;
        explosion.Play();
        explosion.GetComponent<AudioSource>().Play();
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
