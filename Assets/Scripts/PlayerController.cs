using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float _minSpeed = 50.0f;
    [SerializeField] float _maxSpeed = 100.0f;
    [SerializeField] float _accelerationTime = 10.0f;

    [Header("Fuel")]
    [SerializeField] float _fuelReserve = 100.0f;
    [SerializeField] float _fuelConsumption = 5.0f;
    [SerializeField] float _currentFuelLevel;

    [Header("Managers")]
    [SerializeField] GameManager _gameManager;
    [SerializeField] AudioManager _soundManager;
    [SerializeField] UIManager _uiManager;

    float _currentSpeed = 0.0f;
    float _accelerationSpeed = 0.0f;
    float _traveledDistance = 0.0f;

    public float currentSpeed => _currentSpeed;
    public float traveledDistance => _traveledDistance;

    void Start()
    {
        _currentSpeed = _minSpeed;
        _accelerationSpeed = (_maxSpeed - _minSpeed) / _accelerationTime;
        _currentFuelLevel = _fuelReserve;
    }

    void Update()
    {
        if (!_gameManager.isGamePaused)
        {
            UpdateSpeed();
            UpdateTraveledDistance();
            UpdateFuelLevel();

            if (_currentFuelLevel <= 0)
            {
                _uiManager.SetScore(_traveledDistance / 1000.0f);
                _gameManager.GameOver();
            }
        }
    }

    void UpdateSpeed()
    {
        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += _accelerationSpeed * Time.deltaTime;
        }
        else
        {
            _currentSpeed = _maxSpeed;
        }
        _uiManager.SetPlayerSpeed(_currentSpeed);
    }

    void UpdateTraveledDistance()
    {
        _traveledDistance += _currentSpeed * Time.deltaTime;
        _uiManager.SetTraveledDistance(_traveledDistance);
    }

    void UpdateFuelLevel()
    {
        _currentFuelLevel -= _fuelConsumption * Time.deltaTime;
        _uiManager.SetFuelConsumption(_currentFuelLevel / _fuelReserve);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            HandleCollision(other);
        }
        else if (other.gameObject.CompareTag("Collectable"))
        {
            HandleFuelPickup(other.gameObject);
        }
    }

    void HandleCollision(Collider other)
    {
        _currentSpeed = _minSpeed;
        _soundManager.PlayCrushSound();
    }

    void HandleFuelPickup(GameObject fuelGameObject)
    {
        fuelGameObject.GetComponent<MovingObject>().PickUp();
        _soundManager.PlayPickupSound();
        _currentFuelLevel = _fuelReserve;
    }

    public float GetAcceleration()
    {
        return 1.0f / _maxSpeed * _currentSpeed;
    }
}
