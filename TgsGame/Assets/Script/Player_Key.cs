using UnityEngine;

public class Player_Key : MonoBehaviour
{
    public float moveDistance = 1f;           // 1回の連打で動く距離
    public float tapThreshold = 0.2f;         // 連打判定の時間（秒）
    public float autoLeftSpeed = 1f;          // 自動で左に進むスピード

    private float horizontalLastTime = 0f;
    private float verticalLastTime = 0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        float now = Time.time;

        // 自動で左に進む
        transform.position += Vector3.left * autoLeftSpeed * Time.deltaTime;

        // 横方向連打判定
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (now - horizontalLastTime < tapThreshold)
            {
                targetPosition += Vector3.right * moveDistance;
            }
            horizontalLastTime = now;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (now - horizontalLastTime < tapThreshold)
            {
                targetPosition += Vector3.left * moveDistance;
            }
            horizontalLastTime = now;
        }

        // 縦方向連打判定
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (now - verticalLastTime < tapThreshold)
            {
                targetPosition += Vector3.up * moveDistance;
            }
            verticalLastTime = now;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (now - verticalLastTime < tapThreshold)
            {
                targetPosition += Vector3.down * moveDistance;
            }
            verticalLastTime = now;
        }

        // スムーズに移動（連打で移動した分だけ）
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    }
}
