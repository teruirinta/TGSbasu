using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñI");
        }
        else if (!audioSource.enabled)
        {
            Debug.LogError("AudioSource ‚ª–³Œø‚É‚È‚Á‚Ä‚¢‚Ü‚·I");
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
