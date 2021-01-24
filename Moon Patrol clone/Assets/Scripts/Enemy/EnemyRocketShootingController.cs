using Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyBulletRocket;
        [SerializeField] private GameObject firepoint;
        
        private GameObject _firepointTransform;
        private ScoreManager _scoreManager;

        void Start() {
            _scoreManager = GetComponent<ScoreManager>();
            // Instantiate(enemyBulletRocket, firepoint.transform.position, Quaternion.identity);

        }

        // Update is called once per frame
        void Update() {
        }
    }
}