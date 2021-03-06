using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject gameOverMenu;
    public GameObject pauseGame;

    private void OnEnable()
    {
        PlayerController2.OnPlayerDeath += EnableGameOverMenu;
        

    }

    private void OnDisable()
    {
        PlayerController2.OnPlayerDeath -= EnableGameOverMenu;
        //GetComponent<PauseGameTime>().ResumeGame();

    }
    public void EnableGameOverMenu()
    {
        //GetComponent<PauseGameTime>().PauseGame();
        gameOverMenu.SetActive(true);
        
    }

     public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
