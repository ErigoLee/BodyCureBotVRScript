using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRAnim : MonoBehaviour
{
    private Animator anim;   
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Bump",false);
    }


    public void Bumping()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Bump",true);
    }

    public void Idle()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Bump",false);
    }

}
