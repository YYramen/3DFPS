using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PullGunController : MonoBehaviour
{
    [SerializeField, Header("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Header("PullBulletのGameObject")]
    GameObject _pullBulletObj;

    [SerializeField, Header("PullGunの最大射程")]
    float _pullGunRange = 50f;

    [SerializeField, Header("PullGunの引っ張る力")]
    float _pullPower = 0f;

    [SerializeField, Header("ゴッドモード（PullGunの射程無限）")]
    bool _godMode = false;

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
        if (_godMode)
        {
            _pullGunRange += 100f;
        }
        Instantiate(_pullBulletObj, transform.position,
            Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _pullGunRange, LayerMask.GetMask("PullObject")))
        {
            Pull(hit);
        }
        else
        {
            return;
        }
    }

    void Pull(RaycastHit target)
    {
        Vector3 dir = transform.position - target.transform.position;
        target.rigidbody.AddForce(dir * _pullPower, ForceMode.Impulse);

        Debug.Log("Pull 成功");
    }
}
