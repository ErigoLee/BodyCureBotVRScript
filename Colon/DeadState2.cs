using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState2 : FSMState2
{
    public override void Reason(Target target)
    {
        target.SendDeadState();
    }
}
