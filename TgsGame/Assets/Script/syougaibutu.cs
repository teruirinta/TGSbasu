using UnityEngine;

public class syougaibutu : MonoBehaviour
{

    public float speed = 5f;
 

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

