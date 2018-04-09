using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContainerDelivery : MonoBehaviour
{

    private GameObject GOpoints, boat, scorePointSound;

    void Start()
    {
        GOpoints = GameObject.Find("Points");
        boat = GameObject.Find("Boat");
        scorePointSound = GameObject.Find("ScorePointAudio");
    }

    void FixedUpdate()
    {
        GOpoints.GetComponent<Text>().text = "Delivered: " + boat.GetComponent<ShipMovement>().points + "/" + boat.GetComponent<ShipMovement>().pointsTotal;
    }

    // Point +1 for every container delivered to the right pier, if a container is dropped in the ocean, totalpoints -1
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.name == "Container2" && this.gameObject.name == "Pier2") 
        {
            Destroy(col.gameObject);
            scorePointSound.GetComponent<AudioSource>().Play();
            boat.GetComponent<ShipMovement>().points += 1;
        }
        if (col.gameObject.name == "Container3" && this.gameObject.name == "Pier3")
        {
            Destroy(col.gameObject);
            scorePointSound.GetComponent<AudioSource>().Play();
            boat.GetComponent<ShipMovement>().points += 1;
        }
        if (col.gameObject.name == "Container4" && this.gameObject.name == "Pier4")
        {
            Destroy(col.gameObject);
            scorePointSound.GetComponent<AudioSource>().Play();
            boat.GetComponent<ShipMovement>().points += 1;
        }
        if(col.gameObject.tag == "container" && this.gameObject.name == "Terrain")
        {
            Destroy(col.gameObject);
            boat.GetComponent<ShipMovement>().pointsTotal -= 1;
        }
    }
}
