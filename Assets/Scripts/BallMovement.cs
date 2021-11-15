using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rBody;
    private bool pressedSpace;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !pressedSpace) {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rBody.velocity = new Vector2(speed * x, speed * y);
            pressedSpace = true;
        }
    }
}
     