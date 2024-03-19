using UnityEngine;

public class Relay : MonoBehaviour
{
    [SerializeField] GameObject _targetGameObject = null;
    [SerializeField] GameObject _runnerGameObject = null;
    [SerializeField] GameObject _stickGameObject = null;
    [SerializeField] int _listSize = 0;
    [SerializeField] float _passDistance = 2f;

    GameObject[] _runners = null;
    GameObject[] _targets = null;
    Runner _currentRunner = null;
    Vector3[] _targetPositions;
    int _locationIndex = 0;
    bool _isForward = false;
    bool _isRun = false;
    bool _isRunnerGame = false;

    private void Update()
    {
        if (_isRun)
        {
            if (_targetPositions.Length <= 0) return;
            Run();
        }
    }

    public void StartRelay()
    {
        _isRunnerGame = true;
        Initialize();
        _isRun = true;
    }

    public void StartRunner()
    {
        _isRunnerGame = false;
        Initialize();
        _isRun = true;
    }

    public void StopGame()
    {
        _isRun = false;
        for(int i = 0; i < _listSize; i++)
        {
            Destroy(_targets[i]);
            Destroy(_runners[i]);
        }
    }

    private void Run()
    {
        Vector3 currentTarget = _currentRunner.GetDestination();
        if (Vector3.Distance(_currentRunner.transform.position, currentTarget) <= _passDistance)
        {
            print("Here 1");
            if(_isRunnerGame)
            {
                print("Here 2");
                _currentRunner.ToggleMove(); //Relay
            }
            
            _locationIndex = GetNextIndex();

            if (_isRunnerGame)
            {
                _currentRunner = _runners[_locationIndex].GetComponent<Runner>();//Relay
            }
            
            _currentRunner.SetDestination(GetNextPosition(_locationIndex));
            if (_isRunnerGame)
            {
                _currentRunner.ToggleMove();//Ralay
            }
            
            if (IsSwitchDirection(currentTarget))
            {
                _isForward = !_isForward;
            } 
        }
    }

    private int GetNextIndex()
    {
        return _isForward ? _locationIndex + 1 : _locationIndex - 1;
    }

    private Vector3 GetNextPosition(int currentIndex)
    {
        if (_targetPositions.Length > currentIndex)
        {
            return _targetPositions[currentIndex];
        }
        else
        {
            return _targetPositions[0];
        }
    }

    private bool IsSwitchDirection(Vector3 currentTarget)
    {
        if(_locationIndex == _targetPositions.Length - 1 || _locationIndex == 0)
        {
            return true;
        }
        return false;
    }

    private void PlaceTargets()
    {
        for(int i = 0; i < _listSize; i++)
        {
            _targetPositions[i].Set(10*i,0,10*i); //ignore y
            _targets[i] = Instantiate(_targetGameObject, _targetPositions[i], Quaternion.identity);
            if (_isRunnerGame)
            {
                _runners[i] = Instantiate(_runnerGameObject, _targetPositions[i], Quaternion.identity);//relay
            }
        }
        if (!_isRunnerGame)
        {
            _runners[0] = Instantiate(_runnerGameObject, _targetPositions[0], Quaternion.identity);
        }
    }

    private void Initialize()
    {
        _targetPositions = new Vector3[_listSize];
        _runners = new GameObject[_listSize];
        _targets = new GameObject[_listSize];
        PlaceTargets();
        _isForward = true;
        _currentRunner = _runners[0].GetComponent<Runner>();
        _currentRunner.SetStick(Instantiate(_stickGameObject, _currentRunner.transform.position, Quaternion.identity));
        _currentRunner.SetDestination(GetNextPosition(_locationIndex));
        _currentRunner.ToggleMove();
    }
}
