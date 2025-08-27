using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    [Header("UI Settings")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("SE Settings")]
    public AudioClip damageSE;
    public AudioClip healSE;
    public AudioClip scoreSE;
    public AudioSource audioSource;

    [Header("Effect Prefabs")]
    public GameObject item1Effect;   // Item1エフェクト
    public GameObject item2Effect;   // Item2エフェクト
    public GameObject scoreUpEffect; // Scoreエフェクト

    // 無敵時間関連
    private bool isInvincible = false;
    private float invincibleDuration = 2.5f;
    private float invincibleTimer = 0f;

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    void Update()
    {
        // 無敵タイマーの更新
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                isInvincible = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy1"))
        {
            if (!isInvincible)
            {
                PlaySE(damageSE);
                TakeDamage(1);
                isInvincible = true;
                invincibleTimer = invincibleDuration;
            }
        }

        if (other.CompareTag("Item1"))
        {
            PlaySE(healSE);
            Heal(1);
            SpawnEffect(item1Effect); // ← エフェクト出す
            Destroy(other.gameObject, 0.1f);
        }

        if (other.CompareTag("Item2"))
        {
            PlaySE(healSE);
            SpawnEffect(item2Effect); // ← エフェクト出す
            Destroy(other.gameObject, 0.1f);
        }

        if (other.CompareTag("ItemScore"))
        {
            PlaySE(scoreSE);
            SpawnEffect(scoreUpEffect); // ← エフェクト出す
            Destroy(other.gameObject, 0.1f);
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
        if (currentHP >= maxHP) return;

        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP + "（回復！）");
        UpdateHearts();
    }

    void Die()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        FadeManager.Instance.LoadScene("GameOver", 1.0f);
        //SceneManager.LoadScene("GameOver");
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    void PlaySE(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // 共通エフェクト処理
    void SpawnEffect(GameObject effectPrefab)
    {
        if (effectPrefab == null) return;

        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 1f); // 1秒後に削除
    }
}
