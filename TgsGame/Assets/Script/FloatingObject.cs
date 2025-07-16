using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float fallSpeed = 0.1f;        // �Î~���̗������x
    public float startMoveSpeed = 2.0f;   // �Q�[���J�n���̍��ړ����x
    public float startMoveDuration = 1.5f; // ���ړ�����

    private float startMoveTimer;
    private bool isStartMoving = true;

    void Start()
    {
        startMoveTimer = startMoveDuration;
    }

    void Update()
    {
        if (isStartMoving)
        {
            // transform �ō��ֈړ�
            transform.Translate(Vector3.left * startMoveSpeed * Time.deltaTime);
            startMoveTimer -= Time.deltaTime;

            if (startMoveTimer <= 0f)
            {
                isStartMoving = false;
            }
        }
        else
        {
            // �Î~���ɂ�����藎����
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}
