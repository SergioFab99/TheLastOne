using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRestingState : EnemyBaseState
{
    public AudioClip PlayerDetected;
    public override void EnterState(EnemyStateManager manager)
    {
        manager.PathFinder.Target = GameObject.Find("Player").transform;
        PlayerDetected = Resources.Load<AudioClip>("Efecto_de_sonido_Sorpresa_320_kbps.mp3");
        Debug.Log("Entered Restingstate");
    }
    public override void ExitState(EnemyStateManager manager)
    {
        manager.Audiosource().PlayOneShot(PlayerDetected);
    }
    public override void UpdateState(EnemyStateManager manager)
    {

    }
}
