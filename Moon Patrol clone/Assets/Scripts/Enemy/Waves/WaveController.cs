#pragma warning disable 649
using System.Collections.Generic;
using Enemy.Waves;
using UnityEngine;

namespace Enemy.WaveS {
    public class WaveController : MonoBehaviour {
        [SerializeField] private List<GameObject> respawnPointsList = new List<GameObject>();
    
        private int _randomSpawnIndex;
        public void WaveRespawn(List<GameObject> ufoWave) {
            var aiWalls = GameObject.Find("AiWalls").transform;
            foreach (var o in ufoWave) {
                var ufo = Instantiate(o, transform.position, Quaternion.identity) ;
                ufo.transform.parent = aiWalls;
            }
        }
    
        void Start() {
            // TODO START MUSIC
            // respawn wave in random spawn point - ontriggerenter
            _randomSpawnIndex = Random.Range(0, respawnPointsList.Count);
            Debug.Log(respawnPointsList);
        }
    

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other.name);

            var waveStarter = other.GetComponent<WaveStarter>();

            if (waveStarter != null) {
                Debug.Log($"{waveStarter.name} ");
                Debug.Log($"{respawnPointsList[_randomSpawnIndex]}");
            
            }
        }
    }
}