using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject bulletSpawn;

    public GameObject bulletPrefab;

    public GameObject turret;
    public GameObject player;

    public float fireRate = 1;

    float timer = 0;

    public float bulletForce = 100;
    void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateFire();
	}

    void Fire()
    {

        Vector3 dir = bulletSpawn.transform.position - transform.position;
        

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletPrefab.transform.rotation) as GameObject;
        bullet.transform.right = -dir.normalized;
        
        bullet.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.right * bulletForce , ForceMode2D.Impulse);

        timer = Time.time;
    }
        
    void UpdateFire()
    {

        turret.transform.right = Vector3.Normalize(transform.position - player.transform.position);

        if(Time.time > ( timer + 1/fireRate))
        {
            Fire();
        }
    }

}
