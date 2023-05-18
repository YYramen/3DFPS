using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField, Tooltip("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Tooltip("Crosshairのイメージ")]
    Image _crosshairImage;

    [SerializeField, Tooltip("Raycastの距離(射程距離)")]
    float _raycastDistance = 100f;

    private void Update()
    {
        // 画面の中央に向けてRaycastを発射
        Ray ray = new Ray(_muzzle.position, Vector2.zero);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            // Raycastが何かに当たった場合、Crosshairの色を赤にする
            _crosshairImage.color = Color.red;
            Debug.Log("射程圏内");
        }
        else
        {
            // Raycastが何も当たらなかった場合、Crosshairの色を元の色に戻す
            _crosshairImage.color = Color.white;
        }
    }
}
