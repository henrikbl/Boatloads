using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public GameObject menu;
    public GameObject controls;
    private bool isShowing;

    void Awake()
    {
        menu.SetActive(false);
        controls.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            controls.SetActive(false);
            menu.SetActive(isShowing);
        }
	}

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ControlsButtonPressed()
    {
        isShowing = false;
        menu.SetActive(isShowing);
        controls.SetActive(true);
    }
}
