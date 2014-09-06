using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    bool gameOver;
    bool restart;
    int score;   

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (!gameOver) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRoatation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRoatation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
            
        }
        restartText.text = "Press 'R' to restart";
        restart = true;
    }

    public void AddScore (int scoreIncrement)
    {
        score += scoreIncrement;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    void Update ()
    {
        if (restart) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
    }

    void Start ()
    {
        StartCoroutine (SpawnWaves ());
        UpdateScore ();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        score = 0;
    }
}
