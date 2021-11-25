using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState3 : FSMState
{

    //attackTool

    public GameObject attackTool;

    //attack 변수
    private float attackRate;
    private float elapsedTime; //Timer

    //enemy colleagues
    private GameObject[] friends;
    private float friendPull;

    public AttackState3(GameObject gameObject)
    {
        curSpeed = 10.0f;
        curRotSpeed = 5.0f;

        destPos = new Vector3();
        destPos = Vector3.zero;

        attackTool = gameObject;

        elapsedTime = 0.0f;
        attackRate = 3.0f;
        friendPull = 0.5f;
    }

    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        //y값을 고려하지 않기 위해서
        destPos = player.position;
        destPos.y = npc.position.y;

        float dist = Vector3.Distance(npc.position, destPos);

        if (dist >= 20.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(1); // curState -> chase로 변경
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //y값을 고려하지 않기 위해서
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
                    //direct += avoidDist;
                    direct += avoidDist / (avoidDist.sqrMagnitude);
                    //avoidDist = avoidDist / (avoidDist.sqrMagnitude);
                    //npc.Translate(avoidDist * friendPull);
                }
            }
        }
        destPos += direct;
        float dist = Vector3.Distance(npc.position, destPos);
        if (dist > 8.0f)
        {
            //Vector3 direction = Vector3.forward + direct;
            //direction = direction.normalized;
            //npc.Translate(direction * curSpeed * Time.deltaTime);
            npc.Translate(Vector3.forward * Time.deltaTime * curSpeed + direct * friendPull * Time.deltaTime);
            //npc.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        }
        else
        {
            if(direct!=Vector3.zero)
                npc.Translate(direct * friendPull * Time.deltaTime);
            //npc.Translate(Vector3.forward * curSpeed * Time.deltaTime);
            //Vector3 direction = direct;
            //direction = direction.normalized;
            //npc.Translate(direction * curSpeed * Time.deltaTime);
            //npc.Translate(direct * friendPull * Time.deltaTime);
        }
        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
    }

    public override void Attacking(GameObject npc_obj)
    {
        Transform attackSpawnPoint = npc_obj.transform.GetChild(7).transform;
        if (elapsedTime >= attackRate)
        {
            npc_obj.GetComponent<NpcFSM>().AttackingAnim();
            GameObject instance = Instantiate(attackTool, npc_obj.transform.position, npc_obj.transform.rotation);
            instance.GetComponent<Bullet>().npcStage = 3;
            elapsedTime = 0.0f;
        }
        else
        {
            if(elapsedTime == 0.0f)
                npc_obj.GetComponent<NpcFSM>().IdleAnim();
            elapsedTime += Time.deltaTime;
        }
    }
}
