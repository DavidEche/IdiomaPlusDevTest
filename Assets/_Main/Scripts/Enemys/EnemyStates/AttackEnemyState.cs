using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemyState : MonoBehaviour, IEnemyState
{
    [SerializeField] private EnemyState state = EnemyState.attackPlayer;
    [SerializeField] private float AttackRange;
    [SerializeField] private GameObject player;
    [SerializeField] private EnemyChecker enemyChecker;
    [SerializeField] private int coldownAttackTime;
    private NavMeshAgent navMeshAgent;
    private IEnumerator AttackEnemy;


    private bool onAttack;

    public void EndState()
    {
        onAttack = false;
        navMeshAgent.isStopped = true;
        
    }

    public EnemyState GetState()
    {
        return state;
    }

    public void StartState()
    {
        if(navMeshAgent == null){
           navMeshAgent = GetComponent<NavMeshAgent>();
           player = enemyChecker.playerRef; 
        }
        navMeshAgent.isStopped = false;
        onAttack = true;
    }

    private void Update() {
        if(onAttack){
            navMeshAgent.SetDestination(player.transform.position);
            if(Vector3.Distance(player.transform.position, transform.position)<= AttackRange){
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer(){
        onAttack = false;
        navMeshAgent.isStopped = true;
        player.GetComponent<PlayerController>().TakeDamage(50);

    }

    IEnumerator CoolDownAttack(){
        yield return new WaitForSeconds(coldownAttackTime);
        onAttack = true;
    }
}
