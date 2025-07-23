using UnityEngine;
public class EnemyMove3 : MonoBehaviour
{
    public float horizontalSpeed = 2f;     // ���ւ̈ړ����x
    public float floatAmplitude = 0.5f;    // �㉺�̐U��
    public float floatFrequency = 1f;      // �㉺�̑���
    private Vector3 startPos;
    private Collider enemyCollider;        // ������Collider�Q��
    void Start()
    {
        startPos = transform.position;
        enemyCollider = GetComponent<Collider>();
        if (enemyCollider == null)
        {
            Debug.LogWarning("Collider ��������܂���B");
        }
    }
    void Update()
    {
        // ���ֈړ�
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        // �㉺�ɂӂ�ӂ퓮���i�T�C���g�j
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ꎞ�I�ɓ����蔻��𖳌���
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
                Invoke(nameof(EnableCollider), 2f); // 2�b��ɍėL����
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