using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField, Tooltip("弾の生存時間")]
    float _lifeTime = 0.01f;

    [Tooltip("保存しておくためのScale")]
    Vector3 _bulletScale;

    private void Start()
    {
        _bulletScale = transform.localScale;

        transform.DOMove(Vector3.forward * 100f, _lifeTime).OnComplete(DestroyBullet);
    }

    private void DestroyBullet()
    {
        this.gameObject.transform.localScale = _bulletScale;
        Destroy(this.gameObject);
    }
}
