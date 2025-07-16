using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Update()
    {
        // X�{�^���Ń^�C�g���ɖ߂�
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("title");
        }

        // A�{�^���Ŏ��̃X�e�[�W��
        if (Input.GetButtonDown("Fire1"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // "Stage" �̌�̐������擾
            if (currentSceneName.StartsWith("Stage"))
            {
                string numberPart = currentSceneName.Substring(5); // "Stage"�̌��
                if (int.TryParse(numberPart, out int stageNumber))
                {
                    int nextStageNumber = stageNumber + 1;
                    string nextSceneName = "Stage" + nextStageNumber;

                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning("�X�e�[�W�ԍ��̉�͂Ɏ��s���܂���: " + currentSceneName);
                }
            }
            else
            {
                Debug.LogWarning("���݂̃V�[������ 'Stage' �Ŏn�܂��Ă��܂���: " + currentSceneName);
            }
        }
    }
}
