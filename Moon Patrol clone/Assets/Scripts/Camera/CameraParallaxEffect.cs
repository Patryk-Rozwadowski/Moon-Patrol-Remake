using UnityEngine;

public class CameraParallaxEffect : MonoBehaviour {
    public GameObject cam;
    public float parallaxEffect;
    private float length, startpos;

    // Start is called before the first frame update
    private void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        var temp = cam.transform.position.x * (1 - parallaxEffect);
        var dist = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}