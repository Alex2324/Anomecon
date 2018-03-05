using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes the camera follow the player

public class FullCameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;

    public float bufferup = 1.5f;
    public float bufferright = 0.75f;

    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    private float x = 0.0f;
    private float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            distance -= .5f * Input.mouseScrollDelta.y;
            if (distance < 0)
            {
                distance = 0;
            }

            x += Input.GetAxis("Horizontal") * xSpeed * 0.02f;
            y -= Input.GetAxis("Vertical") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(bufferright, 0.0f, -distance) + target.position + new Vector3(0.0f, bufferup, 0.0f);

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}