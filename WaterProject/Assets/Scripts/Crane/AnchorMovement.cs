using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMovement : MonoBehaviour
{

    private GameObject anchorSound, controllChanger;
    private float move, moveSpeed = 0.05f;
    public int craneID;

    void Start()
    {
        anchorSound = GameObject.Find("AnchorAudio");
        controllChanger = GameObject.Find("PlayerChanger");
    }

    // Method for moving the "hook" in and out on the cranemast
    void Update()
    {

        if (controllChanger.GetComponent<PlayerChange>().playerChanger == craneID)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anchorSound.GetComponent<AudioSource>().Play();
                move += moveSpeed;
            }

            else if (Input.GetKey(KeyCode.S))
            {
                anchorSound.GetComponent<AudioSource>().Play();
                move -= moveSpeed;
            }

            else if(!Input.GetKey(KeyCode.W))
            {
                anchorSound.GetComponent<AudioSource>().Stop();
            }

            else if(!Input.GetKey(KeyCode.S))
            {
                anchorSound.GetComponent<AudioSource>().Stop();
            }

            move = Mathf.Clamp(move, 2f, 8f);
            transform.localPosition = new Vector3(0f, 7.85f, move);
        }
	}
}
