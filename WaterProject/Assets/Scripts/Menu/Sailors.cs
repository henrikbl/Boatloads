using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sailors : MonoBehaviour {

    public GameObject prefabSailor;
    public Vector3 startPosition;
    private float InstTimer = 2f;

    void Start ()
    {
        startPosition = new Vector3(-14f, 62f, 1010.6f);
    }
	// Update is called once per frame
	void Update () {
        spawnSailor();
	}

    void spawnSailor()
    {
        InstTimer -= Time.deltaTime;
        if(InstTimer <= 0)
        {
            Instantiate(prefabSailor, startPosition, Quaternion.identity);
            InstTimer = 2f;
            gameObject.GetComponent<AudioSource>().Play();
        }
       
    }
}
