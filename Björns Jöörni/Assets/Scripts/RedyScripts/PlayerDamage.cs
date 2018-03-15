using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public float previousHealth;

    public Image healthBar;

    public float timer;
    public float maxTimer;
    private Animator animator;

    public int frame;


    // Use this for initialization
    private void Start () {

        animator = GetComponent<Animator>();


        currentHealth = maxHealth;
        previousHealth = currentHealth;

    }

    // Update is called once per frame
    private void Update () {

        animator = GetComponent<Animator>();

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

           }


   
    void hardRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




   /* IEnumerator CharDeath()
    {
        
        yield return new WaitForSeconds(2.0f);
       Destroy(gameObject);

    } */

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Damage" && gameObject.tag != "Attack")
        {
            timer = 0;
            previousHealth = currentHealth;
            currentHealth -= 10;


        }

        if (other.gameObject.tag == "EnemyAttack" && gameObject.tag != "Attack")
        {
            timer = 0;
            previousHealth = currentHealth;
            currentHealth -= 8;

            // Jos die koodi

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Die");
                Object.Destroy(gameObject, 5.0f);
                yield return new WaitForSeconds(2.0f);
                hardRestartGame();
            }


        }

    }

  
}
