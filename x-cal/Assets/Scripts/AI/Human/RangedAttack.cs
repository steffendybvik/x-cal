using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AiBehavior {

    private UnitData unitData;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        unitData.rangedAttackUtility = 0.0f;
    }

    public override float GetUtiltyValues()
    {
        return unitData.rangedAttackUtility;
    }

    public override void Execute()
    {
        unitData.ChangeState(UnitData.AISTATE.RANGEDATTACK);


    }
}
