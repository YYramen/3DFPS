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

    public bool IsPaused { get => _isPaused; }

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
            _isPaused = !_isPaused;
        }

        if (_isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
        _cvcPov.m_HorizontalAxis.m_MaxSpeed = 1;
        _cvcPov.m_VerticalAxis.m_MaxSpeed = 1;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _isPaused = true;
        _pausePanel.SetActive(true);
        _cvcPov.m_HorizontalAxis.m_MaxSpeed = 0;
        _cvcPov.m_VerticalAxis.m_MaxSpeed = 0;
        Time.timeScale = 0;
    }

    public void GoToSettings()
    {
        _pausePanel.SetActive(false);
        _settingsObj.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnToMainMenu()
    {
        _settingsObj.SetActive(false);
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}

