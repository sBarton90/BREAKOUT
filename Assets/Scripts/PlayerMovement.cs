using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] public bool pressedSpace;
    [SerializeField] Rigidbody2D myRigidbody;


    bool canMove = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();   
    }

    void MovePlayer() {
        if (!pressedSpace) {
            canMove = false;
            if (Input.GetKey(KeyCode.Space)) {
                pressedSpace = true;
                canMove = true;
            }
        }

        if (canMove) {
            float moveAmount = Input.GetAxis("Horizontal") * moveSpeed;
            myRigidbody.velocity = new Vector2(moveAmount, myRigidbody.velocity.y);
        }
    }
}
