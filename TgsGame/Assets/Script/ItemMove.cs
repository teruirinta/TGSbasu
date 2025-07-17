using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float horizontalSpeed = 2f; // ���ւ̈ړ����x
    public float scaleAmount = 0.2f;   // �g��k���̐U��
    public float scaleSpeed = 2f;      // �g��k���̃X�s�[�h
    public float rotationInterval = 2f; // ��]�̊Ԋu�i�b�j
    public float rotationSpeed = 360f;  // ��]���x�i�x/�b�j

    private Vector3 startPos;
    private Vector3 originalScale;
    private float lastRotationTime;
    private bool isRotating = false;
    private float rotationProgress = 0f;

    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;
        lastRotationTime = Time.time;
    }

    void Update()
    {
        // �������Ɉړ�
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // �g��k���̃A�j���[�V����
        float scaleOffset = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = originalScale + Vector3.one * scaleOffset;

        // ��]����
        if (!isRotating && Time.time - lastRotationTime >= rotationInterval)
        {
            isRotating = true;
            rotationProgress = 0f;
            lastRotationTime = Time.time;
        }

        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, step);
            rotationProgress += step;

            if (rotationProgress >= 360f)
            {
                isRotating = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
