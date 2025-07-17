using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveForce = 10f; // スティック方向への移動力
    public float recoverDelay = 2f;
    public float recoverRate = 2f;

    public Slider staminaSlider;
    public GameObject particleEffectPrefab; // パーティクルのプレハブ

    private float lastPressTime;
    private float recoverTimer;

    private int currentHP = 5;
    public int maxHP = 5;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPressTime = -recoverDelay;
    }

    void Update()
    {
        // 左スティックの入力
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zRotation = transform.rotation.eulerAngles.z;

        Vector2 direction = new Vector2(horizontal, vertical);

        if (direction.magnitude > 0.1f) // 入力があるとき
        {
            // 回転処理
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            // 移動処理（スティック方向に移動）
            Vector3 moveDir = new Vector3(direction.x, direction.y, 0).normalized;
            rb.AddForce(moveDir * moveForce * Time.deltaTime, ForceMode.Force);
        }

        // Y軸反転処理（見た目の向き調整）
        if (zRotation > 90f && zRotation < 270f)
        {
            Vector3 scale = transform.localScale;
            scale.y = -Mathf.Abs(scale.y);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y);
            transform.localScale = scale;
        }

        // Aボタン押した時の処理（パーティクル表示のみ）
        if (Input.GetButtonDown("Fire1"))
        {
            if (particleEffectPrefab != null)
            {
                GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 1f); // 1秒後に自動削除
            }
        }
    }

    void LateUpdate()
    {
        // Z位置固定（物理演算後に位置を調整）
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            if (currentHP < maxHP)
            {
                currentHP++;
                Debug.Log("HP回復！現在: " + currentHP);
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy1"))
        {
            currentHP--;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item2"))
        {
            Destroy(other.gameObject);
        }
    }
}
