using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWire : MonoBehaviour
{
    [SerializeField, Header("ê∂ë∂éûä‘")]
    float _lifeTime = 0.8f;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
