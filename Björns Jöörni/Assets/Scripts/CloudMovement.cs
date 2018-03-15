using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {
    public float movementSpeed = 1f;

    // Update is called once per frame
    private void Update () {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        if(transform.position.x >= 11.5f) {
            transform.position = new Vector2(-11.5f, 0.3098765f);
        }
    }
}
