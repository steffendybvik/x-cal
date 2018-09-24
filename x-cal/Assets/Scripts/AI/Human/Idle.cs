using UnityEngine;

public class Idle : AiBehavior {

    

    private UnitData unitData;

    private void Start() {
        unitData = GetComponent<UnitData>();
    }

    public override float GetUtiltyValues() {
        return unitData.idleUtility;
    }

    public override void Execute() {
        unitData.ChangeState(UnitData.AISTATE.IDLE);

        
    }
}
