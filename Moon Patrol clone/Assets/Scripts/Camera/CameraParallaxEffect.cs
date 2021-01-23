using UnityEngine;

namespace Camera {
    public class CameraParallaxEffect : MonoBehaviour {
        public GameObject cam;
        public float parallaxEffect;
        private float length, startpos;
    
        private void Start() {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    
        private void FixedUpdate() {
            float temp = cam.transform.position.x * (1 - parallaxEffect);
            float dist = cam.transform.position.x * parallaxEffect;

            var position = transform.position;
            position = new Vector3(startpos + dist, position.y, position.z);
            transform.position = position;

            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }
    }
}