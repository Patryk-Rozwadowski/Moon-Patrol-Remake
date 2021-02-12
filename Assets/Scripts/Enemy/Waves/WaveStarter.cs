using System.Collections.Generic;
using Enemy.WaveS;
using UnityEngine;

namespace Enemy.Waves {
    public class WaveStarter : MonoBehaviour {
        [SerializeField] private List<GameObject> ufoWave = new List<GameObject>();
        private Transform _aiWalls;
        private bool _started;

        private WaveController _waveController;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.name != "WaveController") return;
            if (_started == false) {
                _started = true;
                _waveController = other.GetComponent<WaveController>();
                _waveController.WaveRespawn(ufoWave);
            }
        }
    }
}