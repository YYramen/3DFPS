using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerMoveWithInputSystem : MonoBehaviour
{
    [SerializeField, Header("移動速度(歩き)")] float _moveSpeed;

    [SerializeField, Header("集中線パーティクルオブジェクト")]
    GameObject _particleObj;

    [SerializeField, Header("参照用")] PlayerInput _playerInput;

    Rigidbody _rb;
    Vector3 _movement;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnMove;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move")
            return;
        Vector2 inputMove = context.ReadValue<Vector2>();

        _movement = new Vector3(inputMove.x * _moveSpeed, inputMove.y * _moveSpeed, 0);
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * _movement.y + Camera.main.transform.right * _movement.x;

        if (PlayerStateController.StateInstance.State == PlayerState.Inactive) return;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        _rb.velocity = moveForward * _moveSpeed + new Vector3(0, _rb.velocity.y, 0);
    }
}
