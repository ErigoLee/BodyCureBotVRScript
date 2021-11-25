using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private GameObject npcFloor;
    [SerializeField] private GameObject handle;
    [SerializeField] private GameObject npc;
    [SerializeField] private Rope rope;
    [SerializeField] private ColonManager colonManager;
    private bool deleteWork;
    private bool checking;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    //rope
    void Start()
    {
        deleteWork = false;
        checking = false;
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
    }

    
    IEnumerator RopeObjectsDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(handle);
        Destroy(npc);
        //ropechild grab candidate delete
        List<GameObject> ropeChildren = rope.GetRopeChildren();
        if(ropeChildren.Count > 0)
        {
            gestureRecongizedLeft.CanGrabbingTurnOff(); //grab인식 끔
            gestureRecongizedRight.CanGrabbingTurnOff(); 
            foreach(GameObject ropeChild in ropeChildren)
            {
                if (leftHand.isGrabbing)
                {
                    if(leftHand.grabbedObject.gameObject == ropeChild)
                    {
                        leftHand.InsideObjectTurnOff();                        
                    }
                }
                if (rightHand.isGrabbing)
                {
                    if(rightHand.grabbedObject.gameObject == ropeChild)
                    {
                        rightHand.InsideObjectTurnOff();
                    }
                }
                GameObject detector = ropeChild.transform.GetChild(0).gameObject;
                detector.SetActive(false);
                OVRGrabbable grabbable = ropeChild.GetComponent<OVRGrabbable>();
                leftHand.RemoveCandidates(grabbable);
                rightHand.RemoveCandidates(grabbable);
            }
            leftHand.InsideObjectTurnOff();
            rightHand.InsideObjectTurnOff();
            gestureRecongizedLeft.CanGrabbingTurnOn();
            gestureRecongizedRight.CanGrabbingTurnOn();
        }
        Destroy(rope.GetRope());
        colonManager.EndStage0_2();
    }

    public void CheckingTurnOn()
    {
        print("checking turn on");
        checking = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            if (!deleteWork)
            {
                print("npc detect!");
                Destroy(npcFloor);
                StartCoroutine(RopeObjectsDestroy());
                deleteWork = true;
            }
        }
        if (checking)
        {
            print("check!!");
            List<GameObject> ropeObjects = rope.GetRopeChildren();
            if (ropeObjects == null)
                return;
            if (ropeObjects.Count <= 10)
                return;
            for (int i = 0; i < ropeObjects.Count; i++)
            {
                if (i < 14)
                    continue;
                if (ropeObjects[i] == other.gameObject)
                {
                    print("enter!!");
                    rope.DeleteRopeChild();
                    rope.DeleteRopeChild();
                    checking = false;
                    break;
                }
            }

        }
    }
}
