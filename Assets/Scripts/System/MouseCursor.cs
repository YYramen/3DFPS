using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseCursor : MonoBehaviour
{
    [SerializeField, Header("RaycastÇÃRange")] float _raycastDistance = 100f;
    [SerializeField, Header("è∆èÄÇÃImage")] Image _crosshairImage;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance, LayerMask.GetMask("GrapObject")))
        {
            _crosshairImage.color = Color.blue;
        }
        else if ((Physics.Raycast(ray, out hit, _raycastDistance, LayerMask.GetMask("PullObject"))))
        {
            _crosshairImage.color = Color.red;
        }
        else
        {
            _crosshairImage.color = Color.white;
        }
    }
}
