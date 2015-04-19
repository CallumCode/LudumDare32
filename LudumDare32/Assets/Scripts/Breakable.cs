using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour
{

    public Sprite[] stagesOfBreak;

    const float maxHealth = 250;
    float health = maxHealth;

    SpriteRenderer spriteRenderer;

    public BoxCollider2D breakableColider; 
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void TakeDamage(float amount, string who )
    {

        health -= amount;
            
        health = Mathf.Clamp(health, 0, maxHealth);
        int index = Mathf.RoundToInt((1- health / maxHealth) * (stagesOfBreak.Length -1 ));

        spriteRenderer.sprite = stagesOfBreak[index];

        if(index == ( stagesOfBreak.Length -1  ))
        {
            Changeboundarys();
        }
    //    Debug.Log(" Health : " + health + " took " + amount + " from " + who );

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.rigidbody != null  && health > 0)
        {

            TakeDamage(coll.rigidbody.velocity.magnitude * coll.rigidbody.velocity.magnitude*  coll.rigidbody.mass , coll.collider.name);
        }

    }

    void Changeboundarys()
    {
        breakableColider.enabled = false;
    }

}
