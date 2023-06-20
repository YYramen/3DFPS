using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWallJump : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    float _wallJumpPower = 0f;

    [SerializeField, Header("接地判定に使う、RayCastの開始地点")]
    float _wallCheckOffsetY = 0.45f;

    [SerializeField, Header("壁のLayerMask")]
    LayerMask _wallLayer;

    [SerializeField, Header("接地判定に使う、接地判定の長さ")]
    float _wallCheckDistance = 0.2f;

    [SerializeField, Header("WallRun時のプレイヤーの速度")]
    float _wallRunSpeed = 5f;

    [SerializeField, Header("WallRun時のプレイヤーの速度倍率")]
    float _wallRunSpeedMultiPlier = 2.0f;

    [SerializeField, Header("WallRunの時間")]
    float _wallRunTime = 1.0f;

    [SerializeField, Header("プレイヤーのカメラのTransform")]
    Transform _playerCameraTransform;

    [SerializeField, Header("参照用")]
    PlayerInput _playerInput;

    bool _isWall = false;
    bool _isWallJump = false;
    RaycastHit _hitRightWall;
    RaycastHit _hitLeftWall;
    Rigidbody _rb;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnMove;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Jump")
            return;

        if (PlayerStateController.StateInstance.State == PlayerState.WallRun && context.performed)
        {
            _isWallJump = true;
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CheckLeftWall() || CheckRightWall())
        {
            WallRun();
        }

        Debug.Log(PlayerStateController.StateInstance.State);
    }

    bool CheckRightWall()
    {
        return Physics.Raycast(
            this.transform.position + _wallCheckOffsetY * Vector3.up,
            Vector3.right, out _hitRightWall, _wallCheckDistance, _wallLayer);
    }

    bool CheckLeftWall()
    {
        return Physics.Raycast(
            this.transform.position + _wallCheckOffsetY * Vector3.up,
            Vector3.left, out _hitLeftWall, _wallCheckDistance, _wallLayer);
    }
    void WallJump()
    {
        Debug.Log("Wall Jump Enabled");

        Vector3 jumpDir = Vector3.zero;

        if (CheckRightWall())
        {
            jumpDir = _hitRightWall.normal * 2 + transform.up * 2;

        }
        else if (CheckLeftWall())
        {
            jumpDir = _hitLeftWall.normal * 2 + transform.up * 2;

        }
        else
        {
            jumpDir = transform.up;
            Debug.LogWarning("Something Wrong!!!");
        }

        _rb.AddForce(jumpDir * _wallJumpPower, ForceMode.Impulse);
        DisableWallRun();
    }

    /// <summary>
    /// ウォールラン処理
    /// </summary>
    /// <returns></returns>
    void WallRun()
    {
        
        Debug.Log("Start WallRun");

        _rb.useGravity = false;
        if (!_isWall) StartCoroutine(WallRunTime());

        Vector3 dir = Vector3.zero;
        
        if (CheckRightWall())
        {
            if (_playerCameraTransform.transform.forward.z >= 0)
            {
                dir = _hitRightWall.collider.gameObject.transform.forward;
            }
            else if (_playerCameraTransform.transform.forward.z < 0)
            {
                dir = -_hitRightWall.collider.gameObject.transform.forward;
            }

            if (_isWallJump)
            {
                WallJump();
            }
        }
        else if (CheckLeftWall())
        {
            if (_playerCameraTransform.transform.forward.z >= 0)
            {
                dir = _hitLeftWall.collider.gameObject.transform.forward;
            }
            else if (_playerCameraTransform.transform.forward.z < 0)
            {
                dir = -_hitLeftWall.collider.gameObject.transform.forward;
            }

            if (_isWallJump)
            {
                WallJump();
            }
        }
        else
        {
            Debug.LogWarning("Something Wrong");
        }

        dir.y = 0;
        _rb.AddForce(dir.normalized * _wallRunSpeed * _wallRunSpeedMultiPlier, ForceMode.Acceleration);
    }

    /// <summary>
    /// ウォールランをできなくする
    /// </summary>
    /// <returns></returns>
    void DisableWallRun()
    {
        _isWall = false;
        _isWallJump = false;
        _rb.useGravity = true;
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Move);
    }

    IEnumerator WallRunTime()
    {
        _rb.useGravity = false;
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.WallRun);
        _isWall = true;
        Debug.Log("WallRun Now");

        if (_isWallJump)
        {
            yield break;
        }


        yield return new WaitForSeconds(_wallRunTime);

        Debug.Log("WallRun End");
        DisableWallRun();
    }
}
