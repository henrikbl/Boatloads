using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{

    public int playerChanger, setID;
    public Camera Camera1, Camera2, Camera3, Camera4, MapCamera;

	void Start ()
    {
        playerChanger = 1;
        setID = 0;
        CameraEnabled(Camera1);
        CameraDisabled(Camera2);
        CameraDisabled(Camera3);
        CameraDisabled(Camera4);
        MapCamera.enabled = false;
    }
	
    // Controller for å bytte mellom hva man styrer (båten og kranene)
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerChanger = 1;
            CameraEnabled(Camera1);
            CameraDisabled(Camera2);
            CameraDisabled(Camera3);
            CameraDisabled(Camera4);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && setID == 2)
        {
            playerChanger = 2;
            CameraDisabled(Camera1);
            CameraEnabled(Camera2);
            CameraDisabled(Camera3);
            CameraDisabled(Camera4);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && setID == 3)
        {
            playerChanger = 3;
            CameraDisabled(Camera1);
            CameraDisabled(Camera2);
            CameraEnabled(Camera3);
            CameraDisabled(Camera4);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && setID == 4)
        {
            playerChanger = 4;
            CameraDisabled(Camera1);
            CameraDisabled(Camera2);
            CameraDisabled(Camera3);
            CameraEnabled(Camera4);
        }
        
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Camera1.enabled = !Camera1.enabled;
            MapCamera.enabled = !MapCamera.enabled;
        }
    }

    // Metoder for å bestemme hvilket kamera som er aktivt
    void CameraEnabled(Camera cam)
    {
        cam.enabled = true;
        cam.GetComponent<AudioListener>().enabled = true;
    }

    void CameraDisabled(Camera cam)
    {
        cam.enabled = false;
        cam.GetComponent<AudioListener>().enabled = false;
    }
}
