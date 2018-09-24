using UnityEngine;

public abstract class AiBehavior : MonoBehaviour {

    public float TimePassed = 0;
    public abstract float GetUtiltyValues();
    public abstract void Execute();
}
