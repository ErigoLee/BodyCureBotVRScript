using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Idle",false);
    }


    public void IdleState()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Idle",true);
    }

    public void BreathState()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Idle",false);
    }
    
}
