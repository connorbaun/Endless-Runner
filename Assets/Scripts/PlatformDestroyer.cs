using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDestructionPoint; //a ref to the destruction empty game object we made

	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint"); //we tell unity to look for the gameobject with the name PlatformDestructionPoint
		
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);


            gameObject.SetActive(false);
        }
		
	}
}
