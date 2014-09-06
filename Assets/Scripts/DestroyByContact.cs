using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Boundary") {
            return;
        }
        Destroy (other.gameObject);
        Destroy (gameObject);
        if (other.tag == "Player") {
            Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate (explosion, transform.position, transform.rotation);
    }
}
