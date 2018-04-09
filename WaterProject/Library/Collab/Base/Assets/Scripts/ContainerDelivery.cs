using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContainerDelivery : MonoBehaviour {

    public int points, pointsTotal;

    void Start()
    {
        pointsTotal = 9;
        points = 0;
        GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
    }

	/*

    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.name == "Container2" && this.gameObject.name == "Pier2") 
        {
            Destroy(col.gameObject);
            points++;
            GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
            Finished();
        }
        else if (col.gameObject.name == "Container3" && this.gameObject.name == "Pier3")
        {
            Destroy(col.gameObject);
            points++;
            GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
            Finished();
        }
        else if (col.gameObject.name == "Container4" && this.gameObject.name == "Pier4")
        {
            Destroy(col.gameObject);
            points++;
            GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
            Finished();
        }
        else if(col.gameObject.tag == "container" && this.gameObject.name == "Terrain")
        {
            Destroy(col.gameObject);
            pointsTotal--;
            Finished();
        }
    }
*/


	void OnCollisionEnter(Collision col)
	{
		if ((col.gameObject.name == "Container2" && this.gameObject.name == "Pier2")||(col.gameObject.name == "Container3" && this.gameObject.name == "Pier3")||(col.gameObject.name == "Container4" && this.gameObject.name == "Pier4")) 
		{
			Destroy(col.gameObject);
			points++;
			GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
			Finished();
		}
		else if(col.gameObject.tag == "container" && this.gameObject.name == "Terrain")
		{
			Destroy(col.gameObject);
			pointsTotal--;
			Finished();
		}
	}




    void Finished()
    {
        if(points == pointsTotal)
        {
            SceneManager.LoadScene("Startmenu");
        }
    }
}
