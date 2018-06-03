using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool; //this is a ref to a new version of the ObjectPooler script, which we are calling coinpool. We use that same ObjectPooler code to pool both platforms and coins.

    public float distanceBetweenCoins; //set in inspector, this value will be used to determine how far apart to spawn each coin from the last.

    public void SpawnCoins(Vector3 startPosition) //function which spawns coins. It requires a start position in the form of a vector 3.
    {
        GameObject coin1 = coinPool.GetPooledObject(); //go into the obj pooler script and return a pooled obj (in this case a coin, which we will call coin1)
        coin1.transform.position = startPosition; //set the transform of that coin to given startPosition (vec3)
        coin1.SetActive(true); //activate the coin so that it is visible

        GameObject coin2 = coinPool.GetPooledObject(); //ref to the ObjPooler function GetPooledObj() which returns another pooled obj , which we'll call coin2
        coin2.transform.position = new Vector3 (startPosition.x -distanceBetweenCoins, startPosition.y, startPosition.z); //set the transform of that coin to next to the original coin plus distancebetweencoin value
        coin2.SetActive(true); //activate the coin so its visible

        GameObject coin3 = coinPool.GetPooledObject(); //ref to the ObjPooler function GetPooledObj() which returns a third pooled obj, which we'll call coin3
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z); //set the transform of that coin to next to the original coin plus distancebetweencoin value
        coin3.SetActive(true); //activate the coin so its visible
        
    }
}
