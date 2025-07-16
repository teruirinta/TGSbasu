using UnityEngine;

public class Fog : MonoBehaviour
{

    public float minDepth = 0f;
    public float maxDepth = -50f;
    public float minDensity = 0.001f;
    public float maxDensity = 0.05f;

    public float noiseScale = 0.1f;      // ノイズの空間スケール
    public float noiseSpeed = 0.5f;      // ノイズの時間変化速度
    public float noiseIntensity = 0.01f; // ノイズの強さ


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float depth = transform.position.y;
        float t = Mathf.InverseLerp(minDepth, maxDepth, depth);
        float baseDensity = Mathf.Lerp(minDensity, maxDensity, t);

        // Perlinノイズによる揺らぎを加える
        float noise = Mathf.PerlinNoise(Time.time * noiseSpeed, transform.position.x * noiseScale);
        float finalDensity = baseDensity + (noise - 0.5f) * 2f * noiseIntensity;

        RenderSettings.fogDensity = Mathf.Clamp(finalDensity, minDensity, maxDensity);

    }
}
