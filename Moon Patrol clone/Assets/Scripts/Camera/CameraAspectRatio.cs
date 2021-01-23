using UnityEngine;

namespace Camera {
    public class CameraAspectRatio : MonoBehaviour {
        // Use this for initialization
        private void Start() {
            // set the desired aspect ratio (the values in this example are
            // hard-coded for 16:9, but you could make them into public
            // variables instead so you can set them at design time)
            var targetaspect = 4.0f / 3.0f;

            // determine the game window's current aspect ratio
            var windowaspect = Screen.width / (float) Screen.height;

            // current viewport height should be scaled by this amount
            var scaleheight = windowaspect / targetaspect;

            // obtain camera component so we can modify its viewport
            var camera = GetComponent<UnityEngine.Camera>();

            // if scaled height is less than current height, add letterbox
            if (scaleheight < 1.0f) {
                var rect = camera.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

                camera.rect = rect;
            }
            else {
                var scalewidth = 1.0f / scaleheight;

                var rect = camera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                camera.rect = rect;
            }
        }
    }
}