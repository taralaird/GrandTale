using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoPlayController : MonoBehaviour
{
    public GameObject howtoPlay; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void backtoMainMenu()
    {
        howtoPlay.gameObject.SetActive(false);
    }
}
