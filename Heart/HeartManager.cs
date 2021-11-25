using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    //stage0
    [SerializeField] private GameObject bvTransfer;
    [SerializeField] private GameObject bvTransferGuide;
    //stage1
    [SerializeField] private GameObject stand;
    [SerializeField] private GameObject standDetector;
    //stage2
    [SerializeField] private GameObject newStand;
    //portal
    [SerializeField] private GameObject portal;
    //player
    [SerializeField] private GameObject player;
    //stentGuideEffect
    [SerializeField] private GameObject stentGuideEffect;
    [SerializeField] private GameObject stentDetectorGuideEffect;
    //길안내
    [SerializeField] private GameObject heart2_line_1;
    [SerializeField] private GameObject heart2_line_2;
    [SerializeField] private GameObject heart2_line_3;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private OVRGrabbable stentGrabbable;
    private int step = 0;
    void Start()
    {
        portal.SetActive(false);
        //stage0
        bvTransfer.SetActive(false);
        bvTransferGuide.SetActive(false);
        //stage1
        stand.SetActive(false);
        standDetector.SetActive(false);
        //stage2
        newStand.SetActive(false);
        //stentGuideEffect
        stentGuideEffect.SetActive(false);
        stentDetectorGuideEffect.SetActive(false);
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        stentGrabbable = stand.GetComponent<OVRGrabbable>();
        //길안내
        heart2_line_1.SetActive(false);
        heart2_line_2.SetActive(false);
        heart2_line_3.SetActive(false);
        StartStage0();
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.0f);
        bvTransfer.GetComponent<BVTransfer>().BVTransferStart();
    }

    public void StartStage0()
    {
        step = 0;
        bvTransferGuide.SetActive(true);
        bvTransfer.SetActive(true);
        StartCoroutine(Loading());
    }

    public void EndStage0_1()
    {
        Destroy(bvTransfer);
    }

    public void EndStage0_2()
    {
        Destroy(bvTransferGuide);
        StartStage1();
    }

    public void StartStage1()
    {
        step = 1;
        stand.SetActive(true);
        standDetector.SetActive(true);
        stentGuideEffect.SetActive(true);
        stentDetectorGuideEffect.SetActive(true);
        //길안내
        heart2_line_1.SetActive(true);
    }

    public void EndStage1()
    {
        stentDetectorGuideEffect.SetActive(false);
        standDetector.SetActive(false);
        //길안내
        heart2_line_2.SetActive(false);
        StartStage2();
    }

    IEnumerator PlayerMove()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.localPosition = new Vector3(0, 0, 37f);
    }

    public void StartStage2()
    {
        step = 2;
        StartCoroutine(PlayerMove());
        newStand.SetActive(true);
        newStand.GetComponent<NewStent>().InitialPos();
    }

    public void EndStage2()
    {
        HeartEnding();
    }

    public void HeartEnding()
    {
        portal.SetActive(true);
        //길안내
        heart2_line_3.SetActive(true);
    }

    void Update()
    {
        if(step == 1)
        {
            if (leftHand.isGrabbing)
            {
                OVRGrabbable grabbable = leftHand.grabbedObject;
                if(stentGrabbable != null)
                {
                    if(stentGrabbable == grabbable && stentGuideEffect.activeSelf == true)
                    {
                        stentGuideEffect.SetActive(false);
                        //길안내
                        heart2_line_1.SetActive(false);
                        heart2_line_2.SetActive(true);
                    }
                }
            }
            if (rightHand.isGrabbing)
            {
                OVRGrabbable grabbable = rightHand.grabbedObject;
                if(stentGrabbable != null)
                {
                    if(stentGrabbable == grabbable && stentGuideEffect.activeSelf == true)
                    {
                        stentGuideEffect.SetActive(false);
                        //길안내
                        heart2_line_1.SetActive(false);
                        heart2_line_2.SetActive(true);
                    }
                }
            }
        }
    }
}
