using UnityEngine;

public class Enamyspawner : MonoBehaviour
{
    public GameObject Enemy;
    float span = 7.0f;
    float delta = 0;
    float decreaseRate = 0.99f; // span ������������W��
    float minSpan = 0.2f; // �ŏ��̎��ԊԊu

    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            GameObject go = Instantiate(Enemy);
            go.transform.position = new Vector3(15, Random.Range(-4, 6), 0);

            // span ������������
            this.span *= decreaseRate;

            // �ŏ��l�������Ȃ��悤�ɂ���
            if (this.span < minSpan)
            {
                this.span = minSpan;
            }

            // delta �����Z�b�g
            this.delta = 0;
        }
    }
}
