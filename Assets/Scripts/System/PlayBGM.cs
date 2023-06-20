using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField, Header("ƒvƒŒƒC‚·‚éBGM")]
    AudioManager.BGMSoundData.BGM _bgm;

    private void Start()
    {
        AudioManager.AudioManagerInstance.PlayBGM(_bgm);
    }
}
    
