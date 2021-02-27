using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DisallowMultipleComponent]
public class ScoreBoard : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    public int score;

    public void IncreaseScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }
}
