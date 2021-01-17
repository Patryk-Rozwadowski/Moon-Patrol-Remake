#pragma warning disable 649

using UnityEngine;
using UnityEngine.UI;

public class StageTime : MonoBehaviour {
    [SerializeField] private Text stageTimer;

    private float _timer;

    private void Start() {
        _timer = 0;
    }

    void Update() {
        _timer += Time.deltaTime;
        int seconds = Mathf.FloorToInt(_timer % 60F);
        stageTimer.text = seconds.ToString("000");
    }

}