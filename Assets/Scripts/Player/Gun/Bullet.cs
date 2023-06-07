using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField, Header("íeë¨")]
    float _bulletSpeed = 10f;

    [SerializeField, Header("íeÇÃê∂ë∂éûä‘")]
    float _lifeTime = 0.01f;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(this.transform.forward * _bulletSpeed);

        Destroy(this.gameObject, _lifeTime);
    }
}
