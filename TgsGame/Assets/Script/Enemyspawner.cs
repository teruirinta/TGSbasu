using UnityEngine;

public class Enamyspawner : MonoBehaviour
{
    public GameObject Enemy;
    float span = 7.0f;
    float delta = 0;
    float decreaseRate = 0.99f; // span を減少させる係数
    float minSpan = 0.2f; // 最小の時間間隔

    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            GameObject go = Instantiate(Enemy);
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
