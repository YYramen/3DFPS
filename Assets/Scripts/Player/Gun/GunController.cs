using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

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

    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnMove;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.action.name != "Fire")
        {
            return;
        }

        FireBullet();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            // Raycastが何かに当たった場合、Crosshairの色を赤にする
            _crosshairImage.color = Color.red;
        }
        else
        {
            // Raycastが何も当たらなかった場合、Crosshairの色を元の色に戻す
            _crosshairImage.color = Color.white;
        }
    }

    private void FireBullet()
    {
        Instantiate(_bulletObj, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
    }
}
