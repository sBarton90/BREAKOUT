using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPowerup : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite laserSprite;
    public FireLaser fireLaser;

    private void OnTriggerEnter2D(Collider2D other) {
        AssignPower();
        Destroy(other.gameObject);
    }

    void AssignPower() {
        int num = Random.Range(0, 11);
        if (num <= 5) {
            SpawnLaserPaddle();
        } else {
            ExtendThePaddle();
        }
    }

    void SpawnLaserPaddle() {
        transform.localScale = new Vector3(2, 1, 1);
        spriteRenderer.sprite = laserSprite;
        fireLaser.fireCount = 5;
    }

    void ExtendThePaddle() {
        transform.localScale = new Vector3(2.5f, 1, 1);
    }
}
