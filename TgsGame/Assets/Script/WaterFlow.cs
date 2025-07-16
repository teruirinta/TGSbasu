using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    [SerializeField, Header("水流の強さ")]
    Vector3 velocity = new Vector3(0, 10, 0);


    //接触中
    void OnTriggerStay(Collider other)
    {
        //接触したのがプレイヤーだったら
        if (other.tag == "Player" || other.tag == "Basu")
        {
            //プレイヤーのRigidbodyを取得
            Rigidbody playerRigidbody = other.transform.parent.GetComponent<Rigidbody>();

            //プレイヤーの動きに水流の力を加える
            playerRigidbody.linearVelocity += velocity * Time.deltaTime;
        }
    }
}
