using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GrapGunController : MonoBehaviour
{
    [SerializeField, Header("Muzzleの位置")]
    Transform _muzzle;

    [SerializeField, Header("GrapBulletのGameObject")]
    GameObject _grapBulletObj;

    [SerializeField, Header("GrapGunの最大射程")]
    float _grapGunRange = 50f;

    [SerializeField, Header("GrapGunの引っ張る力")]
    float _grapPower;

    Rigidbody _rb;

    [Header("参照用")]
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
            

            Debug.Log("Grap成功");
        }
        else
        {
            return;
        }
    }

    void Grap()
    {

    }
}
