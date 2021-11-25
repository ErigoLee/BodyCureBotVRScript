using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{

    //enemy colleagues
    private GameObject[] friends;
    private float friendPull;


    public ChaseState()
    {
        curSpeed = 10.0f;
        curRotSpeed = 5.0f;

        destPos = new Vector3();
        destPos = Vector3.zero;

        friendPull = 1.0f;
    }

    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        destPos = player.position;
        destPos.y = npc.position.y;
        float dist = Vector3.Distance(player.position,destPos);

        if(dist <= 10.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(2);
        }

    }

    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;
        destPos.y = npc.position.y;

        Vector3 direct = Vector3.zero;
        friends = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < friends.Length; i++)
        {
            if (friends[i] != npc.gameObject)
            {
                float distance = Vector3.Distance(friends[i].transform.position, npc.position);
                if (distance <= 1.0f)
                {
                    Vector3 avoidDist = npc.position - friends[i].transform.position;
                    //단위벡터화
                    //direct += avoidDist;
                    direct += avoidDist / (avoidDist.sqrMagnitude);
                    //avoidDist = avoidDist / (avoidDist.sqrMagnitude);
                    //npc.Translate(avoidDist * friendPull);
                }
            }
        }


        destPos += direct;
        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
        //npc.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed + direct * friendPull * Time.deltaTime);
    }

    public override void Attacking(GameObject npc_obj)
    {
        //nothing
    }
}
