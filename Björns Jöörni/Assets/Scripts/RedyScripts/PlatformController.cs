using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {   
  public float speed = 10f;
  public float jumpForce = 1000f;
  private Animator anim;
  private Rigidbody2D rb2d;


    // Use this for initialization
    private void Awake () {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
  }

    // Update is called once per frame   
    private void Update() {
    if (Input.GetAxis("Horizontal") != 0) {
      transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
      anim.SetBool("Walk", true);

      // Flip sprite
      if (Input.GetAxisRaw("Horizontal") == 1) {
        transform.localScale = new Vector3(1, 1, 1);
      } else if (Input.GetAxisRaw("Horizontal") == -1) {
         transform.localScale = new Vector3(-1, 1, 1);
      }

    } else {
      anim.SetBool("walk", false);
    }

    if (Input.GetButtonDown("Jump")) {
      rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      anim.SetTrigger("Jump");
    }
  } 
}
