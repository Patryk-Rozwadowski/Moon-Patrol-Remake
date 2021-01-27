using System.Collections;
using UnityEngine;

namespace Text {
	public class TypeWriterEffect : MonoBehaviour {

		public float delay = 0.1f;
		public string fullText;
		private string currentText = "";

		void Start () {
			StartCoroutine(ShowText());
		}
	
		IEnumerator ShowText(){
			for(int i = 0; i < fullText.Length + 1; i++){
				currentText = fullText.Substring(0,i);
				// GetComponent<UnityEngine.UI.Text>().text = currentText;
				yield return new WaitForSeconds(delay);
			}
		}
	}
}
