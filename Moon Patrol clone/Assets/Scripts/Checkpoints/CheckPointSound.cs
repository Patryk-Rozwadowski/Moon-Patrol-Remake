using Vehicle;
using UnityEngine;
using ScriptableObjects.Obstacles;
using Score;

public class CheckPointSound : MonoBehaviour
{
        public Collider2D jumpOverCollider2D;
        private bool isColliderIsUntouched = true;

        private void OnTriggerEnter2D(Collider2D obj)
        {
            VehicleController vehicle = obj.GetComponent<VehicleController>();
            if (vehicle != null)
            {
                FindObjectOfType<AudioManager>().Play("Checkpoint");
                isColliderIsUntouched = false;
            }
        }
}

