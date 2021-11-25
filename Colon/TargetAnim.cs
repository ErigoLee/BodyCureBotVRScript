using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnim : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walking",true);
        anim.SetBool("Die",false);
    }

    public void Walking()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Walking", true);
        anim.SetBool("Die", false);
    }


    public void Rest()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Walking", false);
        anim.SetBool("Die", false);
    }


    public void Die()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Walking", false);
        anim.SetBool("Die", true);
    }


    
    void Update()
    {
        
    }
}
