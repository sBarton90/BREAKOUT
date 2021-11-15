using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Prefabs")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;

    [Header("Wave Prefabs")]
    [SerializeField] GameObject brickWaveOne;
    [SerializeField] GameObject brickWaveTwo;
    [SerializeField] GameObject brickWaveThree;

    [Header("UI Elements")]
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    [SerializeField] Text gameOverText;

    private int lives = 3;
    private int score;
    int spawnSelect = 2;
   


    Vector3 brickWaveOneSpawn = new Vector3(.98f, -.48f, 0);
    Vector3 brickWaveTwoSpawn = new Vector3(-3.9f, .55f, 0);
    Vector3 brickWaveThreeSpawn = new Vector3(-3.75f, 1.5f, 0);
    Vector3 ballSpawnPoint = new Vector3(0, -4f, 0);
    Vector3 playerSpawnPoint = new Vector3(0, -4.5f, 0);

    void Start()
    {
        UpdateScoreText();
        SpawnWaveOne();
        SpawnPlayerWithBall();
    }

    private void FixedUpdate() {
        if (GameObject.FindWithTag("Ball") == null && lives != 0) {
            DestroyPlayerAndBall();
            lives--;
            lives--;
            livesText.text = "Lives: " + lives;
            SpawnPlayerWithBall();

            if (lives == 0) {
                gameOverText.gameObject.SetActive(true);
                DestroyPlayerAndBall();
            }
        }
        
        if (GameObject.FindWithTag("Brick") == null && spawnSelect == 2) {
            DestroyPlayerAndBall();
            SpawnWaveTwo();
            spawnSelect++;
        } else if (GameObject.FindWithTag("Brick") == null && spawnSelect == 3) {
            DestroyPlayerAndBall();
            SpawnWaveThree();
        }

    }

    void SpawnPlayerWithBall() {
        Instantiate(player, playerSpawnPoint, Quaternion.identity);
        Instantiate(ball, ballSpawnPoint, Quaternion.identity);
    }

    void SpawnWaveOne() {
        Instantiate(brickWaveOne, brickWaveOneSpawn, Quaternion.identity);
    }

    void SpawnWaveTwo() {
        Instantiate(brickWaveTwo, brickWaveTwoSpawn, Quaternion.identity);
    }

    void SpawnWaveThree() {
        Instantiate(brickWaveThree, brickWaveThreeSpawn, Quaternion.identity);
    }

    public void AddToScore(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }

    private void DestroyPlayerAndBall() {
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.FindWithTag("LargerPlayer"));
        Destroy(GameObject.FindWithTag("LaserPlayer"));
        Destroy(GameObject.FindWithTag("Ball"));
        lives++;
    }


}
