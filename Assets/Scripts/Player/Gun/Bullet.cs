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

    [Tooltip("eΜen_")]
    Vector3 _bulletPos;

    Rigidbody _rb;

    private void Start()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //var hitPos = Physics.Raycast(ray, out hit, _rayDistance);
        //_bulletPos = hit.collider.transform.position;
        //Debug.Log(hit.transform.position);

        //transform.DOMove(_bulletPos, _lifeTime).OnComplete(DestroyBullet);

        _rb = GetComponent<Rigidbody>();

        Destroy(this, _lifeTime);
    }

    private void Update()
    {
        _rb.AddForce(Vector3.forward * _bulletSpeed);
    }

    private void DestroyBullet()
    {
        this.gameObject.transform.localScale = _bulletPos;
        Destroy(this.gameObject);
    }
}
