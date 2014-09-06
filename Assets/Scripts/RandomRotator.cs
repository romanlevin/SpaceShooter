using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{

    public float tumble = 1f;

    void Start ()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
