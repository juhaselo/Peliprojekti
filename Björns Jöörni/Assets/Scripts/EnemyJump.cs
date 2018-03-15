using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {
    public Rigidbody2D enemyRB;
    public float jumpForce;

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemyJump")
        {
            enemyRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
