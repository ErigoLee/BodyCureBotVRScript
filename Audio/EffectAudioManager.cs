using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioManager : MonoBehaviour
{

    //AudionSource effectSound;
    [SerializeField] private AudioClip dialogEffect; //다이얼로그 효과음
    [SerializeField] private AudioClip throwEffect; //던졌을 때 물체랑 부딪치는 효과음
    [SerializeField] private AudioClip pointerFixedRobotEffect; //pointer로 렌치를 부딪칠 때 나는 효과음
    [SerializeField] private AudioClip restoredRobotEffect; // 오른팔 복구 효과음
    [SerializeField] private AudioClip triggerBarEffect; //triggerbar 효과음
    [SerializeField] private AudioClip cutBronchialEffect; //기관지 자를 때 나는 효과음
    [SerializeField] private AudioClip shootingEffect; //총알이 나갈 때 나는 효과음
    [SerializeField] private AudioClip hitMonsterEffect; //몬스터랑 부딪칠 때 나는 효과음
    [SerializeField] private AudioClip reloadedGudEffect; //장전 필요시 나는 효과음
    [SerializeField] private AudioClip getEmblemEffect; //엠블럼 획득시 나는 효과음
    [SerializeField] private AudioClip warningEffect; //경고창 나타날 때 생기는 효과음
    [SerializeField] private AudioClip temporaryHeartBeatEffect; //심장 뛰기 효과음 -한번
    [SerializeField] private AudioClip heartBeatEffect; //심장 뛰기 효과음
    [SerializeField] private AudioClip expandedStentEffect; //스텐트 확장 효과음
    [SerializeField] private AudioClip falledTumorEffect; //종양 떨어질 때 나는 효과음
    [SerializeField] private AudioClip colonNextStageGuideEffect; //다음 스테이지 안내시 나는 효과음
    [SerializeField] private AudioClip buttonClickEffect; //버튼 클릭시 나는 효과음

    private GameObject triggerBarSoundObject;
    private GameObject heartBeatSoundObject;
    void Start()
    {
        triggerBarSoundObject = null;
        heartBeatSoundObject = null;
    }
    public void DialogEffect() //각각 dialogue script에서 NextDialogue함수에 호출(count가 1이상인 경우에 호출되도록 함)
    {

        if (dialogEffect == null)
            return;

        GameObject dialogSoundObject = new GameObject("DialogSoundEffect");
        dialogSoundObject.transform.position = transform.position;
        dialogSoundObject.transform.rotation = transform.rotation;
        AudioSource dialogSound = dialogSoundObject.AddComponent<AudioSource>();
        dialogSound.clip = dialogEffect;
        dialogSound.Play();
        //dialogSound.volume = 0.1f; - 볼륨 조절

        Destroy(dialogSoundObject, 0.5f);
    }


    public void ThrowEffect() // BalloonGenerator - DeleteBallon함수에서 호출 , TutorialThrowCheck - Update함수에서 호출
    {
        if (throwEffect == null)
            return;

        GameObject throwSoundObject = new GameObject("ThrowSoundEffect");
        throwSoundObject.transform.position = transform.position;
        throwSoundObject.transform.rotation = transform.rotation;
        AudioSource throwSound = throwSoundObject.AddComponent<AudioSource>();
        throwSound.clip = throwEffect;
        //throwSound.volume = 0.1f; - 볼륨 조절
        throwSound.Play();
        

        Destroy(throwSoundObject, 1.0f);
    }
    
    public void PointerFixedEffect() //PartActive-DeleteCount함수에서 호출
    {
        if (pointerFixedRobotEffect == null)
            return;

        GameObject PointerSoundObject = new GameObject("PointerEffect");
        PointerSoundObject.transform.position = transform.position;
        PointerSoundObject.transform.rotation = transform.rotation;
        AudioSource pointerSound = PointerSoundObject.AddComponent<AudioSource>();
        pointerSound.clip = pointerFixedRobotEffect;
        //pointerSound.volume = 0.1f; - 볼륨 조절
        pointerSound.Play();
        
        Destroy(PointerSoundObject, 0.5f);
    }

    public void RestoredRobotEffect() //PartActive-Restore함수에서 호출
    {
        if (restoredRobotEffect == null)
            return;

        GameObject restoredSoundObject = new GameObject("RestoredEffect");
        restoredSoundObject.transform.position = transform.position;
        restoredSoundObject.transform.rotation = transform.rotation;
        AudioSource restoredSound = restoredSoundObject.AddComponent<AudioSource>();
        restoredSound.clip = restoredRobotEffect;
        //restored.volume = 0.1f; - 볼륨 조절
        restoredSound.Play();

        Destroy(restoredSoundObject, 1.0f);
    }

    public void TriggerBarEffectTurnOn() //CanTransLungs - triggerEnter함수에서 호출 / RecoverLungs-triggerEnter함수에서 호출 /CreateRope-triggerEnter함수에서 호출
    { //triggerBarEffect은 loop를 아니지만 음원 지속시간이 3초정도였음으면 좋겠다.
        if (triggerBarEffect == null)
            return;
        if (triggerBarSoundObject != null)
            return;
        GameObject _triggerBarSoundObject = new GameObject("TriggerBarEffect");
        _triggerBarSoundObject.transform.position = transform.position;
        _triggerBarSoundObject.transform.rotation = transform.rotation;
        triggerBarSoundObject = _triggerBarSoundObject;
        AudioSource triggerSound = triggerBarSoundObject.AddComponent<AudioSource>();
        triggerSound.clip = triggerBarEffect;
        triggerSound.Play();
    }


    public void TriggerBarEffectTurnOff() //CanTransLungs - triggerExit함수에서 호출, Update함수에서 호출(조건식안에) / RecoverLungs-triggerExit함수에서 호출, Update함수에서 호출(조건식안에) / CreateRope-triggerExit함수에서 호출, Update함수에서 호출(조건식안에)
    {
        if (triggerBarSoundObject == null)
            return;
        Destroy(triggerBarSoundObject);
        triggerBarSoundObject = null;
    }

    public void CutBronchialEffect() //VGestureDetector - Update함수(조건식안에 있음)
    {
        if (cutBronchialEffect == null)
            return;
        GameObject cutBronchialSoundObject = new GameObject("CutBronchialEffect");
        cutBronchialSoundObject.transform.position = transform.position;
        cutBronchialSoundObject.transform.rotation = transform.rotation;
        AudioSource cutBronchialSound = cutBronchialSoundObject.AddComponent<AudioSource>();
        cutBronchialSound.clip = cutBronchialEffect;
        //cutBronchialSound.volume = 0.1f; 볼륨 조절
        cutBronchialSound.Play();

        Destroy(cutBronchialSoundObject, 1.0f);
    }
    //shootingEffect
    public void ShootingEffect()  //Player- LeftHandGun함수,RightHandGun함수에서 호출 
    {
        if (shootingEffect == null)
            return;
        GameObject shootingSoundObject = new GameObject("ShootingEffect");
        shootingSoundObject.transform.position = transform.position;
        shootingSoundObject.transform.rotation = transform.rotation;
        AudioSource shootingSound = shootingSoundObject.AddComponent<AudioSource>();
        shootingSound.clip = shootingEffect;
        shootingSound.volume = 0.1f;
        shootingSound.Play();

        Destroy(shootingSoundObject, 1.0f);
    }
    
    public void HitMonsterEffect() //Bullet2 - triggerEnter함수 호출
    {
        if (hitMonsterEffect == null)
            return;
        GameObject hitMonsterSoundObject = new GameObject("HitMonsterEffect");
        hitMonsterSoundObject.transform.position = transform.position;
        hitMonsterSoundObject.transform.rotation = transform.rotation;
        AudioSource hitMonsterSound = hitMonsterSoundObject.AddComponent<AudioSource>();
        hitMonsterSound.clip = hitMonsterEffect;
        //hitMonsterSound.volume = 0.1f;
        hitMonsterSound.Play();

        Destroy(hitMonsterSoundObject, 1.5f);
    }
    //reloadedGudEffect
    public void ReloadEffect() //LeftReloadText - Reloading코르틴 함수/ RightReloadText - Reloading코르틴 함수호출
    {
        if (reloadedGudEffect == null)
            return;
        GameObject reloadedSoundObject = new GameObject("RealoadedEffect");
        reloadedSoundObject.transform.position = transform.position;
        reloadedSoundObject.transform.rotation = transform.rotation;
        AudioSource reloadedSound = reloadedSoundObject.AddComponent<AudioSource>();
        reloadedSound.clip = reloadedGudEffect;
        //reloadedSound.volume = 0.1f;
        reloadedSound.Play();

        Destroy(reloadedSoundObject,1.0f);
        
    }

    //getEmblemEffect
    public void GetEmblemEffect() //LungManager - LungEnd함수에서 호출 / PreHeartManger - PreHeartEnd함수에서 호출/ColonManager - ColonEnd함수에서 호출
    {
        if (getEmblemEffect == null)
            return;
        GameObject getEmblemSoundObject = new GameObject("GetEmblemEffect");
        getEmblemSoundObject.transform.position = transform.position;
        getEmblemSoundObject.transform.rotation = transform.rotation;
        AudioSource getEmblemSound = getEmblemSoundObject.AddComponent<AudioSource>();
        getEmblemSound.clip = getEmblemEffect;
        //getEmblemSound.volume = 0.1f;
        getEmblemSound.Play();

        Destroy(getEmblemSound, 4.4f);
        
    }

    public void WarningEffect() //PreHeartManager - Loading코르틴함수에서 호출
    {
        if (warningEffect == null)
            return;
        GameObject warningSoundObject = new GameObject("WarningEffect");
        warningSoundObject.transform.position = transform.position;
        warningSoundObject.transform.rotation = transform.rotation;
        AudioSource warningSound = warningSoundObject.AddComponent<AudioSource>();
        warningSound.clip = warningEffect;
        warningSound.volume = 0.1f;
        warningSound.Play();

        Destroy(warningSoundObject, 5.0f);
        
    }

    public void TemporaryHeartBeatEffect() //CPR-CPRAnimStartAndEffect 코르틴에서 호출
    {
        if (temporaryHeartBeatEffect == null)
            return;
        GameObject tempoaryHeartBeatSoundObject = new GameObject("TempoaryHeartBeatEffect");
        tempoaryHeartBeatSoundObject.transform.position = transform.position;
        tempoaryHeartBeatSoundObject.transform.rotation = transform.rotation;
        AudioSource tempoaryHeartSound = tempoaryHeartBeatSoundObject.AddComponent<AudioSource>();
        tempoaryHeartSound.clip = temporaryHeartBeatEffect;
        //tempoaryHeartSound.volume = 0.1f;
        tempoaryHeartSound.Play();

        Destroy(tempoaryHeartBeatSoundObject,1.1f); 
    }

    public void HeartBeatEffectTurnOn() //PreHeartManger - EndStage1에 호출
    {
        if (heartBeatEffect == null) 
            return;

        if (heartBeatSoundObject != null)
            return;
        GameObject _heartBeatSoundObject = new GameObject("HeartBeatEffect");
        _heartBeatSoundObject.transform.position = transform.position;
        _heartBeatSoundObject.transform.rotation = transform.rotation;
        heartBeatSoundObject = _heartBeatSoundObject;
        AudioSource heartSound = heartBeatSoundObject.AddComponent<AudioSource>();
        heartSound.clip = heartBeatEffect;
        heartSound.volume = 0.6f;
        heartSound.loop = true;
        heartSound.Play();
    }

    public void HeartBeatEffectTurnOff() //TotalManger - PreHeartEnd()함수에서 호출
    {
        if (heartBeatSoundObject == null)
            return;
        Destroy(heartBeatSoundObject);
        heartBeatSoundObject = null; 
    }

    public void ExpandedStentEffect() //NewStent -ReadyInterval코르틴에서 호출
    {
        if (expandedStentEffect == null)
            return;
        GameObject expandStentSoundObject = new GameObject("ExpandedStentEffect");
        expandStentSoundObject.transform.position = transform.position;
        expandStentSoundObject.transform.rotation = transform.rotation;
        AudioSource expandedSound = expandStentSoundObject.AddComponent<AudioSource>();
        expandedSound.clip = expandedStentEffect;
        //expandedSound.volume = 0.1f;
        expandedSound.Play();

        Destroy(expandStentSoundObject, 3.0f); 
    }

    public void FalledTumorEffect() //Tumor - OnCollisionEnter함수 호출
    {
        if (falledTumorEffect == null)
            return;
        GameObject falledTumorSoundObject = new GameObject("FalledTumorEffect");
        falledTumorSoundObject.transform.position = transform.position;
        falledTumorSoundObject.transform.rotation = transform.rotation;
        AudioSource falledTumorSound = falledTumorSoundObject.AddComponent<AudioSource>();
        falledTumorSound.clip = falledTumorEffect;
        //falledTumorSound.volume = 0.1f;
        falledTumorSound.Play();

        Destroy(falledTumorSoundObject, 1.0f);
    }
    
    public void ColonNextStageGuideEffect() //ColonManager - PreStartStage2Loading코르틴함수에서 호출,PreStartStage3Loading코르틴함수에서 호출 
    {
        if (colonNextStageGuideEffect == null)
            return;
        GameObject colonNextStageGuideSoundObject = new GameObject("ColonNextStageGuideEffect");
        colonNextStageGuideSoundObject.transform.position = transform.position;
        colonNextStageGuideSoundObject.transform.rotation = transform.rotation;
        AudioSource colonNextStageGuideSound = colonNextStageGuideSoundObject.AddComponent<AudioSource>();
        colonNextStageGuideSound.clip = colonNextStageGuideEffect;
        //colonNextStageGuideSound.volume = 0.1f;
        colonNextStageGuideSound.Play();

        Destroy(colonNextStageGuideSoundObject, 1.0f);
    }

    public void ButtonClickEffect() //PhysicButton - Pressed함수에서 호출
    {
        if (buttonClickEffect == null)
            return;
        GameObject buttonClickSoundObject = new GameObject("ButtonClickEffect");
        buttonClickSoundObject.transform.position = transform.position;
        buttonClickSoundObject.transform.rotation = transform.rotation;
        AudioSource buttonClickSound = buttonClickSoundObject.AddComponent<AudioSource>();
        buttonClickSound.clip = buttonClickEffect;
        //buttonClickSound.volume = 0.1f;
        buttonClickSound.Play();

        Destroy(buttonClickSoundObject, 1.0f);
    }

}
