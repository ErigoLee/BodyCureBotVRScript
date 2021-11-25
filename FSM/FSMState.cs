using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{

    protected float curSpeed;

    protected float curRotSpeed;

    protected Vector3 destPos;

    public abstract void Reason(Transform player, Transform npc, GameObject npc_obj);
    public abstract void Act(Transform player, Transform npc);

    public abstract void Attacking(GameObject npc_obj);
}
