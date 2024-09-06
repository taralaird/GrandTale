using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu; 
    public GameObject howtoPlay; 
    public GameObject introScene; 
    public GameObject scroll1;
    public GameObject scroll2;
    public GameObject healthUI;


    public GameObject mainCamera;

    
    // Start is called before the first frame update
    void Start()
    {
        if (LevelEndScreen.restart)
        {
            mainMenu.gameObject.SetActive(false);
            healthUI.gameObject.SetActive(true);
        }
        else
        {
            mainMenu.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        introScene.gameObject.SetActive(true);
        scroll1.gameObject.SetActive(true);
        scroll2.gameObject.SetActive(false);


    }
    
    public void HowtoPlay()
    {
        howtoPlay.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

