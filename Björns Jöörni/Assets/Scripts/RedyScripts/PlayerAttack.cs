using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCollider = 0.3f;

    public Collider2D attackTrigger;

    private Animator animator;

    // Use this for initialization
    private void Start () {
		
	}

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }


    // Update is called once per frame
    private void Update () {
		if(Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            attackTimer = attackCollider;
            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

            animator.SetTrigger("Attack");

        }
    }
}
