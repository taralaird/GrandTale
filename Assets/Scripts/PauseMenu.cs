using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject storyCanvas;
    public GameObject deathCanvas;
    public GameObject winCanvas;

    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseGame(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !(storyCanvas.activeInHierarchy)&&!(deathCanvas.activeInHierarchy)&&!(winCanvas.activeInHierarchy))
        {
            if (isPaused)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void PauseGame(bool paused)
    {
        if (paused)
        {
            pauseCanvas.SetActive(true);
        }
        else
        {
            pauseCanvas.SetActive(false);
        }
        isPaused = paused;
        Time.timeScale = paused ? 0 : 1;
    }

    public void ContinueGame()
    {
        PauseGame(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
