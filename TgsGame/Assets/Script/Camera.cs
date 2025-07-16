using UnityEngine;

public class Camera : MonoBehaviour
{

    public float wobbleSpeed = 1.0f;
    public float wobbleAmount = 0.1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float wobbleX = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        float wobbleY = Mathf.Cos(Time.time * wobbleSpeed * 0.8f) * wobbleAmount;
        transform.localPosition = initialPosition + new Vector3(wobbleX, wobbleY, 0);
    }

}
