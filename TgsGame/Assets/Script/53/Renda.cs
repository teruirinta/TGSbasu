using UnityEngine;

public class Renda : MonoBehaviour
{
    //public float moveDistance = 1f;         // �A�łŐi�ދ���
    //public float tapThreshold = 0.2f;       // �A�Ŕ���Ԋu
    public float minInputMagnitude = 0.3f;  // �X�e�B�b�N���x
    public float autoLeftSpeed = 1f;        // �I�[�g�X�N���[�����x

    private float lastATapTime = 0f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        //  �I�[�g�ō��ɃX�N���[��
        if (autoLeftSpeed > 0f)
        {
            transform.position += Vector3.left * autoLeftSpeed * Time.deltaTime;
            targetPosition += Vector3.left * autoLeftSpeed * Time.deltaTime; // �^�[�Q�b�g�ʒu���X�V
        }

        ////  �X�e�B�b�N���͂��擾�i�K�v�ȏ�ɕq���ɂȂ�Ȃ��悤�Ɂj
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 inputDir = new Vector3(horizontal, vertical, 0f);

        //if (inputDir.magnitude > minInputMagnitude)
        //{
        //    moveDirection = inputDir.normalized;
        //}

        ////  A�{�^���ijoystick button 0�j��A�ł���Ɛi��
        //if (Input.GetKeyDown(KeyCode.JoystickButton0))
        //{
        //    float now = Time.time;
        //    if (now - lastATapTime < tapThreshold)
        //    {
        //        targetPosition += moveDirection * moveDistance;
        //    }
        //    lastATapTime = now;
        //}

        //  �X���[�Y�Ɉړ�
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    }
}
