using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SceneManager : MonoBehaviour
{
    public void onScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
