using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Update()
    {
        // Xbox �R���g���[���[�� X �{�^���i�ʏ� "Fire2"�j����������
        if (Input.GetButtonDown("Fire2"))
        {
            // ���݂̃V�[�����ēǂݍ��݂���
            SceneManager.LoadScene("SampleScene");
        }
    }
}
