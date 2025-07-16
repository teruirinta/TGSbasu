using UnityEngine;

public class UV : MonoBehaviour
{
    public float speed = 0.5f; // UV�̈ړ����x
    private Material material;
    private float offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.mainTextureOffset.x;
    }

    void Update()
    {
        offset += speed * Time.deltaTime; // ���Ԍo�߂ɉ����ăI�t�Z�b�g���X�V
        material.mainTextureOffset = new Vector2(offset, material.mainTextureOffset.y);
    }
}
