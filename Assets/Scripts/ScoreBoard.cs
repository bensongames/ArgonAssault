using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private int scoreTotal;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        ShowScore();
    }

    private void ShowScore()
    {
        scoreText.text = scoreTotal.ToString("D6");
    }

    public void ScoreHit(int score)
    {
        scoreTotal += score;
        ShowScore();
    }

}
