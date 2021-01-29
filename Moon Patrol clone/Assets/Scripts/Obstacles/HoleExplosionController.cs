using UnityEngine;

namespace Obstacles {
    
    public class HoleExplosionController : MonoBehaviour {

        void Start() {
            Destroy(gameObject.GetComponent<EdgeCollider2D>());
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(4f,2);
            transform.position = new Vector2(transform.position.x, -5f);
        }
    }
}