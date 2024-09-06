using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float boost = 8f;

    public float jumpPower = 16f;
    private float hor;
    private bool facingRight = true;
    private Vector3 originalPos;
    public static bool allowMovement = false; 
    public GameObject thevoid;

    public float health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public float scrolls;
    public TMP_Text scrollText;

    public GameObject deathScreen;
    public GameObject winScreen; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] Transform destination;

    public AudioSource damageNoise;
    public AudioSource successNoise;
    public AudioSource speedNoise;
    public AudioSource shootNoise;
    private AudioSource audio;
    
    public Projectile projectilePrefab;
    public Transform launch;
    public Vector3 localScale;



    void Start() {
        localScale.x = 1;
        health = 3;
        scrolls = 0;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
            gameObject.transform.position.z);
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (true)
        {
            hor = Input.GetAxisRaw("Horizontal");

            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

            if (Input.GetKeyDown("up") && IsGrounded())
            {
                StartCoroutine(jumpAnimator());
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

            if (Input.GetKeyDown("up") && rb.velocity.y > 0f)
            {
                StartCoroutine(jumpAnimator());
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            if (Input.GetKeyDown("space") )
            {
                Debug.Log("shoot");
                shootNoise.Play();
                StartCoroutine(shootAnimator());
                Projectile bullet = Instantiate(projectilePrefab, launch.position, transform.rotation) as Projectile;
                if (localScale.x > 0f)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
                    bullet.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600, 0));
                    bullet.gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

                //bullet.gameObject.transform.localScale = new Vector3(1, 1, 1);
                
                
            }

            Flip();
        }
        else
        {
            
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(hor * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && hor < 0f || !facingRight && hor > 0f)
        {
            facingRight = !facingRight;
            localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Debug.Log("flipped");
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    IEnumerator jumpAnimator()
    {
        //Debug.Log("jump");
        anim.SetBool("IsJumping", true);

        if (rb.velocity.y < 0f)
        {
            //Debug.Log("falling");
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("IsFalling", false);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        anim.SetBool("IsJumping", false);


    }
    IEnumerator shootAnimator()
    {
        anim.SetBool("IsShooting", true);

          
        yield return new WaitForSeconds(0.25f);

        anim.SetBool("IsShooting", false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == thevoid || col.gameObject.tag =="Enemy")
        {
            StartCoroutine(damageAnimator());
            damageNoise.Play();

            health--;
            transform.position = originalPos;
            updateHealth(health);

        }

        if (col.gameObject.tag == "Scroll")
        {
            Destroy(col.gameObject);
            successNoise.Play();

            updateScrolls();
            
        }
        
        if (col.gameObject.tag == "SpeedBoost")
        {
            Destroy(col.gameObject);
            StartCoroutine(speedBoost());
            speedNoise.Play();

        }

        if(col.gameObject.tag == "HealthBoost")
        {
            Destroy(col.gameObject);
            if (health < 3)
            {
                health++;
                addHealth(health);
            }
        }

        if(col.gameObject.tag == "PortalBoost")
        {
            Destroy(col.gameObject);
            Teleport(destination.position);
        }
    }
    IEnumerator damageAnimator()
    {
        //Debug.Log("jump");
        anim.SetBool("Damaged", true);
            yield return new WaitForSeconds(0.4f);
        anim.SetBool("Damaged", false);


    }

    public void updateHealth(float num)
    {
        
        switch (num)
        {
            case 2:
            {
                heart3.gameObject.SetActive(false);
                break;
            }
            case 1:
            {
                heart2.gameObject.SetActive(false);
                break;
            }
            case 0:
            {
                heart1.gameObject.SetActive(false);
                deathScreen.gameObject.SetActive(true);
                allowMovement = false; 
                break;
            }
        }


    }

    public void addHealth(float num)
    {
        switch (num)
        {
            case 3:
                {
                    heart3.gameObject.SetActive(true);
                    break;
                }

            case 2:
                {
                    heart2.gameObject.SetActive(true);
                    break;
                }

        }
    }

    public void updateScrolls()
    {
        scrolls = scrolls + 1;
        switch (scrolls)
        {
            case 1:
            {
                scrollText.text = "1/3";
                break;
            }
            case 2:
            {
                scrollText.text = "2/3";
                break;
            }
            case 3:
            {
                scrollText.text = "3/3";
                allowMovement = false; 
                winScreen.gameObject.SetActive(true);
                UnlockNewLevel();

                break;
            }
        }

    }

    public void Teleport(Vector3 destination)
    {
        transform.position = destination;
    }


    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    IEnumerator speedBoost()
    {
        speed = speed + boost; 
            yield return new WaitForSeconds(5f);
            speed = speed - boost;

    }
    
}