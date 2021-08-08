using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimatorController : MonoBehaviour
{
    public Action endAttack;
    public Action ondamage;
    public Action startAttack;

    [SerializeField] private Animator animator;

    public void MoveCharacter(bool inMove){
        animator.SetBool("Move", inMove);
    }

    public void PlayerAttack(){
        animator.SetTrigger("Attack");
    }

    public void EndAttack(){
        endAttack?.Invoke();
    }

    public void OnDamage(){
        ondamage?.Invoke();
    }

    public void StartAttack(){
        startAttack?.Invoke();
    }

}
