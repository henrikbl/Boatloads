using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

        //Clean the highscore list
        /*
        PlayerPrefs.SetInt("top1", 0);
        PlayerPrefs.SetInt("top2", 0);
        PlayerPrefs.SetInt("top3", 0);
        PlayerPrefs.SetInt("top4", 0);
        PlayerPrefs.SetInt("top5", 0);
        */

        GameObject.Find("top1").GetComponent<Text>().text = PlayerPrefs.GetInt("top1") + "";
        GameObject.Find("top2").GetComponent<Text>().text = PlayerPrefs.GetInt("top2") + "";
        GameObject.Find("top3").GetComponent<Text>().text = PlayerPrefs.GetInt("top3") + "";
        GameObject.Find("top4").GetComponent<Text>().text = PlayerPrefs.GetInt("top4") + "";
        GameObject.Find("top5").GetComponent<Text>().text = PlayerPrefs.GetInt("top5") + "";
    }
	
}
