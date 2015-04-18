using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Vector2 grav;

    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    public float moveForce = 5;
    public float jumpForce = 10;

    public LayerMask ground;
 
    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grav = Physics2D.gravity;

        RaycastHit2D grounded = Physics2D.Raycast(transform.position, -transform.up, boxCollider2D.size.y, ground);

        if (grounded.collider != null)
        {
            Debug.Log(grounded.collider.name );

            if (Input.GetAxis("Horizontal") > 0)
            {
                rigidbody2D.AddForce(transform.right * moveForce);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rigidbody2D.AddForce(-transform.right * moveForce);
            }


            if (Input.GetButtonDown("Jump") )
            {
                rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Boundary"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
