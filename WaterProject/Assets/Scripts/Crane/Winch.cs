using UnityEngine;

public class Winch : MonoBehaviour
{

    private GameObject winchSound, hookSound, controllChanger;
    public int craneID;
    LineRenderer lineRenderer;
    public GameObject anchor;
    public float raiseSpeed, mass = 25000;
    public bool isLifting = false;

	void Start ()
    {
        winchSound = GameObject.Find("WinchAudio");
        hookSound = GameObject.Find("HookAudio");
        controllChanger = GameObject.Find("PlayerChanger");
        lineRenderer = GetComponent<LineRenderer>();
	}
	
    // Controls for lifting and dropping the "hook", also to hook on a container
	void Update ()
    {
        if (controllChanger.GetComponent<PlayerChange>().playerChanger == craneID)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, anchor.transform.position);

            if(Input.GetKey(KeyCode.Z))
            {
                winchSound.GetComponent<AudioSource>().Play();
                GetComponent<SpringJoint>().spring = Mathf.Clamp(GetComponent<SpringJoint>().spring + (-raiseSpeed * 100), 50, 1800);
            }

            else if(Input.GetKey(KeyCode.C))
            {
                winchSound.GetComponent<AudioSource>().Play();
                GetComponent<SpringJoint>().spring = Mathf.Clamp(GetComponent<SpringJoint>().spring + (raiseSpeed * 5), 50, 1800);
            }

            else if(!Input.GetKey(KeyCode.Z))
            {
                winchSound.GetComponent<AudioSource>().Stop();
            }

            else if(!Input.GetKey(KeyCode.C))
            {
                winchSound.GetComponent<AudioSource>().Stop();
            }

            // hook on and off a container
            if (Input.GetKeyDown("space"))
            {
                Collider[] hit = Physics.OverlapSphere(transform.position, 0.3f);
                foreach (Collider e in hit)
                {
                    if (e.tag == "container" && isLifting == false)
                    {
                        hookSound.GetComponent<AudioSource>().Play();
                        e.transform.parent = gameObject.transform;
                        Destroy(e.GetComponent<Rigidbody>());
                        isLifting = true;
                        break;
                    }
                    if (e.tag == "container" && isLifting == true)
                    {
                        hookSound.GetComponent<AudioSource>().Play();
                        e.transform.parent = null;
                        e.gameObject.AddComponent<Rigidbody>();
                        e.GetComponent<Rigidbody>().mass = mass;
                        isLifting = false;
                        break;
                    }
                }
            }
        }
	}
}
