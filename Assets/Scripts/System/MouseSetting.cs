using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class MouseSetting : MonoBehaviour
{
    [SerializeField, Tooltip("マウス感度(縦方向)の最大値")]
    float _maxVerticalSens = 1;

    [SerializeField, Tooltip("マウス感度(縦方向)の最小値")]
    float _minVerticalSens = 0.01f;

    [Tooltip("現在のマウス感度(縦)")]
    float _currentVerticalSens;

    [SerializeField, Tooltip("縦方向感度のSlider")]
    Slider _sliderVertical;

    [SerializeField, Tooltip("マウス感度(横方向)の最大値")]
    float _maxHorizontalSens = 1;

    [SerializeField, Tooltip("マウス感度(横方向)の最小値")]
    float _minHorizontalSens = 0.01f;

    [Tooltip("現在のマウス感度(横)")]
    float _currentHorizontalSens;

    [SerializeField, Tooltip("横方向感度のSlider")]
    Slider _sliderHorizontal;

    [SerializeField, Header("cvcが入っているオブジェクト")]
    GameObject _cvcObj;

    CinemachinePOV _cpov;

    private void Start()
    {
        _cpov = _cvcObj.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();

        _sliderHorizontal.maxValue = _maxHorizontalSens;
        _sliderHorizontal.minValue = _minHorizontalSens;
        _sliderVertical.maxValue = _maxVerticalSens;
        _sliderVertical.minValue = _minVerticalSens;

        _sliderHorizontal.value = _minHorizontalSens;
        _sliderVertical.value = _minVerticalSens;
    }

    public void SetSens()
    {
        _currentHorizontalSens = _sliderHorizontal.value;
        _currentVerticalSens = _sliderVertical.value;

        _cpov.m_HorizontalAxis.m_MaxSpeed = _currentHorizontalSens;
        _cpov.m_VerticalAxis.m_MaxSpeed = _currentVerticalSens;
    }
}
