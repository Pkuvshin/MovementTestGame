using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UiElementControlScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI velocityText;

    private Rigidbody rb;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
        velocityText.text = "0 m/s";

        // access the PlayerMovement script
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude > playerMovement.maxSpeed)
        {
            velocityText.text = playerMovement.maxSpeed.ToString("#####0.0") + " m/s";
        }
        else if (rb.velocity.magnitude < 0.1)
        {
            velocityText.text = "0 m/s";
        }
        else
        {
            velocityText.text = rb.velocity.magnitude.ToString("#0.0") + " m/s";
        }
        

    }


}