using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UiElementControlScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI velocityText;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
        velocityText.text = "0 m/s";

    }

    // Update is called once per frame
    void Update()
    {
        velocityText.text = rb.velocity.magnitude.ToString("#0.0") + " m/s";
    }
}
