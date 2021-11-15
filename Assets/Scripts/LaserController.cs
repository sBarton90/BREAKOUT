using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Brick")) {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
