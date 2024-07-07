using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    ConfigurableJoint _joint;
    [SerializeField]
    float _tensionDuration = 2.0f;
    [SerializeField]
    float _releaseDelay = 0.5f;
    [SerializeField]
    float _repeatDelay = 1.0f;

    private float _tensionTime = 0f;
    private bool _isTensioning = true;
    private Vector3 _initialPosition;

    void Start()
    {
        if (_joint == null)
        {
            _joint = GetComponent<ConfigurableJoint>();
        }

        _initialPosition = _joint.connectedBody.transform.localPosition;
        StartTensioning();
    }

    void Update()
    {
        if (_isTensioning)
        {
            _tensionTime += Time.deltaTime;
            float tensionRatio = Mathf.Clamp01(_tensionTime / _tensionDuration);

            _joint.targetPosition = _initialPosition + new Vector3(-tensionRatio, 0, 0);

            if (_tensionTime >= _tensionDuration)
            {
                _isTensioning = false;
                Invoke("Release", _releaseDelay);
            }
        }

    }

    void Release()
    {
        _joint.targetPosition = _initialPosition;
        Invoke("StartTensioning", _repeatDelay);
    }

    void StartTensioning()
    {
        _tensionTime = 0f;
        _isTensioning = true;
    }
}
