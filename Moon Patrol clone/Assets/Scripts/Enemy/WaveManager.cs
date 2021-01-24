using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class WaveManager : MonoBehaviour {
        [SerializeField] private List<GameObject> ufoWave = new List<GameObject>();
        private Transform _aiWalls;
        private bool _started;
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.name != "WaveController") return;
            Debug.Log($"WAVE MANAGER HIT : {other.name}");

            if (_started == false) {
                _started = true;

                _aiWalls = GameObject.Find("AiWalls").transform;
                foreach (var o in ufoWave) {
                    var ufo = Instantiate(o, transform.position, Quaternion.identity);
                    ufo.transform.parent = _aiWalls;
                }
            }
           
        }
    }
}