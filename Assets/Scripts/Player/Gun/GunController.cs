using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    [SerializeField, Tooltip("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Tooltip("Crosshairのイメージ")]
    Image _crosshairImage;

    [SerializeField, Tooltip("Raycastの距離(射程距離)")]
    float _raycastDistance = 100f;

    [SerializeField, Tooltip("BulletのGameObject")]
    GameObject _bulletObj;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            // Raycastが何かに当たった場合、Crosshairの色を赤にする
            _crosshairImage.color = Color.red;

            if (Input.GetMouseButtonDown(0))
            {
                FireBullet();
            }
        }
        else
        {
            // Raycastが何も当たらなかった場合、Crosshairの色を元の色に戻す
            _crosshairImage.color = Color.white;

            if (Input.GetMouseButtonDown(0))
            {
                FireBullet();
            }
        }
    }

    private void FireBullet()
    {
        Instantiate(_bulletObj, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
    }
}
