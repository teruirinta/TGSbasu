using UnityEngine;
using TMPro;
using System.Collections;

public class GoalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public float animationDuration = 1.5f; // �X�R�A��������܂ł̎��ԁi�b�j

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
            finalScoreText.text = "�X�R�A: " + currentScore.ToString();
            yield return null;
        }

        // �ŏI�X�R�A�𐳊m�ɕ\��
        finalScoreText.text = " �X�R�A: " + targetScore.ToString();
    }
}
