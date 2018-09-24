using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: AiBehavior {

    private UnitData unitData;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        unitData.attackUtility = 0.0f;
    }

    public override float GetUtiltyValues()
    {

        if (unitData.target != null)
        {

            if (unitData.enemyInRange && Vector3.Distance(unitData.target.transform.position, transform.position) < 1.5f)
            {
                unitData.attackUtility = 0.7f;
            }
        }
        else
        {
            unitData.attackUtility = 0.0f;
        }

        return unitData.attackUtility;
    }

    public override void Execute()
    {
        unitData.ChangeState(UnitData.AISTATE.ATTACK);


    }
}
