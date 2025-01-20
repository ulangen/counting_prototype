using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] UIManager _uIManager;

    public void OnResume()
    {
        _uIManager.ShowResumeTimeout();
        gameObject.SetActive(false);
    }
}
