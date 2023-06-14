using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{
    [SerializeField, Header("キーボード＆マウス操作時のPanel")]
    GameObject _keyMousePanel;

    [SerializeField, Header("ゲームパッド操作時のPanel")]
    GameObject _gamePadPanel;

    private void Start()
    {
        _keyMousePanel.SetActive(false);
        _gamePadPanel.SetActive(false);
    }

    private void Update()
    {
        SerchGamePad();
    }

    void SerchGamePad()
    {
        var controllerNames = Input.GetJoystickNames();
        if(controllerNames[0] == "")
        {
            _keyMousePanel.SetActive(true);
            _gamePadPanel.SetActive(false);
        }
        else
        {
            _gamePadPanel.SetActive(true);
            _keyMousePanel.SetActive(false);
        }
    }
}
