using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenes : MonoBehaviour
{
    public void LoadNextScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGame(int index)
    {
        Application.Quit(index);
    }
}
