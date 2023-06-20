using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeText : MonoBehaviour
{
    [SerializeField, Header("テキストの位置")]
    Transform _textPos;

    [SerializeField, Header("揺らす強さ")]
    float _shakePower;

    Vector3 _textInitPos;

    private void Start()
    {
        _textInitPos = _textPos.position;
    }


    private void Update()
    {
        // ランダムに揺らす
        _textPos.position = _textInitPos + Random.insideUnitSphere * _shakePower;
    }
}
