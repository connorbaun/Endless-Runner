using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController thePlayer; //we are referencing the player object here. The player object has a character controller script attached to it.

    private Vector3 lastPlayerPosition; // we are keeping track of the player's position with a vec3 (z tracks depth)
    private float distanceToMove; //this tells the camera how far to move forward each frame by calculating the diff between current player pos and previous player pos

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>(); //tell unity what the player is
        lastPlayerPosition = thePlayer.transform.position;// track player's position on the previous  frame


    }

    // Update is called once per frame
    void Update () {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //the distance the camera will move forward each frame is equal to the difference between the player's current/previous pos

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position; //the last player position is just the player's position.
		
	}
}
