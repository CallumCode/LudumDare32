using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

 
  public  Animator animator;
     // Use this for initialization
    void Start()
    {
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }


        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("ShowHide");
        }
    }

    void StartGame()
    {
         Application.LoadLevel("Main");
    }
}
