using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class MilitaryToggleSlider : MonoBehaviour
{
    public void SetValue(bool value) {
        var animator = GetComponent<Animator>();
        animator.StopPlayback();
        animator.Play(value ? "Enable" : "Disable");
    }
}
