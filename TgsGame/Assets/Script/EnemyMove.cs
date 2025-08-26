using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f;
    public float verticalSpeed = 1f;
    public float normalSpeed = 2f;
    public float boostedSpeed = 5f;
    public float yThreshold = 0.5f;
    public float xThreshold = 3f;
    public AudioClip swimSoundClip;
    private AudioSource audioSource;
    private Vector3 startPos;
    private GameObject player;
    private bool isBoosting = false;
    private Collider enemyCollider; // �� �ǉ��F������Collider�Q��
    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player�I�u�W�F�N�g��������܂���B�G�l�~�[�͓����܂���B");
            enabled = false;
            return;
        }
        // Collider�擾
        enemyCollider = GetComponent<Collider>();
        if (enemyCollider == null)
        {
            Debug.LogWarning("Collider ��������܂���B");
        }
        // AudioSource�̏�����
        audioSource = gameObject.AddComponent<AudioSource>();
        if (swimSoundClip != null)
        {
            audioSource.clip = swimSoundClip;
            audioSource.loop = false;
        }
        else
        {
            Debug.LogWarning("swimSoundClip ���ݒ肳��Ă��܂���B�T�E���h�͍Đ�����܂���B");
        }
    }
    void Update()
    {
        if (player == null) return;
        float yDiff = Mathf.Abs(transform.position.y - player.transform.position.y);
        float xDiff = Mathf.Abs(transform.position.x - player.transform.position.x);
        bool shouldBoost = (yDiff <= yThreshold && xDiff <= xThreshold);
        float currentSpeed = shouldBoost ? boostedSpeed : normalSpeed;
        if (shouldBoost && !isBoosting)
        {
            isBoosting = true;
            if (swimSoundClip != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (!shouldBoost && isBoosting)
        {
            isBoosting = false;
        }
        float newY = Mathf.Sin(Time.time * verticalSpeed) * moveAmount;
        float newX = transform.position.x - currentSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, startPos.y + newY, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ꎞ�I�ɓ����蔻��𖳌���
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
                Invoke(nameof(EnableCollider), 2.5f); // 2.5�b��ɍėL����
            }
            // �K�v�Ȃ炱���ŃG�t�F�N�g��_���[�W������ǉ��\
        }
    }
    void EnableCollider()
    {
        if (enemyCollider != null)
        {
            enemyCollider.enabled = true;
        }
    }
}