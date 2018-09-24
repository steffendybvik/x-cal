using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    public float waited = 0f;
    public float frequency = 1f;

    List<AiBehavior> Ais = new List<AiBehavior>();

    void Start () {
        foreach (var ai in GetComponents<AiBehavior>())
            Ais.Add(ai);
	}
	

	void Update () {

        waited += Time.deltaTime;
        if ( waited < frequency) {
            return;
        }
        waited = 0f;
        float bestUtilityValue = float.MinValue;
        AiBehavior bestAi = null;

        foreach (var ai in Ais) {
            var aiValue = ai.GetUtiltyValues();
            if (aiValue > bestUtilityValue) {

                bestUtilityValue = aiValue;
                bestAi = ai;
            }
        bestAi.Execute();
        }

	}
}
