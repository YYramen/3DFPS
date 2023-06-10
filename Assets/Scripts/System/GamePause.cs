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

    [SerializeField, Header("ポーズ中に非表示にするCrosshair")]
    Image _crosshairImage;

    [SerializeField, Header("パネルを配置する場所")]
    Transform _panelPos;

    [Tooltip("ポーズフラグ")]
    bool _isPaused = false;

    public bool IsPaused { get => _isPaused; }

    private void Start()
    {
        if(_isPaused == true)
        {
            _isPaused = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            _isPaused = !_isPaused;
            if(_isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        //Cursor.visible = _isPaused;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
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

