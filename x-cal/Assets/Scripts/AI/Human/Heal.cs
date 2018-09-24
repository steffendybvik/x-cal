using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : AiBehavior {

    private UnitData unitData;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        enemyHealth = GetComponent<EnemyHealth>();
        unitData.healUtility = 0.0f;
    }

    public override float GetUtiltyValues()
    {

        if (!unitData.enemyInRange && enemyHealth.health < enemyHealth.maxHealth) {
            unitData.healUtility = 0.6f;
        } else if (unitData.enemyInRange) {
            unitData.healUtility = 0.3f;
        } else if (enemyHealth.health >= enemyHealth.maxHealth) {
            unitData.healUtility = 0.0f;
        }

        return unitData.healUtility;
    }

    public override void Execute()
    {
        unitData.ChangeState(UnitData.AISTATE.HEAL);


    }
}
