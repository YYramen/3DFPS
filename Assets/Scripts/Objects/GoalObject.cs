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
                AudioManager.AudioManagerInstance.PlaySE(AudioManager.SESoundData.SE.AllClear);

                _gameSceneControll.AllClear();
            }
            else
            {
                Debug.Log("Goal");
                AudioManager.AudioManagerInstance.PlaySE(AudioManager.SESoundData.SE.StageClear);

                _gameSceneControll.StageClear();
            }
        }
    }
}
