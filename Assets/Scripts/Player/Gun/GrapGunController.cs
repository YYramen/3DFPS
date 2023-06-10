using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GrapGunController : MonoBehaviour
{
    [SerializeField, Header("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Header("Crosshairのイメージ")]
    Image _crosshairImage;

    [SerializeField, Header("Raycastの距離(射程距離)")]
    float _raycastDistance = 100f;

    [SerializeField, Header("GrapBulletのGameObject")]
    GameObject _grapBulletObj;

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
        if (context.action.name != "Fire")
        {
            return;
        }

        if (context.performed)
        {
            FireGrapBullet();
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, _raycastDistance))
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

    private void FireGrapBullet()
    {
        Instantiate(_grapBulletObj, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
    }
}
