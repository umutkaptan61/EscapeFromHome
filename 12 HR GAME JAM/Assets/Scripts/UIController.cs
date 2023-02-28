using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject howToIPlayPanel;
    public GameObject firstPanel;
    private bool panelOn;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {      
        panelOn = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToIPlay()
    {
        panelOn = true;
        firstPanel.SetActive(false);
        howToIPlayPanel.SetActive(true);
    }

    private void Update()
    {
        BackToMainMenu();
    }

    public void BackToMainMenu()   //Nasýl oynanýr panelinin içinden geri dönüþ
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panelOn == true)
        {        
            howToIPlayPanel.SetActive(false);
            firstPanel.SetActive(true);
            panelOn = false;
        }
    }
}
