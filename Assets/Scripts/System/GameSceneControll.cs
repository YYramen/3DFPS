using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneControll : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバー時のUI")]
    GameObject _gameOverPanel;

    [SerializeField, Header("ステージクリア時のUI")]
    GameObject _stageClearPanel;

    [SerializeField, Header("全ステージクリア時のUI")]
    GameObject _allClearUI;

    [SerializeField, Header("チェックポイントの位置")]
    Transform _checkPointPosition;

    [Tooltip("ゲーム内の経過時間")]
    float _gameTime;

    [SerializeField, Header("経過時間を表示するテキスト")]
    Text _gameTimeText;

    GamePause _gamePause;

    private void Start()
    {
        
    }

    void SetUp()
    {
        _gameTime = 0;
        _gamePause = GetComponent<GamePause>();

        _gameOverPanel.SetActive(false);
        _stageClearPanel.SetActive(false);
        _allClearUI.SetActive(false);
    }

    void GameTimeView()
    {
        _gameTimeText.text = _gameTime.ToString("F3");
    }

    void GameOver()
    {
        
    }

    void StageClear()
    {

    }

    void AllClear()
    {

    }

    /// <summary>
    /// ボタンに使う関数
    /// </summary>
    public void ReturnToTitle()
    {

    }

    public void StageRestart()
    {

    }
}
