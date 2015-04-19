using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GameObject winText;


    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Win") > 0)
        {
            winText.SetActive(true);
        }
        else
        {
            winText.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }



    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Deaths", 0);

        PlayerPrefs.SetInt("Win", 0);
        Application.LoadLevel("Main");
    }




}
