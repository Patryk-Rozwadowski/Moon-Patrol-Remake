using System.Collections;
using UnityEngine;

// TODO REMOVE
namespace Text {
    public class TypeWriterEffect : MonoBehaviour {
        public float delay = 0.1f;
        public string fullText;
        private string currentText = "";

        private void Start() {
            StartCoroutine(ShowText());
        }

        private IEnumerator ShowText() {
            for (var i = 0; i < fullText.Length + 1; i++) {
                currentText = fullText.Substring(0, i);
                // GetComponent<UnityEngine.UI.Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}