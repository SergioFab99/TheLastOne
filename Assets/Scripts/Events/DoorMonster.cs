using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorMonster : BaseEvent
{
    private GameObject Prefab;
    GameObject Spawn;
    public override void EventTrigger(EventManager manager)
    {
        Prefab = Resources.Load<GameObject>("Enemy");
        Spawn = GameObject.Instantiate(Prefab);
        Spawn.transform.position = manager.transform.position;
        // Spawn.GetComponent<EnemyPathfindign>().ActivateSurprise();
        
    }
}
