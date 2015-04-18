using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{


    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    public float moveForce = 5;
    public float jumpForce = 10;

    public LayerMask groundMask;

    public GameObject crosshair;

    public Vector2 grav;

    public float maxHorzGrav = 9.81f;
    public float maxVertGrav = 9.81f;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        GravEffect();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Boundary"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
    void Movement()
    {
        RaycastHit2D grounded = Physics2D.Raycast(transform.position, -transform.up, boxCollider2D.size.y, groundMask);

        if (grounded.collider != null)
        {

            if (Input.GetAxis("Horizontal") > 0)
            {
                rigidbody2D.AddForce(transform.right * moveForce);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rigidbody2D.AddForce(-transform.right * moveForce);
            }


            if (Input.GetButtonDown("Jump"))
            {
                rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

    void GravEffect()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = - Camera.main.transform.position.z;
        crosshair.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        float t = ( (mousePos.x - (float)Screen.width / 2)) / ((float)Screen.width / 2);
        t = Mathf.Clamp(t, -1, 1);

        grav.x = t * maxHorzGrav;

        t = (mousePos.y - (float)Screen.height / 2) / ((float)Screen.height / 2);
        t = Mathf.Clamp(t, -1, 1);

        grav.y = t * maxVertGrav;


        Physics2D.gravity = grav;
    }


}