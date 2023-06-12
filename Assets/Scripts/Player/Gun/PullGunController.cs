using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PullGunController : MonoBehaviour
{
    [SerializeField, Header("MuzzleÇÃà íu")]
    Transform _muzzle;

    [SerializeField, Header("PullBulletÇÃGameObject")]
    GameObject _pullBulletObj;

    [SerializeField, Header("PullGunÇÃç≈ëÂéÀíˆ")]
    float _pullGunRange = 50f;

    [SerializeField, Header("PullGunÇÃà¯Ç¡í£ÇÈóÕ")]
    float _pullPower = 0f;

    [Header("éQè∆óp")]
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
        if (context.action.name != "AltFire")
        {
            return;
        }

        if (context.performed)
        {
            FirePullBullet();
        }
    }

    private void FirePullBullet()
    {
        Debug.Log("Pullgun fired");
        Instantiate(_pullBulletObj, transform.position,
            Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _pullGunRange, LayerMask.GetMask("PullObject")))
        {
            Pull();
        }
        else
        {
            return;
        }
    }

    void Pull()
    {
        Debug.Log("Pull ê¨å˜");
    }
}
