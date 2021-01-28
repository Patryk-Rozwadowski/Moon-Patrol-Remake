using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelJOProgress : MonoBehaviour
{
    
    public GameObject vehicle;
    public Slider slider;
    
    void Update()
    {
        var calculate = 10 + (vehicle.transform.position.x / 402.9f) * 6;
        slider.value = calculate;
    }
}
