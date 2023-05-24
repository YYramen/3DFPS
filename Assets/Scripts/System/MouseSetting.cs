using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MouseSetting : MonoBehaviour
{
    [SerializeField, Tooltip("マウス感度(縦方向)の最大値")]
    int _maxVerticalSens = 100;

    [Tooltip("現在のマウス感度(縦)")]
    int _currentVerticalSens;

    [SerializeField, Tooltip("縦方向感度のSlider")]
    Slider _sliderVertical;

    [SerializeField, Tooltip("マウス感度(横方向)の最大値")]
    int _maxHorizontalSens = 100;

    [Tooltip("現在のマウス感度(横)")]
    int _currentHorizontalSens;

    [SerializeField, Tooltip("横方向感度のSlider")]
    Slider _sliderHorizontal;

    [SerializeField, Tooltip("変更を加えるInputSystemコンポーネント")]
    InputAction _action;

    private void Start()
    {
        //_sliderVertical.maxValue =  1 % _maxVerticalSens;
        //_sliderHorizontal.maxValue =  1 % _maxHorizontalSens;
    }

    private void Update()
    {
        _sliderVertical.value = _currentVerticalSens;
        _sliderHorizontal.value = _currentHorizontalSens;
        _sliderVertical.maxValue = 1 % _maxVerticalSens;
        _sliderHorizontal.maxValue = 1 % _maxHorizontalSens;

        //_action.ChangeBinding(1)
        //    .WithProcessor($"ScaleVector2(factor = {_currentVerticalSens})");
    }
}
