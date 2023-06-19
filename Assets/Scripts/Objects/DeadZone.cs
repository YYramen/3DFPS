using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField, Header("GameSceneControllオブジェクト")]
    GameSceneControll _gameSceneControll;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver");

            _gameSceneControll.GameOver();
        }
    }
}
