using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControll : MonoBehaviour
{
    [SerializeField, Header("Materialオブジェクト")]
    Material _material;

    [SerializeField, Header("Tiling")]
    Vector2 _tiling;

    [SerializeField, Header("Offset")]
    Vector2 _offset;

    private void Start()
    {
        _material.SetTextureScale("_MainTex", new Vector2(_tiling.x, _tiling.y));
        _material.SetTextureOffset("_MainTex", new Vector2(_offset.x, _offset.y));
    }

    private void Update()
    {
        if(PlayerStateController.StateInstance.State != PlayerState.None||
            PlayerStateController.StateInstance.State != PlayerState.Inactive)
        {
            this.gameObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            this.gameObject.GetComponent<ParticleSystem>().Pause();
        }

    }
}
