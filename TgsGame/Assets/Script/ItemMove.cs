using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float moveAmount = 0.5f; // ã‰º‚É“®‚­•
    public float verticalSpeed = 2f; // ã‰º‚Ì“®‚«‚Ì‘¬‚³
    public float horizontalSpeed = 2f; // ¶‚Ö‚ÌˆÚ“®‘¬“x

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * verticalSpeed) * moveAmount;
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
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
