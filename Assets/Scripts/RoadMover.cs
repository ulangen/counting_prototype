using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] float _repeatLengthFactor = 0.5f;
    [SerializeField] GameManager _gameManager;
    [SerializeField] PlayerController _playerController;

    float _repeatLength;
    Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        _repeatLength = GetComponent<BoxCollider>().bounds.size.z * _repeatLengthFactor;
    }

    void Update()
    {
        if (!_gameManager.isGamePaused)
        {
            transform.Translate(Vector3.back * _playerController.currentSpeed * Time.deltaTime);
            if (transform.position.z < _startPosition.z - _repeatLength)
            {
                transform.position = _startPosition;
            }
        }
    }
}
