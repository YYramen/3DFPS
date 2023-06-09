using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapBullet : MonoBehaviour
{
    [SerializeField, Header("弾速")]
    float _bulletSpeed = 10f;

    [SerializeField, Header("弾の生存時間")]
    float _lifeTime = 0.01f;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(this.transform.forward * _bulletSpeed);

        Destroy(this.gameObject, _lifeTime);
    }
}
