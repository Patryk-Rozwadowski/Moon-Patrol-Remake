using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.Waves {
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
                foreach (var ufo in ufoWave.Select(o => Instantiate(o, transform.position, Quaternion.identity)))
                    ufo.transform.parent = _aiWalls;
            }
        }
    }
}