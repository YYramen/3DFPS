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
    GameObject _allClearPanel;

    [Tooltip("ゲーム内の経過時間")]
    float _gameTime;

    [SerializeField, Header("経過時間を表示するテキスト")]
    Text _gameTimeText;

    [SerializeField, Header("クリア時間を表示するテキスト")]
    Text _clearTimeText;

    [SerializeField, Header("フェードさせるPanel")]
    Image _fadePanel;

    [Tooltip("フェードインの速度")]
    float _fadeSpeed = 0.02f;

    float _colorAlpha = 0f;

    [SerializeField, Header("GamePauseObject")]
    GamePause _gamePause;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        _gameTime += Time.deltaTime;

        GameTimeView();
    }

    void SetUp()
    {
        _gameTime = 0;

        _fadePanel.gameObject.SetActive(false);
        _gameOverPanel.SetActive(false);
        _stageClearPanel.SetActive(false);
        _allClearPanel.SetActive(false);
    }

    void GameTimeView()
    {
        _gameTimeText.text = $"Time: {_gameTime:F3}";
    }

    public void GameOver()
    {
        _gamePause.TogglePause(true);

        _gameOverPanel.SetActive(true);
    }

    public void StageClear()
    {
        _gamePause.TogglePause(true);

        _stageClearPanel.SetActive(true);
        _clearTimeText.text = $"クリアタイム: {_gameTime:F3}";
    }

    public void AllClear()
    {
        _gamePause.TogglePause(true);

        _allClearPanel.SetActive(true);
    }

    /// <summary>
    /// ボタンに使う関数
    /// </summary>
    public void SceneLoad(string sceneName)
    {
        _fadePanel.gameObject.SetActive(true);

        StartCoroutine(FadeOut(sceneName));
    }

    public void SceneRestart()
    {
        SceneReload();
    }

    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator FadeOut(string sceneName)
    {
        Color c = _fadePanel.color;
        c.a = _colorAlpha;
        _fadePanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed ;
            _fadePanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadePanel.color = c;
                ChangeScene(sceneName);
                break;
            }
        }
    }

    IEnumerator FadeOut()
    {
        Color c = _fadePanel.color;
        c.a = _colorAlpha;
        _fadePanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadePanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadePanel.color = c;
                SceneReload();
                break;
            }
        }
    }

    IEnumerator FadeIn()
    {
        Color c = _fadePanel.color;
        c.a = 1;
        _fadePanel.color = c;
        while (true)
        {
            yield return null;
            c.a -= _fadeSpeed;
            _fadePanel.color = c;

            if (c.a <= 0)
            {
                c.a = 0f;
                _fadePanel.color = c;
                SetUp();
                break;
            }
        }
    }
}
