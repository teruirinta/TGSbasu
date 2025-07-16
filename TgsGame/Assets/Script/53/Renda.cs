using UnityEngine;

public class Renda : MonoBehaviour
{
    //public float moveDistance = 1f;         // 連打で進む距離
    //public float tapThreshold = 0.2f;       // 連打判定間隔
    public float minInputMagnitude = 0.3f;  // スティック感度
    public float autoLeftSpeed = 1f;        // オートスクロール速度

    private float lastATapTime = 0f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        //  オートで左にスクロール
        if (autoLeftSpeed > 0f)
        {
            transform.position += Vector3.left * autoLeftSpeed * Time.deltaTime;
            targetPosition += Vector3.left * autoLeftSpeed * Time.deltaTime; // ターゲット位置も更新
        }

        ////  スティック入力を取得（必要以上に敏感にならないように）
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 inputDir = new Vector3(horizontal, vertical, 0f);

        //if (inputDir.magnitude > minInputMagnitude)
        //{
        //    moveDirection = inputDir.normalized;
        //}

        ////  Aボタン（joystick button 0）を連打すると進む
        //if (Input.GetKeyDown(KeyCode.JoystickButton0))
        //{
        //    float now = Time.time;
        //    if (now - lastATapTime < tapThreshold)
        //    {
        //        targetPosition += moveDirection * moveDistance;
        //    }
        //    lastATapTime = now;
        //}

        //  スムーズに移動
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    }
}
