using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Stats stats;

    public void InitializeStats(Stats _stats){
        stats = _stats;
    }
}
