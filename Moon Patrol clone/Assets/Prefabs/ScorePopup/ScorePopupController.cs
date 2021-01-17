using TMPro;
using UnityEngine;

public class ScorePopupController : MonoBehaviour {
    private TextMeshPro _textMesh;
    

    private void Awake() {
        _textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int scoreAmout) {
        _textMesh.SetText(scoreAmout.ToString());
        Destroy(gameObject, 0.5f);
    }
}