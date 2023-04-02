using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject calculator;
    [SerializeField] private GameObject comparator;
    private GameObject currentMode;

    void Start()
    {
        if(calculator != null)
        {
            calculator.SetActive(true);
            currentMode = calculator;
        }
        if(comparator != null)
        {
            comparator.SetActive(false);
        }
    }

    public void ChangeMode(GameObject mode)
    {
        if(currentMode != null)
        {
            currentMode.SetActive(false);
            mode.SetActive(true);
            currentMode = mode;
        }
    }
    
}
