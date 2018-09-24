using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {

    private bool selected = false;
    public bool swap = false;

    public bool _selected {
        get {
            return selected;
        }
    }

    public void Select() {
        selected = true;
        foreach (var selection in GetComponents<Interaction>()) {
            selection.Select();
        }
    }

    public void Deselect() {
        selected = false;
        foreach (var selection in GetComponents<Interaction>()) {
            selection.Deselect();
        }
    }

    private void Update() {
        if (swap) {
            swap = false;
            if (selected) {
                Deselect();
            } else {
                Select();
            }
        }
    }
}
