using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmSceneManager : MonoBehaviour
{
    [SerializeField] Timer _harvestTimer;
    [SerializeField] Timer _raidTimer;
    [SerializeField] Timer _consumptionTimer;
    [SerializeField] Timer _hireWorkerTimer;
    [SerializeField] Timer _hireWariorTimer;
    [SerializeField] Text _statValuesText;
    [SerializeField] int _workerHarvestRate = 1;
    [SerializeField] int _workerConsumptionRate = 1;
    [SerializeField] int _wariorConsumptionRate = 2;


    private int _resoursesAmount = 5;
    private int _workersAmount = 1;
    private int _wariorsAmount = 0;


    private void Start()
    {
        UpdateStatValues();
    }

    private void Update()
    {
        if (_harvestTimer.Tick)
        {
            _resoursesAmount += _workersAmount * _workerHarvestRate;
        }

        if (_consumptionTimer.Tick)
        {
            _resoursesAmount -= (_workersAmount + (_wariorsAmount * _wariorConsumptionRate));
        }

        UpdateStatValues();
    }

    private void UpdateStatValues()
    {
        _statValuesText.text = _resoursesAmount.ToString() + "\n\n" + _workersAmount.ToString() + "\n\n" + _wariorsAmount.ToString();
    }

}
