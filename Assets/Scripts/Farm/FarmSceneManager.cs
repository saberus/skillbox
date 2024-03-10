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
    [SerializeField] int _workerHarvestRate = 0;
    [SerializeField] int _workerConsumptionRate = 0;
    [SerializeField] int _wariorConsumptionRate = 0;
    [SerializeField] Button _hireWorkerBtn;
    [SerializeField] Button _hireWariorBtn;


    private int _resoursesAmount = 5;
    private int _workersAmount = 1;
    private int _wariorsAmount = 0;


    public void AddWorker()
    {
        _hireWorkerBtn.interactable = false;
        _hireWorkerTimer.Triggered = true;
    }

    public void AddWarior()
    {
        _hireWariorBtn.interactable = false;
        _hireWariorTimer.Triggered = true;
    }

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

        if (_hireWorkerTimer.Tick)
        {
            _workersAmount += 1;
        }

        if (_hireWariorTimer.Tick)
        {
            _wariorsAmount += 1;
        }

        UpdateStatValues();
    }

    private void UpdateStatValues()
    {
        _statValuesText.text = _resoursesAmount.ToString() + "\n\n" + _workersAmount.ToString() + "\n\n" + _wariorsAmount.ToString();
    }

}
