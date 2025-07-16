using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float fallSpeed = 0.1f;        // 静止時の落下速度
    public float startMoveSpeed = 2.0f;   // ゲーム開始時の左移動速度
    public float startMoveDuration = 1.5f; // 左移動時間

    private float startMoveTimer;
    private bool isStartMoving = true;

    void Start()
    {
        startMoveTimer = startMoveDuration;
    }

    void Update()
    {
        if (isStartMoving)
        {
            // transform で左へ移動
            transform.Translate(Vector3.left * startMoveSpeed * Time.deltaTime);
            startMoveTimer -= Time.deltaTime;

            if (startMoveTimer <= 0f)
            {
                isStartMoving = false;
            }
        }
        else
        {
            // 静止時にゆっくり落ちる
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}
