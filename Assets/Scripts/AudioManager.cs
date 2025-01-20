using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _engineSound;
    [SerializeField] AudioSource _crashSound;
    [SerializeField] AudioSource _turnSound;
    [SerializeField] AudioSource _pickupSound;
    [SerializeField] AudioSource _gameOverSound;
    [SerializeField] PlayerController _player;

    void Update()
    {
        _engineSound.pitch = 0.3f + _player.GetAcceleration();
    }

    public void PlayCrushSound()
    {
        _crashSound.pitch = Random.Range(0.5f, 1.5f);
        _crashSound.Play();
    }

    public void PlayTurnSound()
    {
        _turnSound.pitch = Random.Range(0.9f, 1.1f);
        _turnSound.Play();
    }

    public void PlayPickupSound()
    {
        _pickupSound.pitch = Random.Range(0.9f, 1.1f);
        _pickupSound.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOverSound.Play();
    }
}
