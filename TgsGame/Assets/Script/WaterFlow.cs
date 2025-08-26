using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    [SerializeField, Header("�����̋���")]
    Vector3 velocity = new Vector3(0, 10, 0);


    //�ڐG��
    void OnTriggerStay(Collider other)
    {
        //�ڐG�����̂��v���C���[��������
        if (other.tag == "Player" || other.tag == "Basu")
        {
            //�v���C���[��Rigidbody���擾
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody == null)
            {
                playerRigidbody = other.transform.parent?.GetComponent<Rigidbody>();
            }

            if (playerRigidbody == null)
            {
                playerRigidbody = other.transform.root.GetComponent<Rigidbody>();
            }

            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity += velocity * Time.deltaTime;
            }
            else
            {
                Debug.LogWarning("Rigidbody ��������Ȃ�����: " + other.name);
            }


            //�v���C���[�̓����ɐ����̗͂�������
            playerRigidbody.linearVelocity += velocity * Time.deltaTime;
        }
    }
}
