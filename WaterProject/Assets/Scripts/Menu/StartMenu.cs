using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        #if UNITY_EDITOR //UNITY_EDITOR makes it possible to run code in the editor, no need for it during release
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); //only this is mandatory
        #endif
    }
}
