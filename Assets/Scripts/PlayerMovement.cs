using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 30.0f;
    public float speedReductionMultiplier = 0.95f;

    public float RotationSpeed = 5f;

    public Camera playerCamera;
    public float playerCameraAngle;
    public float playerCameraOffsetHorizontal;
    public float playerCameraOffsetVertical;
    public float playerCameraOffsetUpwards;




    private float vAxis;
    private float hAxis;

    private Vector3 forceDirection;

    private Vector2 mousePosition;
    private Vector2 playerScreenPosition;
    private float angle;
    [SerializeField] private float angleThreshold = 1.0f;


    private Vector3 clampedVelocity;


    //[SerializeField] Gameobject ob

    private Rigidbody rb;

    public float thrust = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial player camera angle
        //playerCamera.playerCameraAngle;

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






        // the following code moves with camera with the player
        playerCamera.transform.position = transform.position + new Vector3(playerCameraOffsetHorizontal,
                                                                           playerCameraOffsetUpwards,
                                                                           playerCameraOffsetVertical);


        // the following code makes the player rotate to the mouse
        playerScreenPosition = Camera.main.WorldToViewportPoint(transform.position);
        mousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = AngleBetweenPoints(playerScreenPosition, mousePosition);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        //Debug.Log(angle);

        
        

       
        
        Debug.Log(rb.velocity.magnitude);
    }



    // FixedUpdate to execute physics
    void FixedUpdate()
    {
        // apply a force to the Rigidbody to push it in the direction of forceDirection vector
        rb.AddForce(forceDirection * thrust, ForceMode.Impulse);
        Debug.DrawLine(transform.position, transform.position + forceDirection * thrust, Color.green, 0f, false);

        if (rb.velocity.magnitude > maxSpeed)
        {
            //rb.AddForce(-forceDirection * (thrust + 10) , ForceMode.Impulse);
            //Debug.DrawLine(transform.position, transform.position - forceDirection * (thrust + 10), Color.red, 0f, false);
            //Debug.Log("applying force");
            //rb.velocity.magnitude = maxSpeed;

            clampedVelocity = rb.velocity.normalized;
            clampedVelocity *= maxSpeed;
            rb.velocity = clampedVelocity;

        }
        

    }

    // Function that returns the angle between two points
    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        // add 90 degree offset so that the angle is correct
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg + 90f;
    }
}
