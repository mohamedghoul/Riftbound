using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to switch to any named scene.
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to exit to the desktop.
    // This function will not work in the Unity Editor. A build must be created to test this functionality.
    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
