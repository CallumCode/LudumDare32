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

    public Animator animator;

    public Vector2 grav;

    public float maxHorzGrav = 9.81f;
    public float maxVertGrav = 9.81f;

    public GameObject sprite;
    bool facingRight = true;

    public float airDrag = 0.5f;
     public float groundDrag = 1;

     public GameObject groundCheck; 
    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren< Animator > ();
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
            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
            PlayerPrefs.SetFloat("LastTotalTime", PlayerPrefs.GetFloat("LastTotalTime") + (int)Time.timeSinceLevelLoad);

            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
    void Movement()
    {
        RaycastHit2D grounded = Physics2D.Raycast(transform.position, -transform.up, boxCollider2D.size.y, groundMask);
        grounded = Physics2D.CircleCast(groundCheck.transform.position, boxCollider2D.size.x / 1.8f, -transform.up, boxCollider2D.size.x / 1.8f , groundMask);

        animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);

          
            if ( rigidbody2D.velocity.x > 0 && !facingRight)
            {
                Flip();                 
            }
            else if (rigidbody2D.velocity.x < 0 && facingRight)
            {
                Flip();
            } 
      

        if (grounded.collider != null)
        {
         //   Debug.Log(grounded.collider.name);

            rigidbody2D.drag = groundDrag;

            animator.SetBool("TouchGround", true);

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
        else
        {
            rigidbody2D.drag = airDrag;

            animator.SetBool("TouchGround" ,false);
        }

    }

    void GravEffect()
    {
       

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = - Camera.main.transform.position.z;
        crosshair.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        float t =    ( (mousePos.x - (float)Screen.width / 2)) / ((float)Screen.width / 2);
        t = Mathf.Clamp(t, -1, 1);

        grav.x = t * maxHorzGrav;

        t = (mousePos.y - (float)Screen.height / 2) / ((float)Screen.height / 2);
        t = Mathf.Clamp(t, -1, 1);

        grav.y = t * maxVertGrav;


        Physics2D.gravity = grav;   
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}