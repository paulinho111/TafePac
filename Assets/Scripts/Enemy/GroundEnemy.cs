using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : AIagent
{
    [Header("Attack")]
    BulletManager Buletref;
    public Transform Muzzel;
    void Start()
    {
        Buletref = GameObject.FindGameObjectWithTag("E_AttackManager").GetComponent<BulletManager>();
    }

    // Update is called once per fram
    public override void Attack()
    {
        Buletref.GroundAttack(Muzzel, target);
    }
}
    