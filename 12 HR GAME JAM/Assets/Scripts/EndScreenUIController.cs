using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUIController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }


    public void BackToFirstMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}