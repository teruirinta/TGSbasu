using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Item;
    float span = 10.0f;
    float delta = 0;
    float decreaseRate = 0.99f; // span を減少させる係数
    float minSpan = 0.2f; // 最小の時間間隔
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            this.delta += Time.deltaTime;

            if (this.delta > this.span)
            {
                GameObject go = Instantiate(Item);

                
                go.transform.position = new Vector3(15, Random.Range(-4, 6), 0);
                // span を減少させる
                this.span *= decreaseRate;

                // 最小値を下回らないようにする
                if (this.span < minSpan)
                {
                    this.span = minSpan;
                }
                // delta をリセット
                this.delta = 0;

            }
        }
    }
}

