using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject _stickPrefab = null;
    [SerializeField] GameObject _stickHandle = null;

    private bool _isMoving = false;
    private bool _isStickVisible = false;

    private Vector3 _destination;

    //private void Awake()
    //{
    //    _stickPrefab.SetActive(_isStickVisible);
    //}

    private void Update()
    {
        if (!_isMoving) return;
        MoveRunner();
    }
    public void MoveRunner()
    {
        if (_destination == null) return;
        transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * _speed);
    }

    public Vector3 GetDestination()
    {
        return _destination;
    }

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        transform.LookAt(destination);
    }

    public void ToggleMove()
    {
        _isStickVisible = !_isStickVisible;
        //_stickPrefab.SetActive(_isStickVisible);
        _isMoving = !_isMoving;
    }

    public void SetStick(GameObject stick)
    {
        _stickPrefab = stick;
        _stickPrefab.transform.SetParent(transform);
        _stickPrefab.transform.position = _stickHandle.transform.position;
        _stickPrefab.transform.rotation = _stickHandle.transform.rotation;
    }

}
