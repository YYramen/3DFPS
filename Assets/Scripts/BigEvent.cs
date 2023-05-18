using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEvent : MonoBehaviour
{
    [SerializeField] GameObject _text;

   public void OnClickEvent()
    {
        _text.SetActive(true);
    }
}
