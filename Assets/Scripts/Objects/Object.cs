using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ObjectType
{
    None = 0,
    NomalObj = 1,
    GrapObj = 2,
    PullObj = 3,
}

public class Object : MonoBehaviour
{
    [SerializeField, Header("GrapObjのMaterial")]
    Material _grapObjMaterials;

    [SerializeField, Header("PullObjのMaterial")]
    Material _pullObjMaterials;

    [SerializeField, Header("NomalObjのMaterial")]
    Material _nomalObjMaterials;

    [SerializeField, Header("オブジェクトの種類")]
    ObjectType _objType;

    [Header("グラップオブジェクトの設定")]
    [SerializeField, Header("プレイヤーを引っ張る力")]
    float _grapPower;

    [Header("プルオブジェクトの設定")]
    [SerializeField, Header("オブジェクトを引っ張る力")]
    float _pullPower;

    [SerializeField, Header("Playerのオブジェクト")]
    GameObject _playerObj;

    [Tooltip("銃と接続しているかどうか")]
    bool _isConnected = false;

    public bool IsConnected { get => _isConnected; }

    private void Start()
    {
        ObjectInitialize();
    }

    private void ObjectInitialize()
    {
        switch (_objType)
        {
            case ObjectType.None:
                Debug.LogWarning($"<color=#00ffffff>{this.gameObject.name}にObjectType指定されていません</color>");
                break;
            case ObjectType.NomalObj:
                this.gameObject.GetComponent<Renderer>().material = _nomalObjMaterials;
                break;
            case ObjectType.GrapObj:
                this.gameObject.GetComponent<Renderer>().material = _grapObjMaterials;
                break;
            case ObjectType.PullObj:
                this.gameObject.GetComponent<Renderer>().material = _pullObjMaterials;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_objType == ObjectType.None || _objType == ObjectType.NomalObj)
        {
            return;
        }

        if(_objType == ObjectType.GrapObj && collision.gameObject.layer == LayerMask.NameToLayer("GrapBullet"))
        {

        }
        else if (_objType == ObjectType.PullObj && collision.gameObject.layer == LayerMask.NameToLayer("PullBullet"))
        {

        }
    }
}
