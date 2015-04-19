using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rigidBody2D;
    Animator animator;

    public float time = 15;
    // Use this for initialization
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Invoke("DestroySelf", time);
    }

    // Update is called once per frame
    void Update()
    {

        if (rigidBody2D != null)
        {
            UpdateSpeed(rigidBody2D.velocity.magnitude);
        }
    }

    public void UpdateSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
