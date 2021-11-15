using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] GameManager gameManagerScript;
    [SerializeField] int brickScore = 10;
    [SerializeField] GameObject powerup;
    private float randomNum;
    

    private void Start() {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null) {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Brick")) {
            gameManagerScript.AddToScore(brickScore);
            Vector3 powerUpSpawn = new Vector3(other.transform.position.x, other.transform.position.y, 0);
            SpawnPowerUp(powerUpSpawn, Random.value);
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("StrongBrick")) {
            gameManagerScript.AddToScore(brickScore);
            Vector3 powerUpSpawn = new Vector3(other.transform.position.x, other.transform.position.y, 0);
            SpawnPowerUp(powerUpSpawn, Random.value);
        }
    }

    void SpawnPowerUp(Vector3 spawnPoint, float randomNum) {
        if (randomNum > .80) {
            Instantiate(powerup, spawnPoint, Quaternion.identity);
        }
    }
}
