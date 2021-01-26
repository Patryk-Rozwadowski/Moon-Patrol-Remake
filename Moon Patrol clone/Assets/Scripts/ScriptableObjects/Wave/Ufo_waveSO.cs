using System.Collections.Generic;
using UnityEngine;

// TODO change WaveStarter data with this SO
namespace ScriptableObjects.Wave {
    [CreateAssetMenu(menuName = "ufo wave")]
    public class UfoWaveSo : ScriptableObject {
        [SerializeField] private List<GameObject> ufoWave = new List<GameObject>();
    }
}