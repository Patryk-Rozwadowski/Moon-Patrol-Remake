#pragma warning disable 649

using UnityEngine;

namespace ScriptableObjects.Player {
    [CreateAssetMenu(menuName = "ScriptableObjects/Player/parameters")]
    public class PlayerParamsSO : ScriptableObject {
        [SerializeField] public float
            playerSpeed,
            jumpTimeInAir,
            jumpHeightAccelerate,
            jumpHorizontalSpeed,
            minimalSpeed = 3f,
            maxSpeed = 6f,
            speedStep = 2f;
    }
}