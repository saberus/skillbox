using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float _maxTime = 5f;

    public bool Tick = false;

    private Image _img = null;
    private float _currentTime = Mathf.Infinity;

    private void Awake()
    {
        //find image in childrens
        Transform timer = gameObject.transform.Find("Timer");
        _img = timer.GetComponent<Image>();
    }

    void Start()
    {
        _currentTime = _maxTime;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        Tick = false;
        if (_currentTime <= 0)
        {
            Tick = true;
        }
        _img.fillAmount = _currentTime / _maxTime;
    }
}
