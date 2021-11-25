using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVTransfer : MonoBehaviour
{
    private GameObject GR;
    [SerializeField] private GameObject centerCam;
    [SerializeField] private GameObject player;
    [SerializeField] private BVTransferGuide bvTransferGuide;
    [SerializeField] private HeartManager heartManager;
    private bool transferCan;
    private float speed = 5.0f;
    private Vector3 firstPos;
    private Quaternion firstRot;
    void Start()
    {
        firstPos = player.transform.localPosition;
        firstRot = player.transform.localRotation;
        transferCan = false;
        GR = GameObject.FindGameObjectWithTag("GR");
    }
    public void BVTransferStart()
    {
        GR.SetActive(false);
        bvTransferGuide.BVTransferExplain();
    }

    public void TransferCanTurnOn()
    {
        transferCan = true;
    }

    public void TransferCanTurnOff()
    {
        transferCan = false;
    }

    public void PreGoBack()
    {
        if (transferCan)
        {   
            transferCan = false;
            bvTransferGuide.FaildMissionExplain();
        }
        
    }  


    public void GoBack()
    {
        player.transform.localRotation = firstRot;
        player.transform.localPosition = firstPos;
    }

    void Update()
    {
        if (transferCan)
        {
            Vector3 position = player.transform.localPosition;
            if (position.z >= 38.0f) // 일정 장소에 도달시 비행 종료
            {
                transferCan = false;
                GR.SetActive(true);
                position.y = 0.0f;
                player.transform.localPosition = position;
                bvTransferGuide.SuccessMissionExplain();
                heartManager.EndStage0_1();
            }
            else
            {
                Vector3 centerCamDir = centerCam.transform.forward;
                centerCamDir.Normalize();
                player.transform.Translate(centerCamDir * speed * Time.deltaTime);
            }
        }
    }
}
