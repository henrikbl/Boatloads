using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContainerDelivery : MonoBehaviour {

    public int points, pointsTotal;

    void FixedUpdate()
    {
        GameObject.Find("Points").GetComponent<Text>().text = "Points : " + points;
        Finished();
    }
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.name == "Container2" && this.gameObject.name == "Pier2") 
        {
            Destroy(col.gameObject);
            points++;
        }
        else if (col.gameObject.name == "Container3" && this.gameObject.name == "Pier3")
        {
            Destroy(col.gameObject);
            points++;
        }
        else if (col.gameObject.name == "Container4" && this.gameObject.name == "Pier4")
        {
            Destroy(col.gameObject);
            points++;
        }
        else if(col.gameObject.tag == "container" && this.gameObject.name == "Terrain")
        {
            Destroy(col.gameObject);
            pointsTotal--;
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
