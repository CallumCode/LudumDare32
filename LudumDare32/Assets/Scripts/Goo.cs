using UnityEngine;
using System.Collections;

public class Goo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rigid = other.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            if (other.CompareTag("Player"))
            {
                rigid.velocity = 0.25f * rigid.velocity;
            }
            else
            {
                if (other.CompareTag("Bullet"))
                {
                    other.GetComponent<Bullet>().UpdateSpeed(0);
                }

                Destroy(rigid);
            }
        }
    }

}
