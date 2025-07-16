using TMPro;
using UnityEngine;
using System.Collections;

public class HideUI : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    public float delayBeforeHide = 2f; // 表示しておく時間（秒）

    void Start()
    {
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeHide);

        // 一瞬で透明にする
        Color color = textMeshPro.color;
        color.a = 0f;
        textMeshPro.color = color;
    }

}
