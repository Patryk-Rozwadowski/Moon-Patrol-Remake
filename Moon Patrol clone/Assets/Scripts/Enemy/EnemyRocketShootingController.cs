using Score;
using UnityEngine;

namespace Enemy {
    public class EnemyRocketShootingController : MonoBehaviour {
        [SerializeField] private GameObject enemyBulletRocket;
        [SerializeField] private GameObject verticalFirepoint;
        
        private GameObject _firepointTransform;
        private ScoreManager _scoreManager;

        void Start() {
            _scoreManager = GetComponent<ScoreManager>();

            Debug.Log(_firepointTransform);
            Instantiate(enemyBulletRocket, verticalFirepoint.transform.position, Quaternion.identity);

        }

        // Update is called once per frame
        void Update() {
        }
    }
}