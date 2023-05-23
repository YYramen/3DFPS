using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField, Tooltip("e¬")]
    float _bulletSpeed = 10f;

    [SerializeField, Tooltip("eΜΆΆΤ")]
    float _lifeTime = 0.01f;

    [SerializeField, Tooltip("RayΜΕε£")]
    float _rayDistance = 100f;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(this.transform.forward * _bulletSpeed);

        Destroy(this.gameObject, _lifeTime);
    }
}
