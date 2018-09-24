using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : AiBehavior {

    private UnitData unitData;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        enemyHealth = GetComponent<EnemyHealth>();
        unitData.fleeUtility = 0.0f;
    }

    public override float GetUtiltyValues()
    {

        if (unitData.enemyInRange && enemyHealth.health < 60f) {
            unitData.fleeUtility = 0.9f;
        } else {

            unitData.fleeUtility = 0.0f;
        }

        return unitData.fleeUtility;
    }

    public override void Execute()
    {
        unitData.ChangeState(UnitData.AISTATE.FLEE);


    }
}
