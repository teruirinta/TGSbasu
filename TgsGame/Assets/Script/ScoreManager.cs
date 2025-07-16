using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreUpEffectText;
    public TextMeshProUGUI scoreDownEffectText;

    private float timeCounter = 0f;

    // 合算表示用
    private int currentUpTotal = 0;
    private int currentDownTotal = 0;
    private Coroutine upCoroutine = null;
    private Coroutine downCoroutine = null;

    void Start()
    {
        UpdateScoreText();

        // 初期化
        scoreUpEffectText.text = "";
        scoreUpEffectText.alpha = 0f;
        scoreDownEffectText.text = "";
        scoreDownEffectText.alpha = 0f;
    }

    void Update()
    {
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
        if (other.CompareTag("Enemy1") || other.CompareTag("Enemy2"))
        {
            score -= 150;
            UpdateScoreText();

            currentDownTotal -= 150; // -150ずつ減る（マイナス表示）

            if (downCoroutine != null)
            {
                StopCoroutine(downCoroutine);
            }
            downCoroutine = StartCoroutine(ShowDownEffect());
        }
        else if (other.CompareTag("ItemScore"))
        {
            score += 500;
            UpdateScoreText();

            currentUpTotal += 500;

            if (upCoroutine != null)
            {
                StopCoroutine(upCoroutine);
            }
            upCoroutine = StartCoroutine(ShowUpEffect());
        }
        else if (other.CompareTag("Item1") || other.CompareTag("Item2"))
        {
            score += 200;
            UpdateScoreText();

            currentUpTotal += 200;

            if (upCoroutine != null)
            {
                StopCoroutine(upCoroutine);
            }
            upCoroutine = StartCoroutine(ShowUpEffect());
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    IEnumerator ShowUpEffect()
    {
        scoreUpEffectText.text = "+" + currentUpTotal.ToString();
        scoreUpEffectText.color = Color.green;
        scoreUpEffectText.alpha = 1f;

        yield return new WaitForSeconds(1f);

        currentUpTotal = 0;
        scoreUpEffectText.text = "";
        scoreUpEffectText.alpha = 0f;
        upCoroutine = null;
    }

    IEnumerator ShowDownEffect()
    {
        scoreDownEffectText.text = currentDownTotal.ToString(); // マイナス値がそのまま表示される
        scoreDownEffectText.color = Color.red;
        scoreDownEffectText.alpha = 1f;

        yield return new WaitForSeconds(1f);

        currentDownTotal = 0;
        scoreDownEffectText.text = "";
        scoreDownEffectText.alpha = 0f;
        downCoroutine = null;
    }
}
