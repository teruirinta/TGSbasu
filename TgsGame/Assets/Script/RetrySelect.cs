using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySelect : MonoBehaviour
{
    public RectTransform[] menuItems;
    public RectTransform selector;

    public AudioClip moveSE;   // �J�[�\���ړ���
    public AudioClip decideSE; // ���艹
    private AudioSource audioSource;

    private int currentIndex = 0;
    private float inputCooldown = 0.3f;
    private float lastInputTime = 0f;

    void Start()
    {
        UpdateSelectorPosition();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        float dpadY = Input.GetAxis("DPadY");

        if (Time.time - lastInputTime > inputCooldown)
        {
            if (dpadY > 0.5f)
            {
                currentIndex = (currentIndex - 1 + menuItems.Length) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
                PlaySE(moveSE); // �J�[�\���ړ���
            }
            else if (dpadY < -0.5f)
            {
                currentIndex = (currentIndex + 1) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
                PlaySE(moveSE); // �J�[�\���ړ���
            }
        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            PlaySE(decideSE); // ���艹
            SelectStage(currentIndex);
        }
    }

    void UpdateSelectorPosition()
    {
        Vector3 targetPosition = menuItems[currentIndex].position;
        selector.position = new Vector3(targetPosition.x - 500f, targetPosition.y, targetPosition.z);
    }

    void SelectStage(int index)
    {
        Debug.Log("�I�����ꂽ�C���f�b�N�X: " + index);

        if (index == 0)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("title");
        }
    }

    void PlaySE(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
