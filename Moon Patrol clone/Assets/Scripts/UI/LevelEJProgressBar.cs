using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEJProgressBar : MonoBehaviour
{

    public GameObject vehicle;
    public Slider slider;

    void Update()
    {
        var calculate = 5 + (vehicle.transform.position.x / 479.7f) * 6;
        slider.value = calculate;
    }
}

