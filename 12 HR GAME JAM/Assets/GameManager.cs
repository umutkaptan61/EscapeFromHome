using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject PauseMenu; 
    

    void Start()
    {
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == false)   //Oyunu durdurma kýsmý
            {
                PauseMenu.SetActive(true);              
                Time.timeScale = 0;
                gameIsPaused = true;
            }         
        }     
    }


    public void ResumeTheGame()
    {
        if (gameIsPaused == true)
        {
            PauseMenu.SetActive(false);           
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }


    public void BackTheMainMenu()
    {
        PauseMenu.SetActive(false);     
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
