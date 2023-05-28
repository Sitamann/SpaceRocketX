using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed = 5f; // speed of the meteor movement
    public float minRotationSpeed = 50f; // minimum rotation speed of the meteor
    public float maxRotationSpeed = 200f; // maximum rotation speed of the meteor

    private float rotationSpeed; // the current rotation speed of the meteor

    void Start()
    {
        // set a random rotation speed for the meteor
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        // move the meteor along the Z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // rotate the meteor
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
        }
    }
}
