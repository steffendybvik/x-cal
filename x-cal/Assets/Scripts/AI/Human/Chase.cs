using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AiBehavior {

    private UnitData unitData;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        unitData.chaseUtility = 0.0f;
    }

    public override float GetUtiltyValues()
    {
        if (unitData.target != null) {

            if (unitData.enemyInRange && Vector3.Distance(unitData.target.transform.position, transform.position) > 1f) {
                unitData.chaseUtility = 0.6f;
            }
        } else {
            unitData.chaseUtility = 0.0f;
        }
        return unitData.chaseUtility;
    }

    public override void Execute()
    {
        unitData.ChangeState(UnitData.AISTATE.CHASE);


    }
}
