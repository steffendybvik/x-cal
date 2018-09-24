using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : Interaction {

    private bool selected = false;

    public Color originalColor;
    public Color selectColor = Color.blue;

    public Renderer rend;

    public GameObject DisplayItem;

    void Start () {
       // DisplayItem.SetActive(false);
        originalColor = rend.material.color;
    }

    private void Update() {
        if (selected) {
        }
    }

    public override void Select() {
        //DisplayItem.SetActive(true);
        selected = true;
        rend.material.color = selectColor;
    }

    public override void Deselect() {
        //DisplayItem.SetActive(false);
        selected = false;
        rend.material.color = originalColor;
    }
}
