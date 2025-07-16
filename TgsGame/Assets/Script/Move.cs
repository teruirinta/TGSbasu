using UnityEngine;

public class Move : MonoBehaviour
{
    public float horizontalSpeed = 2f; // ���ւ̈ړ����x
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, startPos.y , transform.position.z);
    }
    
}
