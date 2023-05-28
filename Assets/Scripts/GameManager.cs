using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject meteorPrefab; // the meteor prefab to spawn
    public Transform[] spawnPoints; // the points where the meteors will spawn
    public float spawnInterval = 2f; // the time interval between meteor spawns
    public int maxLives = 3; // the maximum number of lives the player has
    public float gameOverDelay = 2f; // the delay before the game over screen appears
    public GameObject gameOverScreen; // the game over screen object
    public GameObject playerShip; // the player's spaceship object
    public int score = 0; // the player's score

    private int currentLives; // the current number of lives the player has
    private float spawnTimer; // the timer for spawning meteors
    private bool isGameOver; // flag indicating whether the game is over
    public Vector3 position;
    
    void Start()
    {
        
        currentLives = maxLives; // set the current number of lives to the maximum
    }

    void Update()
    {
        // update the spawn timer and spawn meteors if necessary
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnMeteor(position);
            spawnTimer = spawnInterval;
        }
    }

    void SpawnMeteor(Vector3 position)
    {
        Instantiate(meteorPrefab, position, Quaternion.identity);
    }

    public void LoseLife()
    {
        // subtract a life and check if the game is over
        currentLives--;
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int points)
    {
        // add points to the player's score
        score += points;
    }

    void GameOver()
    {
        isGameOver = true;
        playerShip.SetActive(false); // disable the player's spaceship object
        Invoke("ShowGameOverScreen", gameOverDelay); // show the game over screen after a delay
    }

    /* void ShowGameOverScreen()
     {
         gameOverScreen.SetActive(true); // enable the game over screen object
     }*/

    public void RestartGame()
    {
        // restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor"))
        {
            // if the GameManager collides with a meteor, destroy the meteor
            Destroy(other.gameObject);
            LoseLife();
        }
    }
}