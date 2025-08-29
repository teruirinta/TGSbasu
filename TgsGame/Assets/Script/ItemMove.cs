using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float horizontalSpeed = 2f; // ¶‚Ö‚ÌˆÚ“®‘¬“x
    public float scaleAmount = 0.2f;   // Šg‘åk¬‚ÌU•
    public float scaleSpeed = 2f;      // Šg‘åk¬‚ÌƒXƒs[ƒh
    public float rotationSpeed = 360f; // ‰ñ“]‘¬“xi“x/•bj

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // ‰¡•ûŒü‚ÉˆÚ“®
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Šg‘åk¬‚ÌƒAƒjƒ[ƒVƒ‡ƒ“
        float scaleOffset = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = originalScale + Vector3.one * scaleOffset;

        // í‚É‰ñ“]
        float step = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}