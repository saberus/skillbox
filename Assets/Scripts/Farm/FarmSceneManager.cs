using System;
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
    [SerializeField] Text _gameOverNumberText;
    [SerializeField] int _workerHarvestRate = 0;
    [SerializeField] int _workerConsumptionRate = 0;
    [SerializeField] int _wariorConsumptionRate = 0;
    [SerializeField] int _workerPrice = 0;
    [SerializeField] int _wariorPrice = 0;
    [SerializeField] Button _hireWorkerBtn;
    [SerializeField] Button _hireWariorBtn;
    [SerializeField] GameObject _gameScreen;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] GameObject _winImage = null;
    [SerializeField] GameObject _loseImage = null;
    [SerializeField] GameObject _muteImage = null;
    [SerializeField] GameObject _playImage = null;
    [SerializeField] int _winRaidsAmount = 10;
    [SerializeField] Button _playButton = null;



    private int _resoursesAmount = 5;
    private int _workersAmount = 1;
    private int _wariorsAmount = 0;
    private int _nextRaidSyze = 0;

    private int _raidsSurvived = 0;

    private bool _paused = false;



    public void StartNewGame()
    {
        ResetResourses();
        StopTrimersTriggers();
        ResetTimers();
        if (_paused)
        {
            Time.timeScale = 1f;
        }
    }

    public void ToggleMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if(audioSource.isPlaying)
        {
            audioSource.Pause();
            _muteImage.SetActive(true);
            _playImage.SetActive(false);
        }
        else
        {
            audioSource.Play();
            _muteImage.SetActive(false);
            _playImage.SetActive(true);
        }
    }

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
        if (!_paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        _paused = !_paused;
        _playButton.interactable = _paused;
    }

    private void Awake()
    {
        _playButton.interactable = _paused;
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
        CheckWinCondition();

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
        CheckButtonInteractables();

        UpdateStatValues();
    }
    private void CheckButtonInteractables()
    {
        if (_resoursesAmount < _workerPrice)
        {
            _hireWorkerBtn.interactable = false;
        }
        else if(!_hireWorkerTimer.Triggered)
        {
            _hireWorkerBtn.interactable = true;
        }

        if (_resoursesAmount < _wariorPrice)
        {
            _hireWariorBtn.interactable = false;
        }
        else if(!_hireWariorTimer.Triggered)
        {
            _hireWariorBtn.interactable = true;
        }
    }

    private void ResetResourses()
    {
        _resoursesAmount = 5;
        _workersAmount = 1;
        _wariorsAmount = 0;
        _nextRaidSyze = 0;
        _raidsSurvived = 0;
    }

    private void CheckWinCondition()
    {
        if (_raidsSurvived == _winRaidsAmount)
        {
            StopTrimersTriggers();
            _loseImage.SetActive(false);
            _winImage.SetActive(true);
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
            _gameOverNumberText.text = _raidsSurvived.ToString() + " / " + _winRaidsAmount.ToString();
        }
    }

    private void CheckGameOverConditions()
    {
        if (_workersAmount == 0)
        {
            StopTrimersTriggers();
            _loseImage.SetActive(true);
            _winImage.SetActive(false);
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
            _gameOverNumberText.text = _raidsSurvived.ToString() + " / " + _winRaidsAmount.ToString();
        }
    }

    private void StopTrimersTriggers()
    {
        _harvestTimer.Tick = false;
        _raidTimer.Tick = false;
        _consumptionTimer.Tick = false;
        _hireWorkerTimer.Tick = false;
        _hireWariorTimer.Tick = false;
    }

    private void HireWariorLogic()
    {
        _wariorsAmount++;
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
            + "\n\n" + _nextRaidSyze.ToString()
            + "\n\n\n" + _raidsSurvived.ToString() + " / " + _winRaidsAmount.ToString();
    }

    private void RaidLogic()
    {
        for (int i = _nextRaidSyze; i > 0; i--)
        {
            if (_wariorsAmount > 0)
            {
                _wariorsAmount = Mathf.Max(_wariorsAmount - 1, 0);
                continue;
            }
            else if (_workersAmount > 0)
            {
                _workersAmount = Mathf.Max(_workersAmount - 2, 0);
                continue;
            }
            else
            {
                break;
            }
        }
        _raidsSurvived++;
        _nextRaidSyze++;
    }

    private void ResetTimers()
    {
        _harvestTimer.ResetTimer();
        _raidTimer.ResetTimer();
        _consumptionTimer.ResetTimer();
        _hireWorkerTimer.ResetTimer();
        _hireWariorTimer.ResetTimer();
    }



}
