using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {

    public GameObject spriteObject;
    public float rotateSpeed = 1;

    public float maxForce = 50;
    float radius = 1;
    // Use this for initialization
	void Start () 
    {
        radius = GetComponent<CircleCollider2D>().radius;
	}
	
	// Update is called once per frame
	void Update () 
    {
        spriteObject.transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
	}


    void OnTriggerStay2D (Collider2D other)
    {
        Rigidbody2D rigid = other.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            Vector3 dir = Vector3.Normalize(other.transform.position - transform.position);

            float distance = Vector3.Distance(other.transform.position, transform.position);

            rigid.AddForce(dir  * (radius-distance ) / radius * maxForce);
        }
    }
}
