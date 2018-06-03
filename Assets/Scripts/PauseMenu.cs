using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f; //timescale is normally 1, setting it to 0 means no passage of time.
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; //timescale is reset back to normal
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset(); //finds the obj attached to the GameManager script and accesses the Reset() function within
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(mainMenuLevel);
    }
}
