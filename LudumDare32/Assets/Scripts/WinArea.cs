using UnityEngine;
using System.Collections;

public class WinArea : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ( coll.collider.CompareTag("Player"))
        {

            PlayerPrefs.SetInt("Win", 1);
                
             Application.LoadLevel("Start");
            
        }
    }
}
