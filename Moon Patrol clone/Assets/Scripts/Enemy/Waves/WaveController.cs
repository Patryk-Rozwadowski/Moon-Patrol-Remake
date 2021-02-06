#pragma warning disable 649

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.WaveS {
    public class WaveController : MonoBehaviour {
        [SerializeField] private List<GameObject> respawnPointsList = new List<GameObject>();
        private int _randomSpawnIndex;

        public void WaveRespawn(List<GameObject> ufoWave) {
            var aiWalls = GameObject.Find("AiWalls").transform;
            FindObjectOfType<AudioManager>().Play("Enemy");
            foreach (var ufo in ufoWave.Select(o => Instantiate(o,
                respawnPointsList[Random.Range(0, respawnPointsList.Count)].transform.position, Quaternion.identity)))
                ufo.transform.parent = aiWalls;
        }
    }
}