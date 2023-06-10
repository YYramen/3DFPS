using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField, Header("GrapObj‚ÌMaterial")]
    Material _grapObjMaterials;

    [SerializeField, Header("PullObj‚ÌMaterial")]
    Material _pullObjMaterials;

    [SerializeField, Header("NomalObj‚ÌMaterial")]
    Material _nomalObjMaterials;

    private void Start()
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("GrapObject"))
        {
            Debug.Log($"{this.gameObject.name} ‚ÌLayer‚Í{this.gameObject.layer}‚Å‚·");

            this.gameObject.GetComponent<Renderer>().material = _grapObjMaterials;
        }
        else if(this.gameObject.layer == LayerMask.NameToLayer("PullObject"))
        {
            Debug.Log($"{this.gameObject.name} ‚ÌLayer‚Í{this.gameObject.layer}‚Å‚·");

            this.gameObject.GetComponent<Renderer>().material = _pullObjMaterials;
        }
        else if(this.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            Debug.Log($"{this.gameObject.name} ‚ÌLayer‚Í{this.gameObject.layer}‚Å‚·");

            this.gameObject.GetComponent<Renderer>().material = _nomalObjMaterials;
        }
    }
}
