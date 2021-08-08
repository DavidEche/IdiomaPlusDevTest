using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    EnemyState GetState();
    void StartState();
    void EndState();
}

public enum EnemyState
{
    patrol,
    attackPlayer,
}
