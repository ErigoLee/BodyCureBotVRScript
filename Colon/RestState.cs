using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : FSMState2
{
    public override void Reason(Target target)
    {
        //상태 변경 -> walking 상태로
        target.TranslateState(1);
    }
}
