using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GrapGunController : MonoBehaviour
{
    [SerializeField, Header("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Header("GrapWireのGameObject")]
    GameObject _grapWireObj;

    [Tooltip("Wireの頂点（の配列）")]
    Vector3[] _wirePos = new Vector3[2];

    [SerializeField, Header("GrapGunの最大射程")]
    float _grapGunRange = 50f;

    [SerializeField, Header("GrapGunの引っ張る力")]
    float _grapPower;

    [SerializeField, Header("プレイヤーの入力を受け付けるまでの時間")]
    float _waitTime = 0.1f;

    [SerializeField, Header("ゴッドモード(GrapGunの射程無限)")]
    bool _godMode = false;

    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    Rigidbody _rb;

    public float GrapGunRange { get => _grapGunRange;}

    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

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

        if (context.performed && PlayerStateController.StateInstance.State == PlayerState.Inactive)
        {
            FireGrapBullet();
        }
    }

    private void FireGrapBullet()
    {
        Debug.Log("Grapgun fired");
        if (_godMode)
        {
            _grapGunRange += 100f;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, GrapGunRange, LayerMask.GetMask("GrapObject")))
        {
            Grap(hit);
        }
        else
        {
            return;
        }
    }

    void Grap(RaycastHit target)
    {
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Grap);

        // Grap処理
        _rb.velocity = Vector3.zero;
        Vector3 dir = target.transform.position - transform.position;
        _rb.AddForce(dir * _grapPower, ForceMode.Impulse);

        //GrapWireを生成
        var wire = Instantiate(_grapWireObj, _muzzle.transform.position, Quaternion.identity, _muzzle.transform.parent);
        LineRenderer line = wire.GetComponent<LineRenderer>();
        _wirePos[0] = _muzzle.transform.position;
        _wirePos[1] = target.transform.position;
        line.SetPositions(_wirePos);

        StartCoroutine(EndGrapple());
        Debug.Log("Grap Success");
    }

    IEnumerator EndGrapple()
    {
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Inactive);
        yield return new WaitForSeconds(_waitTime);
        Debug.Log("Grapple Ended");
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Move);
    }
}
