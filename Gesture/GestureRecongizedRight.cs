using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class GestureRecongizedRight : MonoBehaviour
{

    protected OVRSkeleton rightSkeleton;
    protected List<OVRBone> rightBones;
    private List<Gesture> saveGestures;

    [SerializeField] private GameObject rightHand;
    protected Gesture preGesture;
    protected Gesture currentGesture;
    protected GestureAction gestureAction;


    private bool canGrabbing;

    private string gestureRightName;

    //cprStart!!
    private bool cprStart = false;

    //thumb 인식 처리 변수
    private bool nextDialogue = true;

    void Start()
    {
        saveGestures = new List<Gesture>();
        LoadData();
        rightSkeleton = rightHand.GetComponent<OVRSkeleton>();
        gestureAction = this.gameObject.GetComponent<GestureAction>();
        preGesture = new Gesture("preGesture");
        gestureRightName = "nullGesture";
        canGrabbing = true;
    }

    public string GetGestureRightName()
    {
        return gestureRightName;
    }

    public bool GetCanGrabbing()
    {
        return canGrabbing;
    }

    public void CanGrabbingTurnOn()
    {
        canGrabbing = true;
    }

    public void CanGrabbingTurnOff()
    {
        canGrabbing = false;
    }

    public void CPRStartTurnOn()
    {
        cprStart = true;
    }

    public void CPRStartTurnOff()
    {
        cprStart = false;
    }

    IEnumerator ThumbLoading()
    {
        yield return new WaitForSeconds(0.5f);
        nextDialogue = true;
    }

    void FixedUpdate()
    {   
        rightBones = new List<OVRBone>(rightSkeleton.Bones);
        currentGesture = Recognized();
        gestureRightName = currentGesture.name;
        if (!currentGesture.name.Equals("nullGesture")&&!cprStart)
        {
            //Debug.Log("Right Gesture: " + currentGesture.name);

            if(currentGesture.name.Equals("Right_go_v1")|| currentGesture.name.Equals("Right_go_v2"))
            {
                gestureAction.GoStraight();
            }
            //v1 - 손가락 하나  v2-손가락 3개
            if (currentGesture.name.Equals("Right_back_v1"))
            {
                gestureAction.GoBack();
            }
            if (!preGesture.name.Equals("Right_thumb") && currentGesture.name.Equals("Right_thumb"))
            {
                if (nextDialogue)
                {
                    GameObject.FindGameObjectWithTag("DialogExist").GetComponent<DialogExist>().NextDialog();
                    nextDialogue = false;
                    StartCoroutine(ThumbLoading());
                }
                
            }

            if (currentGesture.name.Equals("Right_rock_v1") || currentGesture.name.Equals("Right_rock_v2"))
            {
                if (canGrabbing)
                {
                    //print("right rock");
                    rightHand.GetComponent<GrabRight>().GrabStart();
                }
            }
            

            if (!currentGesture.name.Equals("Right_rock_v1"))
            {
                if (!currentGesture.name.Equals("Right_rock_v2"))
                {
                    rightHand.GetComponent<GrabRight>().GrabFinish();
                }
            }

            if (currentGesture.name.Equals("Right_V"))
            {
                gestureAction.AttackAction("rightHand");
            }

            preGesture = currentGesture;
        }
        else
        {
            rightHand.GetComponent<GrabRight>().GrabFinish();
            GameObject.FindGameObjectWithTag("DialogExist").GetComponent<DialogExist>().StopDialog();
        }
    }

    public void LoadData()
    {
        string jsondata = File.ReadAllText(Application.dataPath + "/Scripts/Gesture/rightdata.json");
        var datas = JsonHelper.FromJson<Data>(jsondata);


        for (int i = 0; i < datas.Length; i++)
        {
            Gesture addGesture = new Gesture(datas[i].gesturename);
            List<Vector3> checkedPosition = new List<Vector3>();
            for (int j = 0; j < datas[i].bonepositions.Length; j++)
            {
                checkedPosition.Add(datas[i].bonepositions[j]);
            }
            addGesture.SetPosition(checkedPosition);
            saveGestures.Add(addGesture);
        }
    }

    private Gesture Recognized()
    {

        float checkedDist = 0.05f;
        float minDist = Mathf.Infinity;
        Gesture checkedGesture = new Gesture("nullGesture");

        foreach (var saveGesture in saveGestures)
        {
            bool discardGesture = false;
            float sumDist = 0.0f;
            for (int i = 2; i < rightBones.Count; i++)
            {
                Vector3 pos = rightHand.transform.InverseTransformPoint(rightBones[i].Transform.position);
                float distance = Vector3.Distance(saveGesture.positions[i], pos);

                if (distance > checkedDist)
                {
                    discardGesture = true;
                    break;
                }
                sumDist += distance;
            }

            if (!discardGesture && sumDist < minDist)
            {
                checkedGesture = saveGesture;
                minDist = sumDist;
            }
        }
        return checkedGesture;
    }
}