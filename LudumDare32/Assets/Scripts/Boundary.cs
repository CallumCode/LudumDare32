﻿using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
        

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (! coll.collider.CompareTag("Player"))
        {

            Destroy(coll.gameObject);
        }
    }
}
