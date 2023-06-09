using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance { get; private set; }

    [SerializeField] AudioSource _audioBGM;
    [SerializeField] AudioSource _audioSE;

    [SerializeField] List<BGMSoundData> _bgmSoundDatas;
    [SerializeField] List<SESoundData> _seSoundDatas;

    [SerializeField]
    private float _masterVolume = 1;
    [SerializeField]
    private float _bgmMasterVolume = 1;
    [SerializeField]
    private float _seMasterVolume = 1;

    void Awake()
    {
        if (AudioManagerInstance)
        {
            Debug.LogWarning("AudioManager複数あったため前のものを削除");
            Destroy(this.gameObject);
            return;
        }

        AudioManagerInstance = this;
    }

    /// <summary>
    /// BGMを再生
    /// </summary>
    /// <param name="bgm">再生したいBGM</param>
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = _bgmSoundDatas.Find(data => data._bgm == bgm);
        _audioBGM.clip = data._audioClip;
        _audioBGM.volume = data._volume * _bgmMasterVolume * _masterVolume;
        _audioBGM.Play();
    }

    /// <summary>
    /// SEを再生
    /// </summary>
    /// <param name="se">再生したいSE</param>
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = _seSoundDatas.Find(data => data.Se == se);
        _audioSE.volume = data.Volume * _seMasterVolume * _masterVolume;
        _audioSE.PlayOneShot(data.AudioClip);
    }

    [System.Serializable]
    public class BGMSoundData
    {
        public enum BGM
        {
            Title,
            Stage1,
            Stage2,
            Stage3,
        }

        public BGM _bgm;
        public AudioClip _audioClip;
        [Range(0f, 1f)]
        public float _volume = 1f;
    }

    [System.Serializable]
    public class SESoundData
    {
        public enum SE
        {
            Jump,
            GrapGun,
            PullGun,
            GameOver,
            StageClear,
            AllClear,
            ClickButton,
        }

        public SE Se;
        public AudioClip AudioClip;
        [Range(0, 1)]
        public float Volume = 1;
    }
}
