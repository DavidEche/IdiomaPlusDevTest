using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyChecker : MonoBehaviour
{
    public Action<bool> isplayerInRange;
    public GameObject playerRef;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            playerRef = other.gameObject;
            isplayerInRange?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("exitTrigger");
            isplayerInRange?.Invoke(false);
        }
    }
}
