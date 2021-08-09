using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerBase
{
    [SerializeField] private Transform defaultPlayerPosition;
    [SerializeField] private PlayerController player;
    [SerializeField] private Stats defaultStats;
    [SerializeField] private string sceneName;


    private void Start() {
        player.Initialize(defaultStats);
        player.gameObject.transform.position = defaultPlayerPosition.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToLobby(){
        SceneLoader.LoadLevel(sceneName);
    }
}
