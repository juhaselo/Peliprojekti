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



    // Use this for initialization
    private void Start()
    {

        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void Update()
    {


        if (grounded == true)
       {
            if (Input.GetButtonDown("Jump"))
            {
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground on True");
            grounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground on false");
            grounded = false;
        }
    }

}
