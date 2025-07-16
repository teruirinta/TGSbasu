using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ← 追加！UIを扱うため

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    [Header("UI Settings")]
    public Image[] hearts;         // ハート画像（左から順に配置）
    public Sprite fullHeart;       // 満タンハート画像
    public Sprite emptyHeart;      // 空っぽハート画像

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    void OnTriggerEnter(Collider other)
    {
        // 敵に触れたらダメージ
        if (other.CompareTag("Enemy1"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        // アイテムに触れたら回復
        if (other.CompareTag("Item1"))
        {
            Heal(1);
            Destroy(other.gameObject); // 触れたアイテムは消えるように
        }

        if (other.CompareTag("ItemScore"))
        {
           
            Destroy(other.gameObject); // 触れたアイテムは消えるように
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP);
        UpdateHearts();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Heal(int amount)
    {
        // HPが満タンなら回復しない
        if (currentHP >= maxHP)
        {
           
            return;
        }

        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP + "（回復！）");
        UpdateHearts();
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // ハートを右から減らす処理！
            if (i >= maxHP - currentHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
