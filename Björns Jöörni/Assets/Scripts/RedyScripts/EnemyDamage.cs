using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour {
    public EnemyAttack _EnemyAttack;
    public float enemyHealht;
    public float currentHealth;
    private Animator animator;
    // Use this for initialization
    void Start () {
        currentHealth = enemyHealht;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth<= 0)
        {
            transform.GetComponent<EnemyAttack>().Dead();
            transform.GetComponent<EnemyMovement>().Dead();
        }
	}
    public void Damage(int enemyDamage)
    {
        Debug.Log("Nyt sattuupi");
        currentHealth -= enemyDamage;
        animator.SetBool("hit_1",true);
    }
}
