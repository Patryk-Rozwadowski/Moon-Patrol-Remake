#pragma warning disable 649
using System.Collections.Generic;
using Enemy.Waves;
using Projectiles.Enemy;
using ScriptableObjects.Wave;
using UnityEngine;

public class WaveController : MonoBehaviour {
    [SerializeField] private List<GameObject> respawnPointsList = new List<GameObject>();
    // list of spawn points in ai walls

    private int _randomSpawnIndex;
    
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