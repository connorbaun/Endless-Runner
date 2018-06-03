using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager; //a reference to our scoremanager script

    public DeathMenu theDeathScreen; //ref to an instance of DeathMenu script

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false; //access the score manager script and stop score increase
        thePlayer.gameObject.SetActive(false); //turn player obj invisible so he isn't stuck on bottom of screen

        theDeathScreen.gameObject.SetActive(true);//activate the death menu screen


        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);//deactivate the death menu screen

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++) //start at plat # 0 and go through all of them
        {
            platformList[i].gameObject.SetActive(false); //set each platform in this array to inactive
        }

        thePlayer.transform.position = playerStartPoint; //reset player starting pos
        platformGenerator.position = platformStartPoint; //reset platform generator pos
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0; //reset player's score
        theScoreManager.scoreIncreasing = true; //allow player to gain score again
    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false; //access the score manager script and stop score increase
        thePlayer.gameObject.SetActive(false); //turn player obj invisible so he isn't stuck on bottom of screen
        yield return new WaitForSeconds(0.5f); //adds a short delay before this stuff occurs
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++) //start at plat # 0 and go through all of them
        {
            platformList[i].gameObject.SetActive(false); //set each platform in this array to inactive
        }

        thePlayer.transform.position = playerStartPoint; //reset player starting pos
        platformGenerator.position = platformStartPoint; //reset platform generator pos
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0; //reset player's score
        theScoreManager.scoreIncreasing = true; //allow player to gain score again
    }*/
}
