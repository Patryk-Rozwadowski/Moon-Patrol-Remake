using UnityEngine;

namespace Checkpoints {
    [CreateAssetMenu(menuName = "ScriptableObjects/BaseRespawn")]
    public class BaseRespawnSO : ScriptableObject {
        [SerializeField] public Sprite baseSprite;
    }
}