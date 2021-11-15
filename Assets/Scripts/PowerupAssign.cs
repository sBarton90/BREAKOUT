using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAssign : MonoBehaviour
{
    [SerializeField] GameObject laserPaddle;
    [SerializeField] GameObject player;
    [SerializeField] GameObject largerPlayer;

    


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player")) { 
                AssignPower();
                Destroy(this.gameObject);
        }
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
        Vector3 spawnPos = new Vector3(GameObject.FindWithTag("Player").transform.position.x, GameObject.FindWithTag("Player").transform.position.y, 0);
        Instantiate(laserPaddle, spawnPos, Quaternion.identity);
        Destroy(GameObject.FindWithTag("Player"));
    }

    void ExtendThePaddle() {
        Vector3 spawnPos = new Vector3(GameObject.FindWithTag("Player").transform.position.x, GameObject.FindWithTag("Player").transform.position.y, 0);
        Instantiate(largerPlayer, spawnPos, Quaternion.identity);
        Destroy(GameObject.FindWithTag("Player"));
    }
}
