using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform defaultPlayerPosition;
    [SerializeField] private PlayerStats player;
    [SerializeField] private Stats defaultStats;


    private void Start() {
        player.InitializeStats(defaultStats);
        player.gameObject.transform.position = defaultPlayerPosition.position;
    }
}
