using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField, Header("GrapObjのMaterial")]
    Material _grapObjMaterials;

    [SerializeField, Header("PullObjのMaterial")]
    Material _pullObjMaterials;

    [SerializeField, Header("NomalObjのMaterial")]
    Material _nomalObjMaterials;

    private void Start()
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("GrapObject"))
        {
            Debug.Log($"{this.gameObject.name} のLayerは{this.gameObject.layer}です");

            this.gameObject.GetComponent<Renderer>().material = _grapObjMaterials;
        }
        else if(this.gameObject.layer == LayerMask.NameToLayer("PullObject"))
        {
            Debug.Log($"{this.gameObject.name} のLayerは{this.gameObject.layer}です");

            this.gameObject.GetComponent<Renderer>().material = _pullObjMaterials;
        }
        else if(this.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            Debug.Log($"{this.gameObject.name} のLayerは{this.gameObject.layer}です");

            this.gameObject.GetComponent<Renderer>().material = _nomalObjMaterials;
        }
    }
}
