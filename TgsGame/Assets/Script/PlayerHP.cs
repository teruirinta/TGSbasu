using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �� �ǉ��IUI����������

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    [Header("UI Settings")]
    public Image[] hearts;         // �n�[�g�摜�i�����珇�ɔz�u�j
    public Sprite fullHeart;       // ���^���n�[�g�摜
    public Sprite emptyHeart;      // ����ۃn�[�g�摜

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    void OnTriggerEnter(Collider other)
    {
        // �G�ɐG�ꂽ��_���[�W
        if (other.CompareTag("Enemy1"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        // �A�C�e���ɐG�ꂽ���
        if (other.CompareTag("Item1"))
        {
            Heal(1);
            Destroy(other.gameObject); // �G�ꂽ�A�C�e���͏�����悤��
        }

        if (other.CompareTag("ItemScore"))
        {
           
            Destroy(other.gameObject); // �G�ꂽ�A�C�e���͏�����悤��
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
        // HP�����^���Ȃ�񕜂��Ȃ�
        if (currentHP >= maxHP)
        {
           
            return;
        }

        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP + "�i�񕜁I�j");
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
            // �n�[�g���E���猸�炷�����I
            if (i >= maxHP - currentHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
