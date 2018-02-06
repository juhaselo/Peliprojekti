using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{

    public float movementSpeed;
    public float jumpForce;
    public Animator animator;
    public Rigidbody2D playerRB;
    public bool grounded;

    public float maxHealth;
    public float currentHealth;
    public float previousHealth;

    public Image healthBar;

    public float timer;
    public float maxTimer;


    // Use this for initialization
    void Start()
    {

        currentHealth = maxHealth;
        previousHealth = currentHealth;
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (timer < maxTimer)
        {

            timer += Time.deltaTime;
        }
        else
        {
            previousHealth = currentHealth;
            timer = 0;


        }


        healthBar.fillAmount = Mathf.Lerp(previousHealth / maxHealth, currentHealth / maxHealth, timer / maxTimer);




       if (grounded == true)
       {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("HYPPY");

                playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
            }
       }




        transform.Translate(new Vector3(Input.GetAxis("Horizontal") *
        movementSpeed * Time.deltaTime, 0, 0));
        //Debug.Log (Input.GetAxis ("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            animator.SetBool("Walk", true);

        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground on True");
            grounded = true;
        }
        if (other.gameObject.tag == "Damage")
        {
            Debug.Log ("Damage");
            timer = 0;
            previousHealth = currentHealth;
            currentHealth -= 1;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground on false");
            grounded = false;
        }
    }

}
