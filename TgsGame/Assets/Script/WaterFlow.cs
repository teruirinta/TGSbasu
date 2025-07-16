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
            Rigidbody playerRigidbody = other.transform.parent.GetComponent<Rigidbody>();

            //�v���C���[�̓����ɐ����̗͂�������
            playerRigidbody.linearVelocity += velocity * Time.deltaTime;
        }
    }
}
