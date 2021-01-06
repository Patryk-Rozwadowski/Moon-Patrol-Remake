using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforward2 : MonoBehaviour
{
[SerializeField] private float speed = 200;
    // Update is called once per frame
    void Update()
    {
 // Move the object to the right relative to the camera 1 unit/second.
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
