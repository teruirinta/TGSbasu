using UnityEngine;
using TMPro;
using System.Collections;

public class GoalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public float animationDuration = 1.5f; // スコアが増えるまでの時間（秒）

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        StartCoroutine(AnimateScore(finalScore));
    }

    IEnumerator AnimateScore(int targetScore)
    {
        int currentScore = 0;
        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / animationDuration);
            currentScore = Mathf.FloorToInt(Mathf.Lerp(0, targetScore, progress));
            finalScoreText.text = "スコア: " + currentScore.ToString();
            yield return null;
        }

        // 最終スコアを正確に表示
        finalScoreText.text = " スコア: " + targetScore.ToString();
    }
}
