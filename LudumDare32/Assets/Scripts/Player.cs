using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Vector2 grav;

    Rigidbody2D rigidbody2D;

    public float moveForce = 5;
    public float jumpForce = 10;

     public GameObject groundCheck;

	// Use this for initialization
	void Start () 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        grav = Physics2D.gravity;
        
        if( Input.GetAxis("Horizontal") > 0  )
        {
            rigidbody2D.AddForce(transform.right * moveForce);
        } 
        else  if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2D.AddForce(-transform.right * moveForce);
        }

        bool grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position , LayerMask.NameToLayer("Ground") );

        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            rigidbody2D.AddForce(transform.up * jumpForce , ForceMode2D.Impulse);
        }
    }
}
