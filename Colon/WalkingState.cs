using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : FSMState2
{    
    public override void Reason(Target target)
    {
        //상태 변경
        
        int transferState = Random.Range(1, 3);
        target.TranslateState(transferState);
               
    }
}
