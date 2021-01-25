using System;
using System.Collections.Generic;
using ScriptableObjects.Wave;
using UnityEngine;

namespace Enemy.Waves {
    public class WaveStarter : MonoBehaviour {
        // TODO rename Ufo_waveSO according to name convetion
        [SerializeField] private List<GameObject> ufoWave = new List<GameObject>();
        
        private Transform _aiWalls;
        private bool _started;

        private List<GameObject> _wave;
        private void Start() {
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.name != "WaveController") return;
            Debug.Log($"WAVE MANAGER HIT : {other.name}");

            if (_started == false) {
                _started = true;

                _aiWalls = GameObject.Find("AiWalls").transform;
                foreach (var o in ufoWave) {
                    var ufo = Instantiate(o, transform.position, Quaternion.identity) ;
                    // ufo.transform.parent = _aiWalls;
                    Debug.LogWarning(ufo.name);
                }
            }
           
        }
    }
}