using UnityEngine;

public class Player_Key : MonoBehaviour
{
    public float moveDistance = 1f;           // 1��̘A�łœ�������
    public float tapThreshold = 0.2f;         // �A�Ŕ���̎��ԁi�b�j
    public float autoLeftSpeed = 1f;          // �����ō��ɐi�ރX�s�[�h

    private float horizontalLastTime = 0f;
    private float verticalLastTime = 0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        float now = Time.time;

        // �����ō��ɐi��
        transform.position += Vector3.left * autoLeftSpeed * Time.deltaTime;

        // �������A�Ŕ���
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (now - horizontalLastTime < tapThreshold)
            {
                targetPosition += Vector3.right * moveDistance;
            }
            horizontalLastTime = now;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (now - horizontalLastTime < tapThreshold)
            {
                targetPosition += Vector3.left * moveDistance;
            }
            horizontalLastTime = now;
        }

        // �c�����A�Ŕ���
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (now - verticalLastTime < tapThreshold)
            {
                targetPosition += Vector3.up * moveDistance;
            }
            verticalLastTime = now;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (now - verticalLastTime < tapThreshold)
            {
                targetPosition += Vector3.down * moveDistance;
            }
            verticalLastTime = now;
        }

        // �X���[�Y�Ɉړ��i�A�łňړ������������j
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    }
}
