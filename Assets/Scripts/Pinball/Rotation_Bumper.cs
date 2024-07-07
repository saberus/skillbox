using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Bumper : MonoBehaviour
{
    [SerializeField]
    bool _isClockwise = true;
    [SerializeField]
    float _speedMultiplyer = 200f;

    private int _rotationDerection = 1;
    // Update is called once per frame
    private void Start()
    {
        if (!_isClockwise)
        {
            _rotationDerection = -1;
        }
    }
    void Update()
    {
        transform.transform.Rotate(0, _speedMultiplyer  * _rotationDerection * Time.deltaTime, 0);
    }

}
