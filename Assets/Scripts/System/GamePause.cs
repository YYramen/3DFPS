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

    [Tooltip("ポーズ画面のインスタンス")]
    GameObject _pausePanelInstance;

    public bool IsPaused { get => _isPaused;}

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (_pausePanelInstance == null)
            {
                _pausePanelInstance = GameObject.Instantiate(_pausePanel, _pausePanelPos) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(_pausePanelInstance);
                Time.timeScale = 1f;
            }
        }
    }

    public void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = true;
        _pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0;
        Cursor.visible = false;
        _pausePanel.SetActive(true);
    }
}

