using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField, Header("フェードさせるパネル")]
    Image _fadeImg;

    [SerializeField, Header("フェードさせる速さ")]
    float _fadeSpeed;

    public void SceneChange(string sceneName)
    {
        AudioManager.AudioManagerInstance.PlaySE(AudioManager.SESoundData.SE.ClickButton);

        StartCoroutine(FadeOut(sceneName));
    }

    public void Exit()
    {
        AudioManager.AudioManagerInstance.PlaySE(AudioManager.SESoundData.SE.ClickButton);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut(string sceneName)
    {
        Color c = _fadeImg.color;
        c.a = _fadeImg.color.a;
        _fadeImg.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeImg.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeImg.color = c;
                SceneManager.LoadScene(sceneName);
                break;
            }
        }
    }

    IEnumerator FadeOut()
    {
        Color c = _fadeImg.color;
        c.a = _fadeImg.color.a;
        _fadeImg.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeImg.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeImg.color = c;
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
                break;
            }
        }
    }
}
