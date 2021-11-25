using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioSource bgSound;
    [SerializeField] private AudioSource bgSound;
    //BGM관련 소리
    [SerializeField] private AudioClip startBGM;
    [SerializeField] private AudioClip tutoBGM;
    [SerializeField] private AudioClip decoBGM;
    [SerializeField] private AudioClip lungBGM;
    [SerializeField] private AudioClip defenceBGM;
    [SerializeField] private AudioClip heartBGM;
    [SerializeField] private AudioClip heart2BGM;
    [SerializeField] private AudioClip colonBGM;
    [SerializeField] private AudioClip colon2BGM;
    [SerializeField] private AudioClip endingBGM;
    

    public void SoundTurnOn()
    {
        bgSound.Play();//소리 재생
    }

    public void SoundTurnOff()
    {
        bgSound.Pause(); //소리 정지
    }
    
    public void StartBGMSoundPlay()
    {
        if (startBGM == null)
            return;
        bgSound.clip = startBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void TutoBGMSoundPlay()
    {
        if (tutoBGM == null)
            return;
        bgSound.clip = tutoBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void DecoBGMSoundPlay()
    {
        if (decoBGM == null)
            return;
        bgSound.clip = decoBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void LungBGMSoundPlay()
    {
        if (lungBGM == null)
            return;
        bgSound.clip = lungBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void DefenceBGMSoundPlay()
    {
        if (defenceBGM == null)
            return;
        bgSound.clip = defenceBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void HeartBGMSoundPlay()
    {
        if (heartBGM == null)
            return;
        bgSound.clip = heartBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void Heart2BGMSoundPlay()
    {
        if (heart2BGM == null)
            return;
        bgSound.clip = heart2BGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void ColonBGMSoundPlay()
    {
        if (colonBGM == null)
            return;
        bgSound.clip = colonBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void Colon2BGMSoundPlay()
    {
        if (colon2BGM == null)
            return;
        bgSound.clip = colon2BGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    public void EndingBGMSoundPlay()
    {
        if (endingBGM == null)
            return;
        bgSound.clip = endingBGM;
        bgSound.loop = true;
        bgSound.volume = 0.2f;
        bgSound.Play();
    }

    
}
