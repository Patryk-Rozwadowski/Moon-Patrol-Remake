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
                var ufo = Instantiate(o, respawnPointsList[_randomSpawnIndex].transform.position, Quaternion.identity) ;
                ufo.transform.parent = aiWalls;
            }
        }
    
        void Start() {
            // TODO START MUSIC
            _randomSpawnIndex = Random.Range(0, respawnPointsList.Count);
            Debug.Log(respawnPointsList);
        }
    }
}