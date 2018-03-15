using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int damage;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            Debug.Log("Nyt tuloo vahinkoo");
            col.SendMessageUpwards("Damage", damage);
        }
    }

}
