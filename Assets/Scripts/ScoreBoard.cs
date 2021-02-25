using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    //[SerializeField] text scoreText;
    public int score;

    public void IncreaseScore(int score)
    {
        this.score += score;
    }
}
