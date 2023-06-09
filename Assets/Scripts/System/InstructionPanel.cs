using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        if (controllerNames.Length >= 0 && controllerNames != null)
        {
            _keyMousePanel.SetActive(true);
            _gamePadPanel.SetActive(false);
        }
        else
        {
            _keyMousePanel.SetActive(false);
            _gamePadPanel.SetActive(true);
        }
    }
}
