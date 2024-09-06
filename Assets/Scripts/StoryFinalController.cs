using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryFinalController : MonoBehaviour
{
    public GameObject scroll1; 
    public GameObject scroll2Good;
    public GameObject scroll2Bad;
    
    public AudioSource goodNoise;
    public AudioSource badNoise;
    // Start is called before the first frame update
    void Start()
    {
        scroll2Good.gameObject.SetActive(false);
        scroll2Bad.gameObject.SetActive(false);
        scroll1.gameObject.SetActive(true);
        Debug.Log(PlayerPrefs.GetInt("Killed"));
        if (PlayerPrefs.GetInt("Killed") == 1)
        {
            badNoise.Play();
        }else 
        {
            goodNoise.Play();
        }
    }

    // Update is called once per frame
    public void nextScroll()
    {
        Debug.Log("clicked");
        scroll1.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Killed") == 1)
        {
            scroll2Bad.gameObject.SetActive(true);
        }
        else 
        {
            scroll2Good.gameObject.SetActive(true);
        }
    }

    public void endScene()
    {
        PlayerPrefs.SetInt("Killed",0);
        SceneManager.LoadScene("MainMenu");
    }
}
