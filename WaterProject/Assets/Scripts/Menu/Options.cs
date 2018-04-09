using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    public Slider VolumeSlider;
	// Use this for initialization
	void Start () {
        VolumeSlider.value = AudioListener.volume;
	}

    // Save volume setting and return to main menu
    public void LoadByIndex(int sceneIndex)
    {
        AudioListener.volume = VolumeSlider.value;
        SceneManager.LoadScene(sceneIndex);
    }
}
