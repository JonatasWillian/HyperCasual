using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextvalue;

    void Start()
    {
        uiTextvalue.text = soInt.value.ToString();    
    }

    void Update()
    {
        uiTextvalue.text = soInt.value.ToString();
    }
}
