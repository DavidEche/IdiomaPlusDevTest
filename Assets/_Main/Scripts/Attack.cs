using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private string target;
    [SerializeField] private SensorAttack attackSensor;
    [SerializeField] private PlayerAnimatorController animatorController;

    public void Initialize(PlayerAnimatorController _animatorController){
        animatorController = _animatorController;
    }

    public void StartAttack(){
        attackSensor.StartAttack();
        Debug.Log("StartAttack");
        animatorController.ondamage += OnDamage;
        animatorController.endAttack += EndAttack;
    }

    private void OnDamage(){
        GameObject[] targets = attackSensor.GetTargets().ToArray();
        Debug.Log(targets.Length);
        if(targets.Length != 0){            
            for (int i = 0; i < target.Length; i++)
            {
                targets[i].GetComponent<Enemy>().TakeDamage(50);
            }
        }
    }

    public void EndAttack(){
        attackSensor.EndAttack();
        animatorController.ondamage -= OnDamage;
        animatorController.endAttack -= EndAttack;
    }

}
