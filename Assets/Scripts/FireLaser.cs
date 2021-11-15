using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserSpawner;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite normalSprite;

    public int fireCount;

    
    void Update()
    {
        if (fireCount > 0) {
            ShootLaser();
        } else if (fireCount <= 0) {
            spriteRenderer.sprite = normalSprite;
        }
        
    }

    void ShootLaser() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Instantiate(laser, laserSpawner.GetComponent<Transform>().position, Quaternion.identity);
            fireCount--;
        }
    }
}
