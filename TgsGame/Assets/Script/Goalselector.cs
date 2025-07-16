using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalselector : MonoBehaviour
{
    public RectTransform[] menuItems;
    public RectTransform selector;

    private int currentIndex = 0;
    private float inputCooldown = 0.3f;
    private float lastInputTime = 0f;

    void Start()
    {
        UpdateSelectorPosition();
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
            }
            else if (dpadY < -0.5f)
            {
                currentIndex = (currentIndex + 1) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
            }
        }

        // A�{�^���Ō���i�ʏ�� joystick button 0�j
        if (Input.GetKeyDown("joystick button 1"))
        {
            SelectStage(currentIndex);
        }

        void UpdateSelectorPosition()
        {
            // �O�p�`��I�𒆂̃��j���[���ڂ̍��ɔz�u
            Vector2 targetAnchoredPosition = menuItems[currentIndex].anchoredPosition;
            selector.anchoredPosition = new Vector2(targetAnchoredPosition.x - 500f, targetAnchoredPosition.y);
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
            SceneManager.LoadScene("Stage2");
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("title");
        }
    }
}
