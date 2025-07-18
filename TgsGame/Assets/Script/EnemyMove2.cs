using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform（Inspectorで設定）

    public float speed = 0.5f;        // 追尾速度
    public float flowSpeed = 2.0f;    // 左へ流れる速度
    public float stopDistance = 0f;   // 追尾をやめる距離

    private Collider enemyCollider;   // 自分のCollider参照

    void Start()
    {
        // 自分のColliderを取得
        enemyCollider = GetComponent<Collider>();
        if (enemyCollider == null)
        {
            Debug.LogWarning("Collider が見つかりません。");
        }

        if (player == null)
        {
            Debug.LogWarning("Player Transform が設定されていません。EnemyMove2 は動作しません。");
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (transform.position.x > player.position.x)
        {
            if (distanceToPlayer > stopDistance)
            {
                Vector3 direction = directionToPlayer.normalized;
                transform.position += direction * speed * Time.deltaTime;

                if (direction.x != 0)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
        else
        {
            transform.position += new Vector3(-flowSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 一時的に当たり判定を無効化
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
                Invoke(nameof(EnableCollider), 3f); // 2秒後に再有効化
            }

            //Destroy(gameObject); // 敵は破壊しない
        }
    }

    void EnableCollider()
    {
        if (enemyCollider != null)
        {
            enemyCollider.enabled = true;
        }
    }
}
