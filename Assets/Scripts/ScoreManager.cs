using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //make sure you add in the UI text libary!

public class ScoreManager : MonoBehaviour {

    public Text scoreText; //the word "Score:" in top left
    public Text highScoreText;// the word "High Score:" in top right

    public float scoreCount; //current score value
    public float highScoreCount;// current high score value

    public float pointsPerSecond;//number of points gained per second of progress

    public bool scoreIncreasing;//are we able to gain points?

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

    }

    public void AddScore(int pointsToAdd) //new function that requires a number value to plug in, which we call "points to add"
    {
        scoreCount += pointsToAdd;
    }
}
