using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    GameController gameController;

    public int scoreValue;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController> ();
        }
        if (gameController == null) {
            Debug.Log ("Cannot find 'GameController' script.");
        }
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Boundary") {
            return;
        }
        Destroy (other.gameObject);
        Destroy (gameObject);
        if (other.tag == "Player") {
            Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver ();
        } else if (other.tag == "Bolt") {
            gameController.AddScore (scoreValue);
        }
        Instantiate (explosion, transform.position, transform.rotation);
    }
}
