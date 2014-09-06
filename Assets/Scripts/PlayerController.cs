using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float bank = 3;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float mouseSensitivity = 2f;
    public float fireRate = 0.5f;
    float nextShot;

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal") + Input.GetAxis ("Mouse X") * mouseSensitivity;
        float moveVertical = Input.GetAxis ("Vertical") + Input.GetAxis ("Mouse Y") * mouseSensitivity;

        Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical) * speed;
        rigidbody.velocity = movement;

        rigidbody.position = new Vector3 (
            Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.z * bank / 2f, 0f, rigidbody.velocity.x * -bank);

    }

    void Update ()
    {
        if (Input.GetButton ("Fire1") && Time.time > nextShot) {
            nextShot = Time.time + fireRate;
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play ();
        }
    }
}
