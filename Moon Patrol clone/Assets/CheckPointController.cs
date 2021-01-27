using UnityEngine;
using Vehicle;

public class CheckPointController : MonoBehaviour {
    private LevelController _levelController;

    private bool _isLoading;
    void Start() {
        _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        var vehicle = other.GetComponent<VehicleTireController>();

        if (vehicle != null && _isLoading == false) {
            _isLoading = true;
            Debug.Log("NEXT LEVEL");
            _levelController.NextLevel();
        }
    }
}