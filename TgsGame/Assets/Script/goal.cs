using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class goal : MonoBehaviour
{
    private float timer = 0f;
    public float switchTime = 180f;

    [SerializeField] private ScoreManager scoreManager; // �C���X�y�N�^�[�Őݒ�
    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            PlayerPrefs.SetInt("FinalScore", scoreManager.score);
            SceneManager.LoadScene("goal"); // �S�[���V�[���Ɉړ�
        }
    }
}