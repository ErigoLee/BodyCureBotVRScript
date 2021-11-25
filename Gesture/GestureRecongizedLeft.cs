using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class GestureRecongizedLeft : MonoBehaviour
{
    protected OVRSkeleton leftSkeleton;
    protected List<OVRBone> leftBones;
    private List<Gesture> saveGestures;

    [SerializeField] private GameObject leftHand;
    protected Gesture preGesture;
    protected Gesture currentGesture;
    protected GestureAction gestureAction;

    private string gestureLeftName;

    private bool canGrabbing;

    //cprStart!!
    private bool cprStart = false;

    void Start()
    {
        saveGestures = new List<Gesture>();
        LoadData();
        leftSkeleton = leftHand.GetComponent<OVRSkeleton>();
        gestureAction = this.gameObject.GetComponent<GestureAction>();
        preGesture = new Gesture("preGesture");
        gestureLeftName = "nullGesture";
        canGrabbing = true;
    }
    public string GetGestureLeftName()
    {
        return gestureLeftName;
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

    void FixedUpdate()
    {
        leftBones = new List<OVRBone>(leftSkeleton.Bones);
        currentGesture = Recognized();
        gestureLeftName = currentGesture.name;
        if (!currentGesture.name.Equals("nullGesture")&&!cprStart)
        {
            //Debug.Log("Left Gesture: " + currentGesture.name);


            if (currentGesture.name.Equals("Left_go_v1") || currentGesture.name.Equals("Left_go_v2"))
            {
                gestureAction.GoStraight();
            }
            //v1 - 손가락 하나  v2-손가락 3개
            if (currentGesture.name.Equals("Left_back_v1"))
            {
                gestureAction.GoBack();
            }
            if (currentGesture.name.Equals("Left_rock_v1") || currentGesture.name.Equals("Left_rock_v2"))
            {
                if (canGrabbing)
                {
                    leftHand.GetComponent<GrabLeft>().GrabStart();
                }
            }

            if (!currentGesture.name.Equals("Left_rock_v1"))
            {
                if (!currentGesture.name.Equals("Left_rock_v2"))
                {
                    leftHand.GetComponent<GrabLeft>().GrabFinish();
                }
            }

            if (currentGesture.name.Equals("Left_V"))
            {
                
                gestureAction.AttackAction("leftHand");
            }
           

            preGesture = currentGesture;
        }
        else
        {
            //print("not left rock");
            leftHand.GetComponent<GrabLeft>().GrabFinish();

        }
    }

    public void LoadData()
    {
        string jsondata = File.ReadAllText(Application.dataPath + "/Scripts/Gesture/leftdata.json");
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
            for (int i = 2; i < leftBones.Count; i++)
            {
                Vector3 pos = leftHand.transform.InverseTransformPoint(leftBones[i].Transform.position);
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