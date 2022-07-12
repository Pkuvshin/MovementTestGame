using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject grappleHook;
    [SerializeField] private GameObject ropeSegment;


    private Vector3 playerPos;
    private Vector3 finalPos;
    private Vector3 travelDirection;

    public float grappleSpeed;
    private bool enable_grapple;

    private bool touchingWall;

    private Rigidbody hook_rb;

    private RaycastHit hit;


    private bool isActive;

    void Start()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), grappleHook.GetComponent<Collider>());
        hook_rb = grappleHook.GetComponent<Rigidbody>();


        touchingWall = false;

        isActive = false;

        enable_grapple = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(player.transform.position, player.transform.position + player.transform.forward, Color.blue, 0f, false);
        //Debug.DrawLine(grappleHook.transform.position, grappleHook.transform.position + player.transform.forward, Color.blue, 0f, false);

        if (!enable_grapple)
        {
            // make the grapple have the same position and rotation as the player
            grappleHook.transform.position = player.transform.position;
            grappleHook.transform.eulerAngles = player.transform.eulerAngles;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Pressed secondary button.");
            enable_grapple = true;
            finalPos = hit.point;
            
            if (!isActive) {
                
            }
            isActive = true;
        }

        // move grapple towards desired location
        if (enable_grapple)
        {
            grappleHook.transform.position = Vector3.MoveTowards(grappleHook.transform.position, finalPos, grappleSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1)) {
            enable_grapple = false;
            
        }

    }

    void FixedUpdate()
    {
        // raycast
        if (Physics.Raycast(player.transform.position, -player.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(player.transform.position, -player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }




}

