using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest : MonoBehaviour
{
    [SerializeField] private GameObject ropeSegment;
    public float speed;

    private float segmentLength;

    private Vector3 start;
    private Vector3 end;
    private float distance;

    private GameObject clone1;
    private GameObject clone2;

    // Start is called before the first frame update
    void Start()
    {
        // get the length of the rope Segment
        Vector3 m_Size;
        //Fetch the Collider from the GameObject
        Collider m_Collider = ropeSegment.GetComponent<Collider>();
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        segmentLength = m_Size.z;

        start = new Vector3(4, 1, 0);
        end = new Vector3(14, 1, 0);
        distance = Vector3.Distance(start, end);
        //Debug.Log(distance);

        clone1 = ropeSegment;

        StartCoroutine(CloneSegments());

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(start, end, Color.blue, 1f, false);


    }


    IEnumerator CloneSegments()
    {
        
        for (int i = 0; i < 10; ++i)
        {
            clone2 = Instantiate(clone1, clone1.transform.position + (clone1.transform.forward * (segmentLength + 0.1f)), clone1.transform.rotation);
            clone2.GetComponent<HingeJoint>().connectedBody = clone1.GetComponent<Rigidbody>();
            


            clone1 = clone2;

            

            //Debug.Log(i);
            yield return null;
        }
        
    }

}
