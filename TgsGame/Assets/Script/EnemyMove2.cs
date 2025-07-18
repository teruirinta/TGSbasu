using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform�iInspector�Őݒ�j

    public float speed = 0.5f;        // �ǔ����x
    public float flowSpeed = 2.0f;    // ���֗���鑬�x
    public float stopDistance = 0f;   // �ǔ�����߂鋗��

    private Collider enemyCollider;   // ������Collider�Q��

    void Start()
    {
        // ������Collider���擾
        enemyCollider = GetComponent<Collider>();
        if (enemyCollider == null)
        {
            Debug.LogWarning("Collider ��������܂���B");
        }

        if (player == null)
        {
            Debug.LogWarning("Player Transform ���ݒ肳��Ă��܂���BEnemyMove2 �͓��삵�܂���B");
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
            // �ꎞ�I�ɓ����蔻��𖳌���
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
                Invoke(nameof(EnableCollider), 3f); // 2�b��ɍėL����
            }

            //Destroy(gameObject); // �G�͔j�󂵂Ȃ�
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
