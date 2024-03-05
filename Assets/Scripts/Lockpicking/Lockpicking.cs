using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Lockpicking : MonoBehaviour
{

    [SerializeField] private Text _timerText;
    [SerializeField] private Text _pinText_1;
    [SerializeField] private Text _pinText_2;
    [SerializeField] private Text _pinText_3;
    [SerializeField] private GameObject _gameOverImage;
    [SerializeField][Range(1, 150)] private float _initialTime = 50f;

    int _minPinValue = -10;
    int _maxPinValue = 10;

    private List<int> _pinValues = new List<int>() { 5, 5, 5 };
    private List<int> _winConditionPinValues = new List<int>() { 6, 4, 5 };
    private float _counterTime;

    
    private static Dictionary<String, List<int>> s_instrumentDatabase = new Dictionary<String, List<int>>() { 
        { "Drill_Image", new List<int>(){1,-1,0} },
        { "Hammer_Image",new List<int>(){1,2,-1} },
        { "Picklock_Image", new List<int>(){-1,1,1 } }
    };

    private void Awake()
    {
        _gameOverImage.SetActive(false);
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
        var instrumentData = s_instrumentDatabase.GetValueOrDefault(button.name);
        for(int i = 0; i < _pinValues.Count(); i++)
        {
            int newPinValue = _pinValues[i] + instrumentData[i];
            if (newPinValue <= _maxPinValue && newPinValue >= _minPinValue)
            {
                _pinValues[i] = newPinValue;
            }
        }
        UpdatePinsText();
        if (IsWinCondition())
        {
            SetEndGameScrenValues("win");
        }
    }

    public void StartNewGame()
    {
        _counterTime = _initialTime;
        _gameOverImage.SetActive(false);
    }

    private bool IsWinCondition()
    {
        bool validSoFar = true;
        for (int i = 0; i < _pinValues.Count; i++)
        {
            if (_pinValues[i] != _winConditionPinValues[i]) validSoFar = false;
        }
        return validSoFar;
    }

    private void UpdateTimerValue()
    {
        if (_counterTime >= 0)
        {
            _counterTime -= Time.deltaTime;
        }
        else
        {
            SetEndGameScrenValues("game_over");  
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

    private void SetEndGameScrenValues(string type)
    {
        if(type == "win")
        {
            _gameOverImage.GetComponent<Image>().color = new Color32(91, 159, 117, 183);
        }
        else
        {
            _gameOverImage.GetComponent<Image>().color = new Color32(159, 91, 91, 183);
        }
        _gameOverImage.SetActive(true);
    }
}
