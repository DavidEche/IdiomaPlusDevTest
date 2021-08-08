using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : MonoBehaviour, IEnemyState
{
    [SerializeField] private EnemyState state;
    [SerializeField] private float patrolRange;
    [SerializeField] private int waitTimeMin, waitTimeMax;
    [SerializeField] private Vector3 positionSelected;
    private NavMeshAgent navMeshAgent;
    private Vector3 startPosition;

    private IEnumerator waitTime;
    private IEnumerator waitEndMove;
    public void EndState()
    {
        if(waitTime != null){
            StopCoroutine(waitTime);
        }
        if(waitEndMove != null){
            StopCoroutine(waitTime);
        }
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
           startPosition = transform.position;
        }
        Patrol();
    }

    public void Patrol(){
        positionSelected = SelectRandomPosition();
        navMeshAgent.SetDestination(positionSelected);
        waitEndMove = WaitEndMove();
        navMeshAgent.isStopped = false;
        StartCoroutine(waitEndMove);
    }

    private IEnumerator WaitEndMove(){
        while (Vector3.Distance(positionSelected,transform.position) > 1.0f)
        {
            yield return new WaitForEndOfFrame();
        }
        waitTime = WaitForNextMove();
        StartCoroutine(waitTime);
        waitEndMove = null;
    }

    private IEnumerator WaitForNextMove(){
        int waitTimeRandomValue = Random.Range(waitTimeMin, waitTimeMax);
        yield return new WaitForSeconds(waitTimeRandomValue);
        waitTime = null;
        Patrol();
    }

    private Vector3 SelectRandomPosition(){
        float randomX = UnityEngine.Random.Range(-patrolRange, patrolRange);
        float randomz = UnityEngine.Random.Range(-patrolRange, patrolRange);
        return new Vector3(startPosition.x + randomX, transform.position.y, startPosition.z + randomz);
    }
}
