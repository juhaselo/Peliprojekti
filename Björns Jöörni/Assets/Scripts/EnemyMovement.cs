using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Animator animator;
    public float movementSpeed;
    public bool goLeft = false;
    public bool dead = false;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if(dead == false) { 
            if(goLeft == true)
            {
                transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
                transform.localScale = new Vector2(-0.01f, 0.01f);
            }
            if(goLeft == false)
            {
                transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
                transform.localScale = new Vector2(0.01f, 0.01f);
            }

        }

    }
    public void GoLeft()
    {
        goLeft = true;
        Debug.Log("Moi");
    }
    public void GoRight()
    {
        goLeft = false;
        Debug.Log("Hei");
    }
 public void Dead()
    {
        dead = true;
    }

   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "left")
        {
            movementDeriction = false;
        }
        if(other.gameObject.tag == "right")
        {
            movementDeriction = true;
        }
    }*/
}
