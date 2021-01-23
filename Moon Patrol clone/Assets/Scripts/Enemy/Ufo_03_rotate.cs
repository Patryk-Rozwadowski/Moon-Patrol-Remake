using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 180 * Time.deltaTime); //rotates 180 degrees per second around z axis
    }
}