using UnityEngine;

namespace Obstacles {
    
    public class HoleExplosionController : MonoBehaviour {
        void Start() {
            var position = transform.position;
            Destroy(gameObject.GetComponent<EdgeCollider2D>());
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4f,2);
            position = new Vector2(position.x, -5f);
        }
    }
}