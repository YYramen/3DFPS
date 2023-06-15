using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    float _jumpPower = 0f;

    [SerializeField, Header("接地判定に使う、RayCastの開始地点")]
    float _groundCheckOffsetY = 0.45f;

    [SerializeField, Header("接地判定に使う、接地判定の長さ")]
    float _groundCheckDistance = 0.2f;

    [SerializeField, Header("入力受付を再開するまでの時間")]
    float _waitTime = 0.1f;

    [SerializeField, Header("参照用")]
    PlayerInput _playerInput;

    Rigidbody _rb;
    RaycastHit _hit;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

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
        {
            return;
        }

        if (context.performed && PlayerStateController.StateInstance.State == PlayerState.Move ||
            PlayerStateController.StateInstance.State == PlayerState.WallRun)
        {
            Jump();
        }
    }

    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        CheckGrounded();

        Debug.Log(PlayerStateController.StateInstance.State);
    }

    void Jump()
    {
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Jump);
        _rb.AddForce(_jumpPower * Vector3.up);
        StartCoroutine(ChangePlayerState());
        Debug.Log("Player Jumped");
    }

    void CheckGrounded()
    {
        if(Physics.Raycast(this.transform.position + _groundCheckOffsetY * Vector3.up,
            Vector3.down, out _hit, _groundCheckDistance))
        {
            PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Move);
        }
        else
        {
            PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Jump);
        }
    }

    IEnumerator ChangePlayerState()
    {
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Inactive);
        yield return new WaitForSeconds(_waitTime);
        PlayerStateController.StateInstance.ChangePlayerState(PlayerState.Move);
        Debug.Log("Jump Ended");
    }
}
