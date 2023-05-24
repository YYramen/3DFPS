using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

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

    CinemachinePOV _cinemaChine;

    private void Start()
    {
        _cinemaChine = GetComponent<CinemachinePOV>();

        _sliderVertical = GetComponent<Slider>();
        _sliderHorizontal = GetComponent<Slider>();

        _sliderVertical.maxValue = _maxVerticalSens;
        _sliderVertical.value = _currentVerticalSens;
        _sliderHorizontal.maxValue = _maxHorizontalSens;
        _sliderHorizontal.value = _currentHorizontalSens;
    }

    private void Update()
    {
        _currentVerticalSens = (int)_cinemaChine.m_VerticalAxis.m_SpeedMode;
        _currentHorizontalSens = (int)_cinemaChine.m_HorizontalAxis.m_SpeedMode;

        _sliderVertical.value = _currentVerticalSens;
        _sliderHorizontal.value = _currentHorizontalSens;
    }
}
