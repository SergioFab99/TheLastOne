using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRestingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.PathFinder.Target = GameObject.Find("Target").transform;
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {

    }
}
