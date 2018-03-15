using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAttack : MonoBehaviour {


    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCollider = 0.3f;
    public bool dead = false;

    Animator animator;
    public Collider2D EnemyAttackTrigger;


       // Use this for initialization
    void Start () {

    }

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        EnemyAttackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if(dead == false)
        {
        animator.SetBool("run", true);

            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                    EnemyAttackTrigger.enabled = false;
                }

                EnemyAttackTrigger.enabled = true;
                animator.SetTrigger("skill_1");

            }

            if (attacking == false)
            {
                EnemyAttackTrigger.enabled = false;
            }
        }
        else
        {
            Debug.Log("Kuollut");
            animator.SetBool("death", true);
            SceneManager.LoadScene("ending");
        }


    }




    void OnCollisionEnter2D(Collision2D other)
    //OnCollisionEnter2D
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Vihollinen hyökkää");
            attacking = true;
            attackTimer = attackCollider;
            

        }
    }
    public void Dead()
    {
      
        dead = true;
    }



}
