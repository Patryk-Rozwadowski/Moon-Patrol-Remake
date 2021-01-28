using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAEProgressBar : MonoBehaviour
{
    public GameObject vehicle;
    public Slider slider;

    void Update()
    {
        var calculate = vehicle.transform.position.x / 489f * 6;
        slider.value = calculate;
    }
}
