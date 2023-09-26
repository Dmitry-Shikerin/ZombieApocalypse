using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilitaryToggleText : MonoBehaviour
{
    public string On = "On";
    public string Off = "Off";
    public void SetValue(bool value) {
        var text = GetComponent<Text>();
        text.text = value ? On : Off;
    }
}
