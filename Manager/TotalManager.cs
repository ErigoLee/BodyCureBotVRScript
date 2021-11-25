using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalManager : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject startScene;
    [SerializeField] private GameObject tutoScene;
    [SerializeField] private GameObject tutoManagerObject;
    [SerializeField] private GameObject decoScene;
    [SerializeField] private GameObject decoManagerObject;
    [SerializeField] private GameObject lungScene;
    [SerializeField] private GameObject lungManagerObject;
    [SerializeField] private GameObject preHeartScene;
    [SerializeField] private GameObject preHeartManagerObject;
    [SerializeField] private GameObject heartScene;
    [SerializeField] private GameObject heartManagerObject;
    [SerializeField] private GameObject preColonScene;
    [SerializeField] private GameObject preColonManagerObject;
    [SerializeField] private GameObject colonScene;
    [SerializeField] private GameObject colonManagerObject;
    [SerializeField] private GameObject ending;
    [SerializeField] private GameObject endingManagerObject;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private GameObject GR;
    private int stage = -2;
    void Start()
    {
        //DecoStart();
        GR = GameObject.FindGameObjectWithTag("GR");
        ScreenStart();
    }

    public void ScreenStart()
    {
        audioManager.StartBGMSoundPlay();
        stage = -2;
        GR.GetComponent<GestureRecongizedLeft>().enabled = false;
        GR.GetComponent<GestureRecongizedRight>().enabled = false;
    }

    public void ScreenEnd()
    {
        startScene.SetActive(false);
        TutoStart();
    }


    public void TutoStart()
    {
        audioManager.TutoBGMSoundPlay();
        stage = -1;
        tutoScene.SetActive(true);
        tutoManagerObject.SetActive(true);
    }

    public void TutoEnd()
    {
        tutoScene.SetActive(false);
        DecoStart();
    }


    public void DecoStart()
    {
        audioManager.DecoBGMSoundPlay();
        stage = 0;
        playerObject.transform.position = new Vector3(0,0,0);
        player.transform.localPosition = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().center = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        player.GetComponent<BoxCollider>().isTrigger = true;
        decoManagerObject.SetActive(true);
        decoScene.SetActive(true);
    }

    public void DecoEnd()
    {
        decoScene.SetActive(false);
        LungStart();
    }

    public void LungStart()
    {
        audioManager.LungBGMSoundPlay();
        stage = 1;
        playerObject.transform.position = new Vector3(0,0,0);
        player.transform.localPosition = new Vector3(0,0,4.4f);
        player.GetComponent<BoxCollider>().center = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().size = new Vector3(3,5,3);
        player.GetComponent<BoxCollider>().isTrigger = true;
        player.GetComponent<Player>().enabled = true;
        lungScene.SetActive(true);
        lungManagerObject.SetActive(true);
    }

    public void LungEnd()
    {
        lungScene.SetActive(false);
        player.GetComponent<Player>().enabled = false;
        PreHeartStart();
    }

    public void PreHeartStart()
    {
        audioManager.HeartBGMSoundPlay();
        stage = 2;
        playerObject.transform.position = new Vector3(0, 0, 0);
        player.transform.localPosition = new Vector3(0, 0, 0);
        player.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        player.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        player.GetComponent<BoxCollider>().isTrigger = true;
        preHeartScene.SetActive(true);
        preHeartManagerObject.SetActive(true);
    }

    public void PreHeartEnd()
    {
        effectAudioManager.HeartBeatEffectTurnOff();
        preHeartScene.SetActive(false);
        HeartStart();
    }
    
    public void HeartStart()
    {
        audioManager.Heart2BGMSoundPlay();
        stage = 3;
        playerObject.transform.position = new Vector3(0, 1, 0);
        player.transform.localPosition = new Vector3(0, 1, -42);
        player.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        player.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        player.GetComponent<BoxCollider>().isTrigger = true;
        heartScene.SetActive(true);
        heartManagerObject.SetActive(true);
        player.GetComponent<RestrictedAreaSet2>().enabled = true;
    }

    public void HeartEnd()
    {
        player.GetComponent<RestrictedAreaSet2>().enabled = false;
        heartScene.SetActive(false);
        PreColonStart();
    }

    public void PreColonStart()
    {
        audioManager.ColonBGMSoundPlay();
        stage = 4;
        playerObject.transform.position = new Vector3(0,0,0);
        player.transform.localPosition = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().center = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        player.GetComponent<BoxCollider>().isTrigger = true;
        preColonScene.SetActive(true);
        preColonManagerObject.SetActive(true);
    }

    public void PreColonEnd()
    {
        preColonScene.SetActive(false);
        ColonStart();
    }

    public void ColonStart()
    {
        audioManager.Colon2BGMSoundPlay();
        stage = 5;
        playerObject.transform.position = new Vector3(0,10,0);
        player.transform.localPosition = new Vector3(0,0,0);
        player.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        player.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        player.GetComponent<BoxCollider>().isTrigger = true;
        colonScene.SetActive(true);
        colonManagerObject.SetActive(true);
        player.GetComponent<RestrictedAreaSet>().enabled = true;
    }

    public void ColonEnd()
    {
        colonScene.SetActive(false);
        player.GetComponent<RestrictedAreaSet>().enabled = false;
        EndStart();
    }

    public void EndStart()
    {
        audioManager.EndingBGMSoundPlay();
        playerObject.transform.position = new Vector3(0, 0, 0);
        player.transform.localPosition = new Vector3(0, 0, 0);
        ending.SetActive(true);
        endingManagerObject.SetActive(true);
        GR.SetActive(false);
    }


    void Update()
    {
        switch (stage)
        {
            case -1:
                Vector3 position = player.transform.localPosition;
                if (position.x > 8)
                    position.x = 8;
                if (position.x < -8)
                    position.x = -8;
                if (position.z > 8)
                    position.z = 8;
                if (position.z < -8)
                    position.z = -8;
                player.transform.localPosition = position;
                break;
            //deco
            case 0:
                position = player.transform.localPosition;
                if (position.x < -5)
                    position.x = -5;
                if (position.x > 5)
                    position.x = 5;
                if (position.z < -8)
                    position.z = -8;
                if (position.z > 8)
                    position.z = 8;
                player.transform.localPosition = position;
                break;
            //lung
            case 1:
                position = player.transform.localPosition;
                if (position.x < -13)
                    position.x = -13;
                if (position.x > 13)
                    position.x = 13;
                if (position.z < -20)
                    position.z = -20;
                if (position.z > 20)
                    position.z = 20;
                break;
            //preHeart
            case 2:
                position = player.transform.localPosition;
                if (position.x < -13)
                    position.x = -13;
                if (position.x > 13)
                    position.x = 13;
                if (position.z < -11)
                    position.z = -11;
                if (position.z > 11)
                    position.z = 11;
                break;
            //Heart
            case 3:
                //none -> Restricted Area Set2
                break;
            //preColon
            case 4:
                position = player.transform.localPosition;
                if (position.x < -20)
                    position.x = -20;
                if (position.x > 20)
                    position.x = 20;
                if (position.z < -11)
                    position.z = -11;
                if (position.z > 11)
                    position.z = 11;
                break;
            //Colon
            case 5:
                //none -> Restricted Area Set
                break;
        }
    }
}
