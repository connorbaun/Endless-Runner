using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform; //the platform that is going to be generated ahead of the player
    public Transform generationPoint; //the point ahead of us that will generate more platforms
    public float distanceBetween; //how far apart do they spawn?

    private float platformWidth; //distance between each platform

    public float distanceBetweenMin; //minimum distance between each platform
    public float distanceBetweenMax; //maximum distance between each platform

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;
    private CoinGenerator theCoinGenerator;


    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public float randomCoinThreshold; //set in inspector, the random number generated in coin generation is checked against this number to see how many coins to generate.




    

	// Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //the game will automatically grab the length of whatever item we dragged onto "Platform" in inspector

        platformWidths = new float[theObjectPools.Length]; //there should be the same number of random widths as there are platform types- we have created an array called platformWidths[] and set its size equal to objectPools[].length

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x; //whatever platform is spawned, platformWidth's int will be equal to the x length of that platform.
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType < CoinGenerator > (); //finds the object that has the CoinGenerator script attached to it.

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x) //if the x pos of this obj is less than the x pos of the GenerationPoint obj...
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length); //we defined this int as being a random number between 0 and the max size the platform array.

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeightChange)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z); //move the x pos ahead 

            //Instantiate (/* thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation); // create the new platform at the new generationpoint position

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f,100f) < randomCoinThreshold)
            {

                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)); //calls SpawnCoins() function inside of CoinGenerator. We are giving it the parameter vector 3 which spawns coins 1 unit above the platform.

            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z); //move the x pos ahead 


        }

    }
}
