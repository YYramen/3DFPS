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

    [SerializeField, Header("GamePauseコンポーネント")]
    GamePause _gamePause;

    [SerializeField, Header("照準のImage")] 
    Image _crosshairImage;

    private void Update()
    {
        if (_gamePause.IsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (_gamePause.IsPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

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
