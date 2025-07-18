using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public RectTransform[] menuItems;
    public RectTransform selector;

    public AudioClip moveSE;   // カーソル移動音
    public AudioClip decideSE; // 決定音
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
                PlaySE(moveSE); // カーソル移動音
            }
            else if (dpadY < -0.5f)
            {
                currentIndex = (currentIndex + 1) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
                PlaySE(moveSE); // カーソル移動音
            }
        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            PlaySE(decideSE); // 決定音
            SelectStage(currentIndex);
        }
    }

    void UpdateSelectorPosition()
    {
        Vector3 targetPosition = menuItems[currentIndex].position;
        selector.position = new Vector3(targetPosition.x - 300f, targetPosition.y, targetPosition.z);
    }

    void SelectStage(int index)
    {
        Debug.Log("選択されたインデックス: " + index);

        if (index == 0)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("Stage2");
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
