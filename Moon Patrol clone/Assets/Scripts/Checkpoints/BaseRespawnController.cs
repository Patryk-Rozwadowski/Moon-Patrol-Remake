#pragma warning disable 649

using UnityEngine;

public class BaseRespawnController : MonoBehaviour {
    [SerializeField] private BaseRespawnSO sprite;
    [SerializeField] private GameObject vehicle;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = sprite.baseSprite;
        Instantiate(vehicle, gameObject.transform.transform);
    }
}