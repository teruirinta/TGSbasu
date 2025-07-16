using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f;
    public float verticalSpeed = 1f;
    public float normalSpeed = 2f;
    public float boostedSpeed = 5f;
    public float yThreshold = 0.5f;
    public float xThreshold = 3f;

    public AudioClip swimSoundClip; // ← 泳ぎサウンドをInspectorに設定
    private AudioSource audioSource;

    private Vector3 startPos;
    private GameObject player;
    private bool isBoosting = false; // 今加速中かどうかを記録

    void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Playerオブジェクトが見つからないラ！");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swimSoundClip;
        audioSource.loop = false; // 一回だけ再生（ループしたいならtrueに）
    }

    void Update()
    {
        if (player == null) return;

        float yDiff = Mathf.Abs(transform.position.y - player.transform.position.y);
        float xDiff = Mathf.Abs(transform.position.x - player.transform.position.x);

        bool shouldBoost = (yDiff <= yThreshold && xDiff <= xThreshold);

        float currentSpeed = shouldBoost ? boostedSpeed : normalSpeed;

        // 状態が変わったときにサウンドを再生
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
            // ループするなら止めてもOK：
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