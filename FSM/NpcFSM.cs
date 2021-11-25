using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcFSM : FSM
{
    public enum FSMStateID
    {
        None,
        Chase,
        Attack,
        Dead,
    }

    //npc state 상태 관련 변수
    public FSMStateID curState;

    private List<FSMState> fsmstates;

    //health
    private int health;
    

    //stage  1-weak npc/ 2-middle npc/ 3-strong npc
    public int npcStage;

    //attck
    public GameObject attackTool;

    //Animator Script
    private EnemyAnim enemyAnim;

    //deadState
    private bool deadState = false;


    public void TranslateState(int index)
    {
        if(index == 1)
        {
            RunningAnim();
            curState = FSMStateID.Chase;
        }
        else if(index == 2)
        {
            curState = FSMStateID.Attack;
        }
        else if(index == 3)
        {
            curState = FSMStateID.Dead;
        }
    }

    public void AttackingAnim()
    {
        enemyAnim.SetAttacking();
    }

    public void DieAnim()
    {
        enemyAnim.SetDie();
    }
    public void RunningAnim()
    {
        enemyAnim.SetRunning();
    }
    

    public void IdleAnim()
    {
        enemyAnim.SetIdle();
    }


    protected override void Initialize()
    {
        curState = FSMStateID.Chase;
        health = 100;
        

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        
        enemyAnim = GetComponent<EnemyAnim>();

        enemyAnim.SetRunning(); //because curState가 FSMStateID.Chase이므로,


        if (!playerTransform)
            print("Player doesn't exist!!");
        ConstructState();

    }

    public void ConstructState()
    {
        fsmstates = new List<FSMState>();

        ChaseState chaseState = new ChaseState();
        fsmstates.Add(chaseState);
        if(npcStage == 1)
        {
            AttackState1 attackState = new AttackState1(attackTool);
            fsmstates.Add(attackState);
        }
        else if(npcStage == 2)
        {
            AttackState2 attackState2 = new AttackState2(attackTool);
            fsmstates.Add(attackState2);
        }
        else
        {
            AttackState3 attackState3 = new AttackState3(attackTool);
            fsmstates.Add(attackState3);
        }
        DeadState deadstate = new DeadState();
        fsmstates.Add(deadstate);
    }

    protected override void FSMUpdate()
    {
        if (deadState)
            return;

        switch(curState)
        {
            case FSMStateID.Chase:
                fsmstates[0].Reason(playerTransform,transform, gameObject);
                fsmstates[0].Act(playerTransform, transform);
                break;
            case FSMStateID.Attack:
                fsmstates[1].Reason(playerTransform,transform, gameObject);
                fsmstates[1].Act(playerTransform, transform);
                fsmstates[1].Attacking(gameObject);
                break;
            case FSMStateID.Dead:
                fsmstates[2].Reason(playerTransform,transform, gameObject);
                deadState = true;
                DieAnim();
                break;
        }

        

        if (health <= 0)
            curState = FSMStateID.Dead;
    }

    public void Attacked()
    {
        if (health > 0)
        {
            health -= 100;
            print("Attacked!"+health);
        }
            
    }
    
}
