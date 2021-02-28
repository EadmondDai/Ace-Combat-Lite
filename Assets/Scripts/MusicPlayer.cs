using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int musicsPlayerNum = FindObjectsOfType<MusicPlayer>().Length;
        if (musicsPlayerNum > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
