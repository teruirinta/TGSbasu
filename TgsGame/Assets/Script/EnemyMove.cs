using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f;
    public float verticalSpeed = 1f;
    public float normalSpeed = 2f;
    public float boostedSpeed = 5f;
    public float yThreshold = 0.5f;
    public float xThreshold = 3f;

    public AudioClip swimSoundClip; // �� �j���T�E���h��Inspector�ɐݒ�
    private AudioSource audioSource;

    private Vector3 startPos;
    private GameObject player;
    private bool isBoosting = false; // �����������ǂ������L�^

    void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player�I�u�W�F�N�g��������Ȃ����I");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swimSoundClip;
        audioSource.loop = false; // ��񂾂��Đ��i���[�v�������Ȃ�true�Ɂj
    }

    void Update()
    {
        if (player == null) return;

        float yDiff = Mathf.Abs(transform.position.y - player.transform.position.y);
        float xDiff = Mathf.Abs(transform.position.x - player.transform.position.x);

        bool shouldBoost = (yDiff <= yThreshold && xDiff <= xThreshold);

        float currentSpeed = shouldBoost ? boostedSpeed : normalSpeed;

        // ��Ԃ��ς�����Ƃ��ɃT�E���h���Đ�
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
            // ���[�v����Ȃ�~�߂Ă�OK�F
            // audioSource.Stop();
        }

        float newY = Mathf.Sin(Time.time * verticalSpeed) * moveAmount;
        float newX = transform.position.x - currentSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, startPos.y + newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}