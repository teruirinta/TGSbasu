using UnityEngine;

public class FlowObject : MonoBehaviour
{
    public float flowSpeed = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 playerPosition = collision.gameObject.transform.position;

            if (contactPoint.x < playerPosition.x)
            {
                // Player���E���痈�� �� ���ɗ����
                StartCoroutine(Flow(Vector2.left));
            }
            else
            {
                // Player�������痈�� �� �E�ɗ����
                StartCoroutine(Flow(Vector2.right));
            }
        }
    }

    private System.Collections.IEnumerator Flow(Vector2 direction)
    {
        float flowTime = 1.0f; // ����鎞�ԁi�b�j
        float timer = 0f;

        while (timer < flowTime)
        {
            transform.Translate(direction * flowSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
