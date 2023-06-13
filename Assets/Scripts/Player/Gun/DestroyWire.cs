using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWire : MonoBehaviour
{
    [SerializeField, Header("��������")]
    float _lifeTime = 0.8f;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
