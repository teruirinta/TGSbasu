using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource が見つかりません！");
        }
        else if (!audioSource.enabled)
        {
            Debug.LogError("AudioSource が無効になっています！");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
        }
    }
}
