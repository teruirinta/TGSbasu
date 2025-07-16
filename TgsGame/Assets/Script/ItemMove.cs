using UnityEngine;

public class ItemMove : MonoBehaviour
{

    public float horizontalSpeed = 2f; // ���ւ̈ړ����x
    public float scaleAmount = 0.2f;   // �g��k���̐U��
    public float scaleSpeed = 2f;      // �g��k���̃X�s�[�h

    private Vector3 startPos;
    private Vector3 originalScale;

    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;
    }

    void Update()
    {
        // �������Ɉړ�
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // �g��k���̃A�j���[�V����
        float scaleOffset = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = originalScale + Vector3.one * scaleOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
