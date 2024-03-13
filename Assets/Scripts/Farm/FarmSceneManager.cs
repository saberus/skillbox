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
    [SerializeField] int _workerPrice = 0;
    [SerializeField] int _wariorPrice = 0;
    [SerializeField] Button _hireWorkerBtn;
    [SerializeField] Button _hireWariorBtn;
    [SerializeField] GameObject _gameScreen;
    [SerializeField] GameObject _gameOverScreen;


    private int _resoursesAmount = 5;
    private int _workersAmount = 1;
    private int _wariorsAmount = 0;
    private int _nextRaidSyze = 1;

    private bool _paused = false;


    public void AddWorker()
    {
        _hireWorkerBtn.interactable = false;
        _hireWorkerTimer.Triggered = true;
        _resoursesAmount -= _workerPrice;
    }

    public void AddWarior()
    {
        _hireWariorBtn.interactable = false;
        _hireWariorTimer.Triggered = true;
        _resoursesAmount -= _wariorPrice;
    }

    public void PauseGame()
    {
        if (_paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        _paused = !_paused;
    }

    private void Start()
    {
        UpdateStatValues();
    }

    private void Update()
    {
        if (_raidTimer.Tick)
        {
            RaidLogic();
        }

        CheckGameOverConditions();

        if (_harvestTimer.Tick)
        {
            HarvestLogic();
        }

        if (_consumptionTimer.Tick)
        {
            ConsumptionLogic();
        }

        if (_hireWorkerTimer.Tick)
        {
            HireWorkerLogic();
        }

        if (_hireWariorTimer.Tick)
        {
            HireWariorLogic();
        }

        UpdateStatValues();
    }

    private void HireWariorLogic()
    {
        _wariorsAmount += 1;
        _hireWariorBtn.interactable = true;
    }

    private void HireWorkerLogic()
    {
        _workersAmount += 1;
        _hireWorkerBtn.interactable = true;
    }

    private void ConsumptionLogic()
    {
        int resoursesToConsume = (_workersAmount * _workerConsumptionRate) + (_wariorsAmount * _wariorConsumptionRate);
        int resousesTotal = _resoursesAmount - resoursesToConsume;
        _resoursesAmount = Mathf.Max(resousesTotal, 0);
    }

    private void HarvestLogic()
    {
        _resoursesAmount += _workersAmount * _workerHarvestRate;
    }

    private void UpdateStatValues()
    {
        _statValuesText.text = _resoursesAmount.ToString() 
            + "\n\n" + _workersAmount.ToString()
            + "\n\n" + _wariorsAmount.ToString()
            + "\n\n" + _nextRaidSyze.ToString();
    }

    private void RaidLogic()
    {
        for (int i = _nextRaidSyze; i > 0; i--)
        {
            if (_wariorsAmount > 0)
            {
                _workersAmount = Mathf.Max(_wariorsAmount--, 0);
            }
            else if (_workersAmount > 0)
            {
                _workersAmount = Mathf.Max(_workersAmount - 2, 0);
            }
            else
            {
                break;
            }
        }
        _nextRaidSyze++;
    }

    private void CheckGameOverConditions()
    {
        if (_workersAmount == 0)
        {
            _gameOverScreen.SetActive(true);
            _gameScreen.SetActive(false);
            //Time.timeScale = 0;
        }
    }



}
