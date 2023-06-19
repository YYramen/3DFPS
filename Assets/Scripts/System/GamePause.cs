using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField, Header("ポーズ中に表示するPanel")]
    GameObject _pausePanel;

    [SerializeField, Header("Settingsオブジェクト")]
    GameObject _settingsObj;

    [SerializeField, Header("cvcオブジェクト")]
    GameObject _cvcObj;

    [SerializeField, Header("ポーズ中に非表示にするCrosshair")]
    Image _crosshairImage;

    [SerializeField, Header("パネルを配置する場所")]
    Transform _panelPos;

    [Tooltip("ポーズフラグ")]
    bool _isPaused = false;

    CinemachinePOV _cvcPov;

    public bool IsPaused { get => _isPaused; set => _isPaused = value; }

    private void Start()
    {
        if (_isPaused == true)
        {
            _isPaused = false;
        }

        _cvcPov = _cvcObj.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }

        if (_isPaused)
        {
            _cvcPov.m_HorizontalAxis.m_MaxSpeed = 0;
            _cvcPov.m_VerticalAxis.m_MaxSpeed = 0;
            Time.timeScale = 0;
        }
        else
        {
            _cvcPov.m_HorizontalAxis.m_MaxSpeed = 1;
            _cvcPov.m_VerticalAxis.m_MaxSpeed = 1;
            Time.timeScale = 1;
        }
    }

    public void TogglePause(bool value)
    {
        _isPaused = value;
    }

    public void ResumeGame()
    {
        TogglePause(false);
        _pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        TogglePause(true);
        _pausePanel.SetActive(true);
    }

    public void GoToSettings()
    {
        _pausePanel.SetActive(false);
        _settingsObj.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        _settingsObj.SetActive(false);
        _pausePanel.SetActive(true);
    }
}

