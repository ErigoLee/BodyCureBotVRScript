using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceManger : MonoBehaviour
{
    [SerializeField] private LungManager lungManager;
    //player
    [SerializeField]
    private GameObject player;

    //noPlayerObject
    [SerializeField]
    private GameObject noPlayerObjects;

    [SerializeField] private AudioManager audioManager;
    

    public void DenfenceReadyStage()
    {
        audioManager.DefenceBGMSoundPlay();
        player.transform.localPosition = new Vector3(4.0f, 0.0f, 1.0f);
        noPlayerObjects.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -120.0f, 0.0f));
    }

    public void DefenceStart()
    {
        lungManager.StartStep3_2();
    }

    public void DefenceEndStage()
    {
        audioManager.LungBGMSoundPlay();
        noPlayerObjects.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        player.transform.localPosition = new Vector3(-7.0f, 0.0f, 0.0f);
    }


    public void DenfenceEnd()
    {
        
        lungManager.EndStep3();
    }
}
