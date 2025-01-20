using UnityEngine;

public class PassingCarController : MonoBehaviour
{
    [SerializeField] float _speed = 50.0f;
    [SerializeField] float _throwForce = 10.0f;
    [SerializeField] float _rotationForce = 10.0f;
    [SerializeField] ParticleSystem _explosionPrefab;

    Rigidbody _rigidbody;
    PlayerController _playerController;
    GameManager _gameManager;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!_gameManager.isGamePaused)
        {
            float relativeSpeed = _speed - _playerController.currentSpeed;
            transform.Translate(Vector3.forward * relativeSpeed * Time.deltaTime, Space.World);

            if (transform.position.z < -30)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ThrowObject();
        }
    }

    public void ThrowObject()
    {
        _speed *= 0.75f;

        Vector3 upwardForce = Vector3.up * _throwForce;

        Vector3 randomTorque = new Vector3(
            Random.Range(-_rotationForce, _rotationForce),
            Random.Range(-_rotationForce, _rotationForce),
            Random.Range(-_rotationForce, _rotationForce)
        );

        _rigidbody.AddForce(upwardForce, ForceMode.Impulse);
        _rigidbody.AddTorque(randomTorque, ForceMode.Impulse);

        _explosionPrefab.Play();
    }
}
