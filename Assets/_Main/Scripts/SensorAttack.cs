using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorAttack : MonoBehaviour
{
    private List<GameObject> targets = new List<GameObject>();
    [SerializeField]private Collider Sensor;
    [SerializeField]private string targetTag;

    private bool triggerActivate = false;

    private void OnTriggerEnter(Collider other) {
        if(triggerActivate && other.CompareTag(targetTag)){
            targets.Add(other.gameObject);
            Debug.Log(other);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(triggerActivate && other.CompareTag(targetTag)){
            targets.Remove(other.gameObject);
            Debug.Log(other);
        }
    }

    public void EndAttack(){
        triggerActivate = false;
        targets.Clear();
        Debug.Log("EndAttack");
    }

    public void StartAttack(){
        Debug.Log("startAttack");
        triggerActivate = true;
    }

    public List<GameObject> GetTargets(){
        return targets;
    }
}
