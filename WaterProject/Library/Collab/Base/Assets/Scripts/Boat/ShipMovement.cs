using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{

    private GameObject engineSound, crashSound, sinkSound, controllChanger, GOspeed, GOhp, GOgameOver;
    private bool pauseTimer, hascrash, light, noHp;
    private int[] top5;
    private Rigidbody rb;
    public float Speed, actualSpeed, hp, timeSpent, score, Stabilizer = 0.3f;
    public int points, pointsTotal, intScore;
    public Vector3 dirSpeed;
    public Light boatLight; 

    void Start()
    {
        engineSound = GameObject.Find("MotorAudio");
        crashSound = GameObject.Find("CrashAudio");
        sinkSound = GameObject.Find("SinkAudio");
        controllChanger = GameObject.Find("PlayerChanger");
        GOhp = GameObject.Find("HP");
        GOspeed = GameObject.Find("Speed");
        GOgameOver = GameObject.Find("GameOver");
        boatLight.enabled = false;
        hascrash = false;
        noHp = true;
        Speed = 450;
        points = 0;
        pointsTotal = 9;
        top5 = new int[5];
        pauseTimer = false;
        rb = GetComponent<Rigidbody>();
        hp = 1000; 
    }

    void Update()
    {
        //Frontlight on ship
        if (Input.GetKeyDown(KeyCode.F))
        {
            light = !light;

            if (light)
            {
                boatLight.enabled = true;
            }
            else if (!light)
            {
                boatLight.enabled = false;
            }
        }
    } 

    // Shipscontrols, stabilizer, UI print out of speed and HP
    void FixedUpdate()
    {
        if (hascrash)
        {
            crashSound.GetComponent<AudioSource>().Play();
            hascrash = false;
        }

        if(!pauseTimer)
        {
            timeSpent += Time.deltaTime;
        }

        if(points == pointsTotal)
        {
            pauseTimer = true;
            Finished();
        }

        if (controllChanger.GetComponent<PlayerChange>().playerChanger == 1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rb.AddForce(-transform.forward * v * (Speed * 10000));

            if (dirSpeed.z > 0)
            {
                rb.AddTorque(0f, h * (-Speed * 10000), 0f);
            }
            else
            {
                rb.AddTorque(0f, h * (Speed * 10000), 0f);
            }
        }

        actualSpeed = rb.velocity.magnitude;
        dirSpeed = transform.InverseTransformDirection(rb.velocity);
        GOspeed.GetComponent<Text>().text = "Speed: " + Mathf.Round(actualSpeed);
        GOhp.GetComponent<Text>().text = "HP: " + hp;

        // Enginesound with pitch for acceleration
       engineSound.GetComponent<AudioSource>().pitch = 1 + actualSpeed * .1f;
     
        //If boat has no HP left
        if(hp <= 0)
        {
            if (noHp)
            {
                noHP();
                noHp = false;
            }
        }

        //Stabilizer
        Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;

        if (rb.transform.rotation.z > 5 || rb.transform.rotation.z < -5)
        {
            rb.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Stabilizer*10);
        }
        else
        {
            rb.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Stabilizer);
        }
    }

    // Crash into terrain or piers with high speeds, ship takes damage.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Pier" || col.gameObject.name == "Terrain")
            if (actualSpeed > 16)
            {
                hp -= 250;
                hascrash = true;
            }
            else if (actualSpeed > 11)
            {
                hp -= 150;
                hascrash = true;
            }
    }

    void noHP()
    {
        rb.mass = 40000000;
        sinkSound.GetComponent<AudioSource>().Play();
        GOgameOver.GetComponent<Text>().text = "Game over!";
        StartCoroutine(finished());
    }

    // When the game is done.
    void Finished()
    {
        score = (points * 1000) / (timeSpent / 60);
        intScore = (int)score;
        GOgameOver.GetComponent<Text>().text = "Your score: " + intScore;
        top5[0] = PlayerPrefs.GetInt("top1");
        top5[1] = PlayerPrefs.GetInt("top2");
        top5[2] = PlayerPrefs.GetInt("top3");
        top5[3] = PlayerPrefs.GetInt("top4");
        top5[4] = PlayerPrefs.GetInt("top5");
        for (int i = 0; i <= 4; i++)
        {
            if (intScore >= top5[i])
            {
                int temp = top5[i];
                top5[i] = intScore;
                switch (i)
                {
                    case 0:
                        PlayerPrefs.SetInt("top1", intScore);
                        break;
                    case 1:
                        PlayerPrefs.SetInt("top2", intScore);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("top3", intScore);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("top4", intScore);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("top5", intScore);
                        break;
                }
                intScore = temp;
            }
        }
        StartCoroutine(finished());
    }

    IEnumerator finished()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Highscore");
    }
}
