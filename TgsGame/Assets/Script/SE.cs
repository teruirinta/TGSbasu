using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource ��������܂���I");
        }
        else if (!audioSource.enabled)
        {
            Debug.LogError("AudioSource �������ɂȂ��Ă��܂��I");
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
