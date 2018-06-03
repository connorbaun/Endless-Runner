using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset(); //finds the obj attached to the GameManager script and accesses the Reset() function within
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenuLevel);
    }
 
}
