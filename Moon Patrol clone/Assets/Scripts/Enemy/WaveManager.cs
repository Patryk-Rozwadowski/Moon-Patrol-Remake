using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class WaveManager : MonoBehaviour {
        [SerializeField] private List<GameObject> ufoWave = new List<GameObject>();
        private Transform _aiWalls;
        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other);
            _aiWalls = GameObject.Find("AiWalls").transform;
            foreach (var o in ufoWave) {
                var ufo = Instantiate(o, transform.position, Quaternion.identity);
                ufo.transform.parent = _aiWalls;
            }
        }
    }
}