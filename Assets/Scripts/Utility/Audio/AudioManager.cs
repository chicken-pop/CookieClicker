using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField]
    private AudioSource[] AudioSources = new AudioSource[3];

    private List<AudioClip> SeAudioClips = new List<AudioClip>();

    private List<AudioClip> BgmAudioClips = new List<AudioClip>();

    public enum AudioScourceType
    {
        Invalid = -1,
        BGM,
        SE_Primary,
        SE_Secondary
    }

    public enum SETypes
    {
        Invalid = -1,
        Click,
    }

    public enum BGMType
    {
        Invalid = -1,
        Start,
        InGame
    }

    public override void Awake()
    {
        var audioSources = this.GetComponentsInChildren<AudioSource>();

        for (int i = 0; i < AudioSources.Length; i++)
        {
            AudioSources[i] = audioSources[i];
        }
    }

    public void AudioLoad()
    {
        var seAudioClips = AddressableAssetLoadUtility.Instance.LoadAssetsAsync<AudioClip>("SE");
        SeAudioClips.AddRange(seAudioClips);

        var bgmAudioClips = AddressableAssetLoadUtility.Instance.LoadAssetsAsync<AudioClip>("BGM");
        BgmAudioClips.AddRange(bgmAudioClips);
    }

    public void PlayBGM(BGMType bgm)
    {
        AudioSources[(int)AudioScourceType.BGM].clip = BgmAudioClips[(int)bgm];
        AudioSources[(int)AudioScourceType.BGM].Play();
    }

    public void PlaySE(SETypes se)
    {
        if (!AudioSources[(int)AudioScourceType.SE_Primary].isPlaying)
        {
            AudioSources[(int)AudioScourceType.SE_Primary].clip = SeAudioClips[(int)se];
            AudioSources[(int)AudioScourceType.SE_Primary].Play();
            return;
        }

        if (!AudioSources[(int)AudioScourceType.SE_Secondary].isPlaying)
        {
            AudioSources[(int)AudioScourceType.SE_Secondary].clip = SeAudioClips[(int)se];
            AudioSources[(int)AudioScourceType.SE_Secondary].Play();
            return;
        }

        Debug.LogError("再生できるオーディオ数を超えています");
    }
}
