using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TraveledDistance;
    [SerializeField] TextMeshProUGUI m_PlayerSpeed;
    [SerializeField] Slider m_FuelConsumption;
    [SerializeField] GameObject m_StartMenu;
    [SerializeField] GameObject m_hUD;
    [SerializeField] ResumeTimeout m_ResumeTimeout;
    [SerializeField] PauseMenu m_PauseMenu;
    [SerializeField] GameObject m_GameOverMenu;
    [SerializeField] TextMeshProUGUI m_ScoreText;

    public void SetTraveledDistance(float distance)
    {
        float distanceInKm = Mathf.Round(distance / 100.0f) / 10.0f;
        m_TraveledDistance.text = $"{distanceInKm}";
    }

    public void SetPlayerSpeed(float speed)
    {
        float roundedSpeed = Mathf.Round(speed);
        m_PlayerSpeed.text = $"{roundedSpeed}";
    }

    public void SetFuelConsumption(float consumption)
    {
        m_FuelConsumption.value = consumption;
    }

    void HideAll()
    {
        m_StartMenu.SetActive(false);
        m_PauseMenu.gameObject.SetActive(false);
        m_hUD.SetActive(false);
    }

    public void ShowHUD()
    {
        HideAll();
        m_hUD.SetActive(true);
    }

    public void HideStartMenu()
    {
        m_StartMenu.SetActive(false);
        ShowHUD();
    }

    public void ShowResumeTimeout()
    {
        HideAll();
        m_ResumeTimeout.gameObject.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        HideAll();
        m_PauseMenu.gameObject.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        HideAll();
        m_GameOverMenu.SetActive(true);
    }

    public void SetScore(float scoreInKm)
    {
        m_ScoreText.text = $"You have traveled {scoreInKm.ToString("0.0")} km";
    }
}
