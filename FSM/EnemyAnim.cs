using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Running",true);
        anim.SetBool("Die",false);
        anim.SetBool("Idle",false);
    }

    public void SetRunning()
    {
        if(anim==null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Running",true);
        anim.SetBool("Die",false);
        anim.SetBool("Idle",false);
    }

    public void SetAttacking()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Running",false);
        anim.SetBool("Die",false);
        anim.SetBool("Idle",false);
    }

    public void SetIdle()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Running", false);
        anim.SetBool("Die", false);
        anim.SetBool("Idle", true);
    }

    public void SetDie()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Running",false);
        anim.SetBool("Die",true);
        anim.SetBool("Idle",false);
    }

}
