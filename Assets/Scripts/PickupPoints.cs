using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour {
    public int scoreToGive; //whatever amount we want to give to player

    private ScoreManager theScoreManager; //a ref to our scoremanager script


	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") //if the name of collided object is "player"...
        {
            theScoreManager.AddScore(scoreToGive); //ref to a function inside of ScoreManager called AddScore(), and we are providing ScoretoGive as the number for that function (See ScoreManager script)
            gameObject.SetActive(false); //disables coin so it dissapears onscreen once its touched
        }

    }
}
