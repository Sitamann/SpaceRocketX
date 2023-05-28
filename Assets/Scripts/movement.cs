using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // speed of the horizontal movement
    public float tiltAmount = 20f; // amount to tilt the spaceship when turning
    public float smoothTime = 0.1f; // time it takes to smoothly interpolate the movement
    public float maxTiltAngle = 45f; // maximum angle the spaceship can tilt
    public float tiltSpeed = 5f; // speed at which the spaceship tilts

    private float targetPosition; // the target horizontal position of the spaceship
    private Vector3 velocity; // the current velocity of the spaceship
    private float currentTiltAngle; // the current tilt angle of the spaceship

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // get the horizontal input

        // set the target horizontal position based on the input
        targetPosition = transform.position.x + horizontalInput * speed * Time.deltaTime;

        // smoothly interpolate the current position towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition, transform.position.y, transform.position.z), ref velocity, smoothTime);

        // tilt the spaceship when turning
        float tiltAngle = -horizontalInput * tiltAmount;
        tiltAngle = Mathf.Clamp(tiltAngle, -maxTiltAngle, maxTiltAngle);
        currentTiltAngle = Mathf.Lerp(currentTiltAngle, tiltAngle, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, currentTiltAngle);
    }
}