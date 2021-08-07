using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int live;
    private Vector3 startPosition;
    public NavMeshAgent navMeshAgent;
}
