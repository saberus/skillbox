using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadSelectedScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void LoadCurrentScene()
    {
        LoadSelectedScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

}
