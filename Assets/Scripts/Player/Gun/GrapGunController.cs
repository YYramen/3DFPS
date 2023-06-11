using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GrapGunController : MonoBehaviour
{
    [SerializeField, Header("MuzzleÇÃà íu")]
    Transform _muzzle;

    [SerializeField, Header("GrapBulletÇÃGameObject")]
    GameObject _grapBulletObj;

    [SerializeField, Header("GrapGunÇÃç≈ëÂéÀíˆ")]
    float _grapGunRange = 50f;

    [SerializeField, Header("GrapGunÇÃà¯Ç¡í£ÇÈóÕ")]
    float _grapPower;

    Rigidbody _rb;

    [Header("éQè∆óp")]
    [SerializeField] PlayerInput _playerInput;

    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnHold;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnHold;
    }

    public void OnHold(InputAction.CallbackContext context)
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

    private void FireGrapBullet()
    {
        Debug.Log("Grapgun fired");
        Instantiate(_grapBulletObj, transform.position,
            Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _grapGunRange, LayerMask.GetMask("GrapObject")))
        {
            var dir = (hit.transform.position - this.transform.position).normalized; ;
            _rb.AddForce(dir * _grapPower, ForceMode.Impulse);

            Debug.Log("Grapê¨å˜");
        }
        else
        {
            return;
        }
    }
}
