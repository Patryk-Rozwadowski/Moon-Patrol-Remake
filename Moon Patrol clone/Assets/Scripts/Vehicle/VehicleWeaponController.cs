using UnityEngine;

public class VehicleWeaponController : MonoBehaviour {
    public Transform firePointHorizon;
    public Transform firePointVertical;

    [SerializeField] private KeyCode horizonFireKey = KeyCode.None;
    [SerializeField] private KeyCode verticalFireKey = KeyCode.None;

    [SerializeField] private GameObject bulletVertical;
    [SerializeField] private GameObject bulletHorizon;
    
    private void Update() {
       Shoot();
    }
    
    private void Shoot() {
        if (Input.GetKeyDown(horizonFireKey)) {
            HorizontalShoot();
        }
        else if (Input.GetKeyDown(verticalFireKey)) {
            VerticalShoot();
        }
    }
    
    private void VerticalShoot() {
        GameObject bullet = Instantiate(bulletVertical, firePointVertical.position, Quaternion.identity);
        Destroy(bullet, 0.5f);
    }

    private void HorizontalShoot() {
        GameObject bullet = Instantiate(bulletHorizon, firePointHorizon.position, Quaternion.identity);
        Destroy(bullet, 0.8f);
    }
}