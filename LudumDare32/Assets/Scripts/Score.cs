using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public GameObject BestDeaths;
    public GameObject LastDeaths;

    public GameObject BestTime;
    public GameObject LastTime;

    public GameObject BestTotalTime;
    public GameObject LastTotalTime;


    // Use this for initialization
    void Start()
    {
    //    PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("BestDeaths", int.MaxValue) != int.MaxValue)
        {
            BestDeaths.GetComponent<Text>().text = "Best Deaths: " + PlayerPrefs.GetInt("BestDeaths", int.MaxValue);
        }
        if (PlayerPrefs.GetInt("Deaths", int.MaxValue) != int.MaxValue)
        {
            LastDeaths.GetComponent<Text>().text = "Last Deaths: " + PlayerPrefs.GetInt("Deaths");
        }

        if (PlayerPrefs.GetFloat("BestTime", float.MaxValue) != float.MaxValue)
        {
            BestTime.GetComponent<Text>().text = "Best Time: " + PlayerPrefs.GetFloat("BestTime");
        }

        if (PlayerPrefs.GetFloat("LastTime", float.MaxValue) != float.MaxValue)
        {
            LastTime.GetComponent<Text>().text = "Last Time: " + PlayerPrefs.GetFloat("LastTime");
        }

        if (PlayerPrefs.GetFloat("BestTotalTime", float.MaxValue) != float.MaxValue)
        {
            BestTotalTime.GetComponent<Text>().text = "Best Total Time: " + PlayerPrefs.GetFloat("BestTotalTime");
        }

        if (PlayerPrefs.GetFloat("LastTotalTime", float.MaxValue) != float.MaxValue)
        {
            LastTotalTime.GetComponent<Text>().text = "Last Total Time: " + PlayerPrefs.GetFloat("LastTotalTime");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
