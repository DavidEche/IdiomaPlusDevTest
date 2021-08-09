using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerBase
{
    [SerializeField] private Transform defaultPlayerPosition;
    [SerializeField] private PlayerStats player;
    [SerializeField] private Stats defaultStats;
    [SerializeField] private string sceneName;


    private void Start() {
        player.InitializeStats(defaultStats);
        player.gameObject.transform.position = defaultPlayerPosition.position;
    }

    public void BackToLobby(){
        SceneLoader.LoadLevel(sceneName);
    }
}
