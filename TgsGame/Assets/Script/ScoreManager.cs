using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("スコアポップアップ用")]
    public GameObject scorePopupPrefab; // ワールド空間用TextMeshProプレハブ

    private float timeCounter = 0f;
    public bool isGoalReached = false;
    [SerializeField] private Transform goalTransform;

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (goalTransform != null && goalTransform.position.x <= 0.5f)
        {
            return; // ゴールのXが0.5以下ならスコア加算を停止
        }

        timeCounter += Time.deltaTime;

        if (timeCounter >= 1f)
        {
            score += 100;
            timeCounter = 0f;
            UpdateScoreText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy1"))
        {
            score -= 150;
            UpdateScoreText();
            ShowScorePopup(other.transform.position, -150, Color.red);
        }
        else if (other.CompareTag("ItemScore"))
        {
            score += 500;
            UpdateScoreText();
            ShowScorePopup(other.transform.position, 500, Color.green);
        }
        else if (other.CompareTag("Item1"))
        {
            score += 200;
            UpdateScoreText();
            ShowScorePopup(other.transform.position, 200, Color.green);
        }
        else if (other.CompareTag("Item2"))
        {
            score += 100;
            UpdateScoreText();
            ShowScorePopup(other.transform.position, 100, Color.green);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "スコア: " + score.ToString();
        }
    }

    void ShowScorePopup(Vector3 position, int amount, Color color)
    {
        GameObject popup = Instantiate(scorePopupPrefab, position + Vector3.up * 0.5f, Quaternion.identity);
        TextMeshPro tmp = popup.GetComponent<TextMeshPro>();
        if (tmp != null)
        {
            tmp.text = (amount > 0 ? "+" : "") + amount.ToString();
            tmp.color = color;
        }

        StartCoroutine(PopupFadeOut(popup));
    }

    IEnumerator PopupFadeOut(GameObject popup)
    {
        float duration = 1f;
        float time = 0f;
        Vector3 startPos = popup.transform.position;
        Vector3 endPos = startPos + Vector3.up * 1f;

        TextMeshPro tmp = popup.GetComponent<TextMeshPro>();
        Color originalColor = tmp.color;

        while (time < duration)
        {
            popup.transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            tmp.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0), time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(popup);
    }
}
