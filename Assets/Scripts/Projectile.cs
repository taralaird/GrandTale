using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 6f;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed ;
        
    }

    void Awake()
    {
        Destroy(gameObject,2f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("Killed", 1);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
 