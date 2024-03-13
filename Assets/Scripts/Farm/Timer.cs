using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float _maxTime = 5f;
    [SerializeField] bool _singleExecution = false;

    public bool Triggered = false;
    public bool Tick = false;

    private Image _img = null;
    private float _currentTime = Mathf.Infinity;

    public void ResetTimer()
    {
        _currentTime = _maxTime;
    }

    private void Awake()
    {
        Transform timer = gameObject.transform.Find("Timer");
        _img = timer.GetComponent<Image>();
    }

    void Start()
    {
        if(!_singleExecution) Triggered = true;
        _currentTime = _maxTime;
    }

    void Update()
    {
        Tick = false;
        if (Triggered)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _currentTime = _maxTime;
                Tick = true;
                if (_singleExecution) Triggered = false;
            }
            _img.fillAmount = _currentTime / _maxTime;
        }
    }
}
