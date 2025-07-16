using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public float speed = 0.5f;  // �ǔ����x
    public float flowSpeed = 2.0f;  // ���֗���鑬�x
    public float stopDistance = 0f;  // �ǔ�����߂鋗��

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (transform.position.x > player.position.x)
        {
            if (distanceToPlayer > stopDistance)
            {
                // �v���C���[�Ɍ������Ĉړ�
                Vector3 direction = directionToPlayer.normalized;
                transform.position += direction * speed * Time.deltaTime;

                // �������v���C���[�̕����ɉ�]
                if (direction.x != 0)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
        else
        {
            // �v���C���[�𖳎����č��֗����
            transform.position += new Vector3(-flowSpeed * Time.deltaTime, 0, 0);

            // ���������悤�ɉ�]�iY�����]�j
            transform.rotation = Quaternion.Euler(0, 0, 180); // �K�v�ɉ�����Z�p�x����
        }
    }
}
