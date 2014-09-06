using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    
    
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRoatation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRoatation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
            
        }
    }

    void Start ()
    {
        StartCoroutine (SpawnWaves ());
    }
}
