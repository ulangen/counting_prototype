using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode _pauseKey;
    [SerializeField] UIManager _uiManager;
    [SerializeField] AudioManager _audioManager;

    bool _isGamePaused = true;
    bool _isGameStarted = false;

    public bool isGamePaused => _isGamePaused;

    void Update()
    {
        if (Input.GetKeyDown(_pauseKey) && _isGameStarted)
        {
            PauseGame();
            _uiManager.ShowPauseMenu();
        }
    }

    public void StartGame()
    {
        _isGameStarted = true;
        _uiManager.HideStartMenu();
        ResumeGame();
    }

    public void PauseGame()
    {
        if (!_isGamePaused)
        {
            _isGamePaused = true;
        }
    }

    public void ResumeGame()
    {
        if (_isGamePaused)
        {
            _isGamePaused = false;
        }
    }

    public void GameOver()
    {
        PauseGame();
        _uiManager.ShowGameOverMenu();
        _audioManager.PlayGameOverSound();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
