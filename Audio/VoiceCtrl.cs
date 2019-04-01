/*
* @Description: Controller of audio
* @Author: ookuro19
* @Date:   2018-06-21 18:11:28
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-08-16 16:07:43
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceCtrl : SingletonMono<VoiceCtrl>
{

    public bool _IsListeningMusic = true;

    public AudioSource _BGMAudioSource;
    public AudioSource _GeneralAudioSource;
    public AudioSource _UIAudioSource;
    public AudioSource _HitAudioSource;

    public AudioClip[] _BowAudioClip;
    public AudioClip[] _HitResultAudioClip;
    public AudioClip[] _LevelAudioClip;
    public AudioClip[] _UIAudioClip;

    private List<AudioSource> m_audioSourseList = new List<AudioSource>();

    #region Unity Method
    void Awake()
    {
        InitVoiceCtrl();
    }
    #endregion

    void InitVoiceCtrl()
    {

        _BGMAudioSource.playOnAwake = true;
        _BGMAudioSource.loop = true;

        _GeneralAudioSource.playOnAwake = false;
        _GeneralAudioSource.loop = false;

        _UIAudioSource.playOnAwake = false;
        _UIAudioSource.loop = false;

        _HitAudioSource.playOnAwake = false;
        _HitAudioSource.loop = false;

        m_audioSourseList.Add(_BGMAudioSource);
        m_audioSourseList.Add(_GeneralAudioSource);
        m_audioSourseList.Add(_UIAudioSource);
        m_audioSourseList.Add(_HitAudioSource);

#if UNITY_EDITOR
        if (_IsListeningMusic)
        {
            _BGMAudioSource.volume = 0;
            _GeneralAudioSource.volume = 0;
            _UIAudioSource.volume = 0;
        }
#endif
    }

    public void PlaySound(object tClipType)
    {
        string enumType = tClipType.GetType().Name;
        string enumName = tClipType.ToString();
        int tNum = (int)tClipType;
        // Debug.Log("play sound name is : " + enumType + "." + enumName);
        // AudioClip clip = ResourcesLoad.Instance.LoadAudioClip(tClipType);
        // Debug.Log("cur audio clip name is : " + enumName);
        switch (enumType)
        {
            case "Bow":
                {
                    PlayAudioClip(_BowAudioClip[tNum]);
                    break;
                }
            case "HitResult":
                {
                    PlayHitSound(_HitResultAudioClip[tNum]);
                    break;
                }
            case "Level":
                {
                    PlayAudioClip(_LevelAudioClip[tNum]);
                    break;
                }
            case "UI":
                {
                    PlayUISound(_UIAudioClip[tNum]);
                    break;
                }
        }
        switch (enumName)
        {
            case "GameOver":
                {
                    StartCoroutine(BGMReplay(1f));
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    //切换是否播放声音
    public void SwitchVoicePlay()
    {
        CurrentGameInfo.Instance.SwichVoicePlay();
        for (int i = 0; i < m_audioSourseList.Count; i++)
        {
            m_audioSourseList[i].enabled = CurrentGameInfo.g_IsVoiceOn;
        }
    }

    //停止播放声音
    public void StopSound()
    {
        _GeneralAudioSource.Stop();
    }

    //停止播放声音
    public void StopUISound()
    {
        _UIAudioSource.Stop();
    }

    public void StopBgmPlay()
    {
        _BGMAudioSource.Stop();
    }

    void PlayAudioClip(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        _GeneralAudioSource.clip = clip;
        _GeneralAudioSource.minDistance = 1.0f;
        _GeneralAudioSource.maxDistance = 50;
        _GeneralAudioSource.rolloffMode = AudioRolloffMode.Linear;
        _GeneralAudioSource.transform.position = transform.position;
        _GeneralAudioSource.Play();
    }

    void PlayUISound(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        _UIAudioSource.clip = clip;
        _UIAudioSource.minDistance = 1.0f;
        _UIAudioSource.maxDistance = 50;
        _UIAudioSource.rolloffMode = AudioRolloffMode.Linear;
        _UIAudioSource.transform.position = transform.position;
        _UIAudioSource.Play();
    }

    void PlayHitSound(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        _HitAudioSource.clip = clip;
        _HitAudioSource.minDistance = 1.0f;
        _HitAudioSource.maxDistance = 50;
        _HitAudioSource.rolloffMode = AudioRolloffMode.Linear;
        _HitAudioSource.transform.position = transform.position;
        _HitAudioSource.Play();
    }

    IEnumerator BGMReplay(float delayTime)
    {
        _BGMAudioSource.volume = 0.25f;
        yield return new WaitForSeconds(delayTime);
        _BGMAudioSource.volume = 0.5f;
    }

}
