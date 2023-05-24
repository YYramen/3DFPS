using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField, Tooltip("ポーズ中に表示するPanel")]
    GameObject _pausePanel;

    [SerializeField, Tooltip("ポーズ中に非表示にするCrosshair")]
    Image _crosshairImage;

    [SerializeField, Tooltip("ポーズパネルを配置する場所")]
    Transform _pausePanelPos;

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
        }

        if (_isPaused == true)
        {
            PauseGame();
        }
        else if (_isPaused == false)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}

