using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public GameObject scroll1;
    public GameObject scroll2;
    public GameObject scroll3;
    
    // Start is called before the first frame update
    void Start()
    { 
        int rand1 = Random.Range(1, 3);
        int rand2 = Random.Range(1, 3);
        int rand3 = Random.Range(1, 3);
        
       switch (rand1)
       {
           case 1:
           {
               scroll1.transform.position = new Vector3(-7,9.5f,-0.0977031514f);
               break;
           }
           case 2:
           {
               scroll1.transform.position = new Vector3(-5.5f,4.5999999f,-0.0977031514f);
               break;
           }
           case 3:
           {
               scroll1.transform.position = new Vector3(3,3.5f,-0.0977031514f);
               break;
           }
       }
       switch (rand2)
       {
           case 1:
           {
               scroll2.transform.position = new Vector3(28.3999996f,9.39999962f,-0.0977031514f);
               break;
           }
           case 2:
           {
               scroll2.transform.position = new Vector3(42.5999985f,11.3999996f,-0.0977031514f);
               break;
           }
           case 3:
           {
               scroll2.transform.position = new Vector3(36.9000015f,4.5999999f,-0.0977031514f);
               break;
           }
       }
       
       switch (rand3)
       {
           case 1:
           {
               scroll3.transform.position = new Vector3(57.5f,5.5f,-0.0977031514f);
               break;
           }
           case 2:
           {
               scroll3.transform.position = new Vector3(44.5999985f,-1f,-0.0977031514f);
               break;
           }
           case 3:
           {
               scroll3.transform.position = new Vector3(48.5f,7.30000019f,-0.0977031514f);
               break;
           }
       }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
