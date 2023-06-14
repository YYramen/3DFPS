using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;

    [SerializeField, Header("GameOver時に表示するオブジェクト")]
    GameObject _gameOverObj;

    [SerializeField, Header("StageClear時に表示させるオブジェクト")]
    GameObject _stageClearObj;

    [SerializeField, Header("GameClear時に表示させるオブジェクト")]
    GameObject _gameClearObj;

    private void Awake()
    {
        if(GameManagerInstance == null)
        {
            GameManagerInstance = this;
            Debug.Log(GameManagerInstance.gameObject.name);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(GameManagerInstance == this)
        {
            GameManagerInstance = null;
        }
    }

    void StageClear()
    {

    }

    void GameOver()
    {

    }

    void GameClear()
    {

    }
}
