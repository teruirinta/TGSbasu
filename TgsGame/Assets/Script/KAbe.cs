using UnityEngine;

public class KAbe : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy1"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Item1"))
        {
            Destroy(other.gameObject); 
        }
        if (other.CompareTag("Enemy2"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Item2"))
        {
            Destroy(other.gameObject); 
        }
        if (other.CompareTag("kabe"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("ItemScore"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("konbu"))
        {
            Destroy(other.gameObject);
        }
    }
}
