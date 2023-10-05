using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int maxScene;
    public int actualScene;

    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
        maxScene = SceneManager.sceneCountInBuildSettings - 1;
    }

    public void PreviousScene()
    {
        if (actualScene < 0)
        {
            actualScene = maxScene;
            SceneManager.LoadScene(actualScene);
        }
        else
        {
            actualScene--;
            SceneManager.LoadScene(actualScene);
        }
    }

    public void NextScene()
    {
        if (actualScene > maxScene)
        {
            actualScene = 0;
            SceneManager.LoadScene(actualScene);
        }
        else
        {
            actualScene++;
            SceneManager.LoadScene(actualScene);
        }
    }

}
