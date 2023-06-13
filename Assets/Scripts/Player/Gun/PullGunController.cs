using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PullGunController : MonoBehaviour
{
    [SerializeField, Header("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Header("PullWireのGameObject")]
    GameObject _pullWireObj;

    [Tooltip("Wireの頂点（の配列）")]
    Vector3[] _wirePos = new Vector3[2];

    [SerializeField, Header("PullGunの最大射程")]
    float _pullGunRange = 50f;

    [SerializeField, Header("PullGunの引っ張る力")]
    float _pullPower = 0f;

    [SerializeField, Header("ゴッドモード（PullGunの射程無限）")]
    bool _godMode = false;

    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    public float PullGunRange { get => _pullGunRange;}

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, PullGunRange, LayerMask.GetMask("PullObject")))
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

        //PullWireを生成
        var wire = Instantiate(_pullWireObj, _muzzle.transform.position, Quaternion.identity, _muzzle.transform.parent);
        LineRenderer line = wire.GetComponent<LineRenderer>();
        _wirePos[0] = _muzzle.transform.position;
        _wirePos[1] = target.transform.position;
        line.SetPositions(_wirePos);

        Debug.Log("Pull 成功");
    }
}
