using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Enemy1;
    float span = 3.0f;
    float delta = -2.0f;
    float decreaseRate = 0.99f; // span ������������W��
    float minSpan = 0.2f; // �ŏ��̎��ԊԊu
   
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
                GameObject go = Instantiate(Enemy1);


                go.transform.position = new Vector3(15, Random.Range(-4, 6), 0);
                // span ������������
                this.span *= decreaseRate;

                // �ŏ��l�������Ȃ��悤�ɂ���
                if (this.span < minSpan)
                {
                    this.span = minSpan;
                }
                //delta �����Z�b�g
                this.delta = 0;

            }
        }
    }

}
