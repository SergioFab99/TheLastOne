using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState CurrentState;
    public EnemyBaseState AggroState = new EnemyAggroState();
    public EnemyBaseState RestingState = new EnemyRestingState();
    public EnemyPathfindign PathFinder;
    SpriteRenderer SpriteRenderer;

    void Start()
    {
        CurrentState = RestingState; 
        PathFinder = GetComponent<EnemyPathfindign>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
        if(CurrentState == AggroState)
        {
            SpriteRenderer.color = Color.red;
        }
        if(CurrentState == RestingState)
        {
            SpriteRenderer.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchState(AggroState);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchState(RestingState);
        }
    }
    void SwitchState(EnemyBaseState NewState)
    {
        CurrentState.ExitState(this);
        CurrentState= NewState;
        CurrentState.EnterState(this);
    }
}
