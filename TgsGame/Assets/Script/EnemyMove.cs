using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f; // �㉺�ɓ�����
    public float verticalSpeed = 1f; // �㉺�̓����̑���
    public float horizontalSpeed = 2f; // ���ւ̈ړ����x

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * verticalSpeed) * moveAmount;
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, startPos.y + newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
