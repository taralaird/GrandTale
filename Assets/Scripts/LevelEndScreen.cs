using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScreen : MonoBehaviour
{
    public static bool restart = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene()
    {
        Debug.Log("Clicked");
        restart = true; 
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        PlayerMovement.allowMovement = true; 
        
    }
    public void RestartGame()
    { 
        SceneManager.LoadScene("MainMenu");
      
        
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
    
    public void OpenFinale()
        {
            SceneManager.LoadScene("FinalScene");
        }


    public void QuitGame()
    {
        Application.Quit();
    }
}
