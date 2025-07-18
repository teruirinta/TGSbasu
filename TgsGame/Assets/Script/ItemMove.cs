using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float horizontalSpeed = 2f; // 左への移動速度
    public float scaleAmount = 0.2f;   // 拡大縮小の振幅
    public float scaleSpeed = 2f;      // 拡大縮小のスピード
    public float rotationInterval = 2f; // 回転の間隔（秒）
    public float rotationSpeed = 360f;  // 回転速度（度/秒）

    private Vector3 startPos;
    private Vector3 originalScale;
    private float lastRotationTime;
    private bool isRotating = false;
    private float rotationProgress = 0f;

    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;
        lastRotationTime = Time.time;
    }

    void Update()
    {
        // 横方向に移動
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // 拡大縮小のアニメーション
        float scaleOffset = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = originalScale + Vector3.one * scaleOffset;

        // 回転処理
        if (!isRotating && Time.time - lastRotationTime >= rotationInterval)
        {
            isRotating = true;
            rotationProgress = 0f;
            lastRotationTime = Time.time;
        }

        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, step);
            rotationProgress += step;

            if (rotationProgress >= 360f)
            {
                isRotating = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
