using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int live;
    [SerializeField] private EnemyChecker enemyChecker;
    [SerializeField] private IEnemyState[] enemyStates;
    [SerializeField] private IEnemyState currentState;
    [SerializeField] private EnemyState defaultState;


    private Animator animator;


    private void Start() {
        enemyStates = GetComponents<IEnemyState>();
        StateMachine(defaultState);
        enemyChecker.isplayerInRange += CheckerRange;
    }

    public virtual void StateMachine(EnemyState newState){
        if(currentState != null){
            currentState.EndState();
        }
        for (var i = 0; i < enemyStates.Length; i++)
        {
            if(enemyStates[i].GetState() == newState){
                enemyStates[i].StartState();
                break;
            }
        }        
    }

    private void CheckerRange(bool inOrExitRange){
        if(inOrExitRange){
            StateMachine(EnemyState.attackPlayer);
        }else{
            StateMachine(defaultState);
        }
    }

}
