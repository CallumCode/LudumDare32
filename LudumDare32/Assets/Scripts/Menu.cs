using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GameObject winText;

    public Animator score;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Win") > 0)
        {
            winText.SetActive(true);
            score.SetTrigger("ShowHide");
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
        PlayerPrefs.SetFloat("LastTotalTime", 0);

        PlayerPrefs.SetInt("Win", 0);
        Application.LoadLevel("Main");
    }




}
