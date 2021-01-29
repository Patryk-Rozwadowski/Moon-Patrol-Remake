using UnityEngine;

namespace Camera {
    public class CameraParallaxEffect : MonoBehaviour {
        [SerializeField] private float parallaxEffect;

        private GameObject _cam;
        private float length, startpos;
    
        private void Start() {
            _cam = GameObject.Find("Main Camera").gameObject;
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    
        private void Update() {
            var temp = _cam.transform.position.x * (1 - parallaxEffect);
            var dist = _cam.transform.position.x * parallaxEffect;

            var position = transform.position;
            position = new Vector3(startpos + dist, position.y, position.z);
            transform.position = position;

            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }
    }
}