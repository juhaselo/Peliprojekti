using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurner : MonoBehaviour {

    public GameObject host;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(gameObject.tag);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Moikka");
        if (gameObject.tag == "Left" && other.gameObject.tag == "Enemy")
        {
            Debug.Log("Osuttiin vasuriin");
            host.gameObject.GetComponent<EnemyMovement>().GoRight();
        }
        if (gameObject.tag == "Right" && other.gameObject.tag == "Enemy")
        {
            Debug.Log("Osuttiin oikeeseen");
            host.gameObject.GetComponent<EnemyMovement>().GoLeft();
        }
    }

}
