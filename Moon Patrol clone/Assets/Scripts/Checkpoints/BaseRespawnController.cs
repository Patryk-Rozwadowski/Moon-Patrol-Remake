#pragma warning disable 649
using UnityEngine;

namespace Checkpoints {
    public class BaseRespawnController : MonoBehaviour {
        [SerializeField] private BaseRespawnSO sprite = null;
        [SerializeField] private GameObject vehicle = null;

        private void Start() {
            GetComponent<SpriteRenderer>().sprite = sprite.baseSprite;
            Instantiate(vehicle, gameObject.transform.transform);
        }
    }
}