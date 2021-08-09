using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : ManagerBase
{
    [SerializeField] private string nameLoadScene;

    public void PlayGame(){
        SceneLoader.LoadLevel(nameLoadScene);
    }
}
