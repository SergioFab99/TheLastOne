using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    Rigidbody2D Player;
    EnemyPathfindign EnemyPathfindign;
    RaycastHit2D Hit;
    [SerializeField] private float AggroDistance;
    [SerializeField] private float AggroTime;
    EnemyStateManager Manager;
    private void Awake()
    {
        Manager = gameObject.GetComponent<EnemyStateManager>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        EnemyPathfindign = GetComponent<EnemyPathfindign>();
    }
    private void Update()
    {
        Vector2 Direction = new Vector2(Player.transform.position.x - transform.position.y, Player.transform.position.y - transform.position.y);
        Hit = Physics2D.Raycast(transform.position, Direction);
        Debug.DrawRay(transform.position, Direction);
        Debug.Log(Hit.collider.name);
        if (Hit.collider.gameObject.tag == "Player" && Hit.distance < AggroDistance)
        {
            Debug.Log("Player detected");
            Manager.SwitchState(Manager.AggroState);
        }
        else
        {
            Debug.Log("Player not detected");
            return;
        }
    }
}