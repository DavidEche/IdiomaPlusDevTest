using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimatorController playerAnimatorController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private Attack playerAttack;
    [SerializeField] private Stats playerStats;
    [SerializeField] public Action<Stats> updateStats;



    public Stats PlayerStats
    {
        get { return playerStats; } 
    } 

    public void Initialize(Stats baseStats){
        playerStats = baseStats;
        playerAttack.Initialize(playerAnimatorController);
        playerMovementController.Initialize(playerAnimatorController, playerAttack);
    }

    public void TakeDamage(int damage){
        playerStats.currentLive -= damage;
        updateStats?.Invoke(playerStats);
    }
}
