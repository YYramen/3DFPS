using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    [SerializeField, Header("全ステージクリア判定")]
    bool _allClear = false;

    [SerializeField, Header("GameSceneControllオブジェクト")]
    GameSceneControll _gameSceneControll;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_allClear)
            {
                Debug.Log("AllClear");
                _gameSceneControll.AllClear();
            }
            else
            {
                Debug.Log("Goal");
                _gameSceneControll.StageClear();
            }
        }
    }
}
