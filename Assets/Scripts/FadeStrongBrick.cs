using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeStrongBrick : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    int hitCount = 0;

    private void Update() {
        if (hitCount == 1) {
            spriteRenderer.color = new Color(1, 1, 1);
        } else if (hitCount == 2) {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        hitCount++;
    }
}
