using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseCursorControll : MonoBehaviour
{
    [SerializeField, Header("GrapGunコンポーネント")] 
    GrapGunController _gGun;

    [SerializeField, Header("PullGunコンポーネント")]
    PullGunController _pGun;

    [SerializeField, Header("照準のImage")] 
    Image _crosshairImage;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _gGun.GrapGunRange, LayerMask.GetMask("GrapObject")))
        {
            _crosshairImage.color = Color.blue;
        }
        else if ((Physics.Raycast(ray, out hit, _pGun.PullGunRange, LayerMask.GetMask("PullObject"))))
        {
            _crosshairImage.color = Color.red;
        }
        else
        {
            _crosshairImage.color = Color.white;
        }
    }
}
