using UnityEngine;

public class awa : MonoBehaviour
{
    public enum BubbleDirection { Up, Down }
    public BubbleDirection direction = BubbleDirection.Up;
    public float bounceForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 bounceDir = direction == BubbleDirection.Up ? Vector3.up : Vector3.down;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(bounceDir * bounceForce, ForceMode.Impulse);
        }
    }
}
