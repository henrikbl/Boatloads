using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    private GameObject craneSound, controllChanger;
    public int craneID;
    public float turn, turnspeed = 1f;

    void Start()
    {
        craneSound = GameObject.Find("CraneAudio");
        controllChanger = GameObject.Find("PlayerChanger");
    }

    // Rotate Crane
    void Update ()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, 40.0f);
        foreach (Collider e in hit)
        {
            if (e.name == "Boat")
            {
                controllChanger.GetComponent<PlayerChange>().setID = craneID;
                if (controllChanger.GetComponent<PlayerChange>().playerChanger == craneID && e.name == "Boat")
                {
                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        craneSound.GetComponent<AudioSource>().Play();
                        turn = Input.GetAxis("Horizontal") * turnspeed;
                        transform.Rotate(new Vector3(0, turn, 0));
                    }
                    else if(Input.GetAxis("Horizontal") == 0)
                    {
                        craneSound.GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
	}
}
