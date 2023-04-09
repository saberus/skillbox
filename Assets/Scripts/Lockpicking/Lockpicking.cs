using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lockpicking : MonoBehaviour
{

    [SerializeField] private Text _timerText;
    [SerializeField] private Text _pinText_1;
    [SerializeField] private Text _pinText_2;
    [SerializeField] private Text _pinText_3;
    [SerializeField][Range(1, 150)] private float _initialTime = 50f;

    private List<int> _pinValues = new List<int>() { 5, 5, 5 };
    private float _counterTime;
    private float _elapsedTime = 0f;

    
    private static Dictionary<String, List<int>> s_musicDatabase = new Dictionary<String, List<int>>() { 
        { "Drill_Image", new List<int>(){1,-1,0} },
        { "Hammer_Image",new List<int>(){1,2,-1} },
        { "Picklock_Image", new List<int>(){-1,1,1 } }
    };

    private void Awake()
    {
        UpdatePinsText();
    }


    void Start()
    {
        _counterTime = _initialTime;
        _timerText.text = _counterTime.ToString();
    }
    void Update()
    {
        UpdateTimerValue();
        UpdateTimerText();
    }

    public void ApplyInstrument(Button button)
    {
        var instrumentData = s_musicDatabase.GetValueOrDefault(button.name);
        _pinValues = _pinValues.Select((x, i) => x + instrumentData[i]).ToList();
        UpdatePinsText();

    }

    private void UpdateTimerValue()
    {
        if (_counterTime >= 0)
        {
            _counterTime -= Time.deltaTime;
        }
    }

    private void UpdateTimerText()
    {
        _timerText.text = Mathf.Round(_counterTime).ToString();
    }

    private void UpdatePinsText()
    {
        _pinText_1.text = _pinValues[0].ToString();
        _pinText_2.text = _pinValues[1].ToString();
        _pinText_3.text = _pinValues[2].ToString();
    }
}
