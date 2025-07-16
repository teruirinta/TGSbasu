using UnityEngine;


public class Yurayura : MonoBehaviour

{
    [Header("Motion Settings")]
    [SerializeField] float swaySpeed = 0.5f;
    [SerializeField] float swayAmount = 0.5f;
    [SerializeField] float verticalWaveSpeed = 0.3f;
    [SerializeField] float verticalWaveAmount = 0.3f;
    [SerializeField] float scaleWaveSpeed = 0.2f;
    [SerializeField] float scaleWaveAmount = 0.1f;

    [Header("Drift Settings")]
    [SerializeField] float horizontalSpeed = 0.5f;

    Vector3 initialPos;
    Vector3 initialScale;
    float offset;

    void Start()
    {
        initialPos = transform.position;
        initialScale = transform.localScale;
        offset = Random.Range(0f, 100f); // 個体差を出すためのオフセット
    }

    void Update()
    {
        float time = Time.time + offset;

        // 横揺れ（海流に揺れる）
        float sway = Mathf.Sin(time * swaySpeed) * swayAmount;

        // 縦揺れ（波の上下）
        float vertical = Mathf.PerlinNoise(time * verticalWaveSpeed, 0f) * verticalWaveAmount;

        // スケール変化（伸び縮み）
        float scaleFactor = 1f + Mathf.Sin(time * scaleWaveSpeed) * scaleWaveAmount;

        // 左方向へのドリフト
        initialPos.x -= horizontalSpeed * Time.deltaTime;

        // 適用
        transform.position = initialPos + new Vector3(sway, vertical, 0f);
        transform.localScale = new Vector3(initialScale.x, initialScale.y * scaleFactor, initialScale.z);
    }

}
