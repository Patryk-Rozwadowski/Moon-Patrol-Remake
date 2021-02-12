using UnityEngine;

public class ShaderEffectBleedingColors : MonoBehaviour {
    public float intensity = 3;
    public float shift = 0.5f;
    private Material material;

    void Awake() {
        material = new Material(Shader.Find("Hidden/BleedingColors"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        material.SetFloat("_Intensity", intensity);
        material.SetFloat("_ValueX", shift);
        Graphics.Blit(source, destination, material);
    }
}