using UnityEngine;
using System.Collections;

public class WinArea : MonoBehaviour 
{

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

            if (PlayerPrefs.GetInt("Deaths") < PlayerPrefs.GetInt("BestDeaths", int.MaxValue))
            {
                PlayerPrefs.SetInt("BestDeaths", PlayerPrefs.GetInt("Deaths"));

            }
            PlayerPrefs.SetFloat("LastTime", (int)Time.timeSinceLevelLoad);

            if (PlayerPrefs.GetFloat("LastTime") < PlayerPrefs.GetFloat("BestTime", int.MaxValue))
            {
                PlayerPrefs.SetFloat("BestTime", PlayerPrefs.GetFloat("LastTime"));
            }
            ///

            PlayerPrefs.SetFloat("LastTotalTime", PlayerPrefs.GetFloat("LastTotalTime") + (int)Time.timeSinceLevelLoad);

            if (PlayerPrefs.GetFloat("LastTotalTime") < PlayerPrefs.GetFloat("BestTotalTime", int.MaxValue))
            {
                PlayerPrefs.SetFloat("BestTotalTime", PlayerPrefs.GetFloat("LastTotalTime"));
            }

            PlayerPrefs.SetInt("Win", 1);
             Application.LoadLevel("Start");
            
        }
    }
}
