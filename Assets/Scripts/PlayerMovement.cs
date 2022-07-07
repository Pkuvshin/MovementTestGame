using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 10000.0f;

    public float RotationSpeed = 5f;



    private float vAxis;
    private float hAxis;

    Vector3 forceDirection;

    //[SerializeField] Gameobject ob

    Rigidbody rb;

    public float thrust = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // get Rigidbody of parent GameObject
        rb = gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input of axis
        vAxis = -Input.GetAxis("Vertical");
        hAxis = -Input.GetAxis("Horizontal");

        // set vector based on axis direction
        forceDirection = new Vector3(hAxis, 0, vAxis);

        // Prevent the player from moving faster than maxSpeed
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    // FixedUpdate to execute physics
    void FixedUpdate()
    {
        // apply a force to the Rigidbody to push it in the direction of forceDirection vector
        rb.AddForce(forceDirection * thrust ,ForceMode.Impulse);

        //a different way of limiting max speed
        /*
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        */

    }
}
