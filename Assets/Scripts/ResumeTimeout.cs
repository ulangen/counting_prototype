using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResumeTimeout : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] UIManager _uIManager;
    [SerializeField] float _resumeTime = 3.0f;
    [SerializeField] TextMeshProUGUI _timerText;
    float _timer;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (_timer > 0.0f)
        {
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString("0.0");
        }
        else
        {
            OnTimeout();
            ResetTimer();
            gameObject.SetActive(false);
        }
    }

    void OnTimeout()
    {
        _uIManager.ShowHUD();
        _gameManager.ResumeGame();
    }

    void ResetTimer()
    {
        _timer = _resumeTime;
    }
}
