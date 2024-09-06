using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryIntroController : MonoBehaviour
{
    public GameObject introScene; 
    public GameObject scroll1; 
    public GameObject scroll1b; 
    public GameObject scroll2;
    public GameObject healthUI;

    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        PlayerMovement.allowMovement = true; 
        introScene.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        healthUI.gameObject.SetActive(true);

    }
    public void continueStory()
    {
        scroll1.gameObject.SetActive(false);
        scroll1b.gameObject.SetActive(true);
    }
    public void continueStory2()
    {
        scroll1b.gameObject.SetActive(false);
        scroll2.gameObject.SetActive(true);
    }

}
