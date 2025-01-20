using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int _numberOfTrafficLanes = 4;
    [SerializeField] float _distanceToFarLane = 20.0f;
    [SerializeField] GameManager _gameManager;
    [SerializeField] AudioManager _audioManager;

    Vector3 _startPosition;
    Vector3 _targetPosition;
    float _distanceBetweenTrafficLanes;
    int _currentTrafficLane = 0;

    void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition;
        _distanceBetweenTrafficLanes = _distanceToFarLane / _numberOfTrafficLanes;
    }

    void Update()
    {
        if (!_gameManager.isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }

            transform.position = Vector3.Lerp(transform.position, _targetPosition, 5.0f * Time.deltaTime);
        }
    }

    void UpdateTargetPosition()
    {
        float xPosition = _startPosition.x + _currentTrafficLane * _distanceBetweenTrafficLanes;
        _targetPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void MoveLeft()
    {
        if (_currentTrafficLane > 0)
        {
            _currentTrafficLane--;
            UpdateTargetPosition();
            _audioManager.PlayTurnSound();
        }
    }

    void MoveRight()
    {
        if (_currentTrafficLane < _numberOfTrafficLanes - 1)
        {
            _currentTrafficLane++;
            UpdateTargetPosition();
            _audioManager.PlayTurnSound();
        }
    }
}
