using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public float speed = 0.5f;  // 追尾速度
    public float flowSpeed = 2.0f;  // 左へ流れる速度
    public float stopDistance = 0f;  // 追尾をやめる距離

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (transform.position.x > player.position.x)
        {
            if (distanceToPlayer > stopDistance)
            {
                // プレイヤーに向かって移動
                Vector3 direction = directionToPlayer.normalized;
                transform.position += direction * speed * Time.deltaTime;

                // 向きをプレイヤーの方向に回転
                if (direction.x != 0)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
        else
        {
            // プレイヤーを無視して左へ流れる
            transform.position += new Vector3(-flowSpeed * Time.deltaTime, 0, 0);

            // 左を向くように回転（Y軸反転）
            transform.rotation = Quaternion.Euler(0, 0, 180); // 必要に応じてZ角度調整
        }
    }
}
