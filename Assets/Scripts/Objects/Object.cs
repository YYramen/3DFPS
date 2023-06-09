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
}
