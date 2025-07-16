using UnityEngine;

public class UV : MonoBehaviour
{
    public float speed = 0.5f; // UVの移動速度
    private Material material;
    private float offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.mainTextureOffset.x;
    }

    void Update()
    {
        offset += speed * Time.deltaTime; // 時間経過に応じてオフセットを更新
        material.mainTextureOffset = new Vector2(offset, material.mainTextureOffset.y);
    }
}
