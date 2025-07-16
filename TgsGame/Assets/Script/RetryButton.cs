using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Update()
    {
        // Xボタンでタイトルに戻る
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("title");
        }

        // Aボタンで次のステージへ
        if (Input.GetButtonDown("Fire1"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // "Stage" の後の数字を取得
            if (currentSceneName.StartsWith("Stage"))
            {
                string numberPart = currentSceneName.Substring(5); // "Stage"の後ろ
                if (int.TryParse(numberPart, out int stageNumber))
                {
                    int nextStageNumber = stageNumber + 1;
                    string nextSceneName = "Stage" + nextStageNumber;

                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning("ステージ番号の解析に失敗しました: " + currentSceneName);
                }
            }
            else
            {
                Debug.LogWarning("現在のシーン名が 'Stage' で始まっていません: " + currentSceneName);
            }
        }
    }
}
