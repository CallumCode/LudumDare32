using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextShadow : MonoBehaviour
{

     public Text parentText;

    // Use this for initialization
    void Start() 
    {
              Text text = GetComponent<Text>();

              text.text = parentText.text;
              text.fontSize  = parentText.fontSize;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
