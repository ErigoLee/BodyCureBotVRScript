using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Target : FSM
{
    
    public enum FSMStateID
    {
        None,
        Walking,
        Rest,
        Dead,
    }

    //npc state 상태 관련 변수
    public FSMStateID curState;
    private bool statecheck = false;

    private List<FSMState2> fsmstates;

    //scar
    private GameObject scar;

    //TargetManager
    private GameObject targetManager;

    //health
    private int health;

    //Target
    private Target target;

    //restricted
    private float min_x = -1.3f;
    private float max_x = 1.3f;
    private float min_z = -16.5f;
    private float max_z = -12.5f;


    private NavMeshAgent agent;

    //die state
    private bool dieState = false;

    //Animator script
    [SerializeField] private TargetAnim targetAnim;

    //timer
    private float elaspedTime = 0.0f;
    private float endTime = 2.0f;

    //effect Object
    [SerializeField] private GameObject effect;

    public void SetScar(GameObject _scar)
    {
        scar = _scar;
    }

    public void SetTargetManager(GameObject _targetManager)
    {
        targetManager = _targetManager;
    }


    public void SendDeadState()
    {
        targetAnim.Die();
        dieState = true;
        GameObject _effect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(_effect, 1.0f); ;
        targetManager.GetComponent<TargetManager>().DeleteObject(scar,gameObject);
    }


    public void SetDestPos()
    {
        //random seed부여하기
        float temp = Time.time * 100f;
        Random.InitState((int)temp);

        destPos = new Vector3();
        float x = Random.Range(min_x,max_x);
        float z = Random.Range(min_z,max_z);
        Vector3 newDestPos = new Vector3(x, 10.45f, z);

        float distance = Vector3.Distance(newDestPos,transform.position);
        if (distance <= 0.05f)
        {
            
            float _x = Random.Range(-0.05f,0.05f);
            float _z = Random.Range(-0.05f, 0.05f);
            float new_x = _x + x < min_x ? min_x : _x + x > max_x ? max_x : _x + x;
            float new_z = _z + z < min_z ? min_z : _z + z > max_z ? max_z : _z + z;
            destPos = new Vector3(new_x,10.45f,new_z);
        }
        else
        {
            destPos = newDestPos;
        }
        agent.SetDestination(destPos);
        
    }

    IEnumerator TranslateLoding(int index)
    {

        switch (index)
        {
            case 1:
                targetAnim.Walking();
                curState = FSMStateID.Walking;
                break;
            case 2:
                targetAnim.Rest();
                curState = FSMStateID.Rest;
                break;
            case 3:
                curState = FSMStateID.Dead;
                break;
        }
      
        if(curState == FSMStateID.Walking)
        {
            agent.speed = 2.5f;
        }
        else
        {
            agent.speed = 0.0f;
        }

        yield return new WaitForSeconds(2.0f);
        statecheck = false;
    }


    public void TranslateState(int index)
    {
        if (statecheck)
            return;
        statecheck = true;
        StartCoroutine(TranslateLoding(index));
    }

    protected override void Initialize()
    {
        curState = FSMStateID.Walking;
        target = GetComponent<Target>();
        health = 100;
        agent = GetComponent<NavMeshAgent>();
        SetDestPos();
        ConstructState();
    }

    public void ConstructState()
    {
        fsmstates = new List<FSMState2>();

        WalkingState walkingState = new WalkingState();
        fsmstates.Add(walkingState);
        RestState restState = new RestState();
        fsmstates.Add(restState);
        DeadState2 deadState2 = new DeadState2();
        fsmstates.Add(deadState2);
    }

    protected override void FSMUpdate()
    {

        if (dieState)
            return;

        switch (curState)
        {
            case FSMStateID.Walking:
                fsmstates[0].Reason(target);
                break;
            case FSMStateID.Rest:
                fsmstates[1].Reason(target);
                break;
            case FSMStateID.Dead:
                fsmstates[2].Reason(target);
                break;
        }

        if (health <= 0)
        {
            curState = FSMStateID.Dead;
        }

        //목적지 자동 변경 추가 -> 막히는 경우가 방지하기 위해 
        elaspedTime += Time.deltaTime;
        float distance = Vector3.Distance(destPos, transform.position);
        if (elaspedTime > endTime || distance <= 0.5f)
        {
            elaspedTime = 0.0f;
            target.SetDestPos();
        }
    }


    public void Attacked()
    {
        health = 0;
    }
}
