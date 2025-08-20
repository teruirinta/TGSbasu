using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveForce = 10f; // 押したときの移動力

  
    public float recoverDelay = 2f;
    public float recoverRate = 2f;

    public Slider staminaSlider;

    public GameObject particleEffectPrefab; // 追加：パーティクルのプレハブ

   
    private float lastPressTime;
    private float recoverTimer;

    private int currentHP = 5;
    public int maxHP = 5;

    private Rigidbody rb;


    Animator animator;
    float swimAnimWeight = 0f;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        lastPressTime = -recoverDelay;


        animator = transform.GetChild(0).GetComponent<Animator>();

    }

    void Update()
    {
        // Z位置固定
        Vector3 newPosition = transform.position;
        newPosition.z = 0;
        transform.position = newPosition;

        // 左スティックの入力
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zRotation = transform.rotation.eulerAngles.z;


        if (horizontal != 0 || vertical != 0)
        {
            Vector2 direction = new Vector2(horizontal, vertical);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0,0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

          
        }


        if (zRotation > 90f && zRotation < 270f)
        {
            Vector3 scale = transform.localScale;
            scale.y = -Mathf.Abs(scale.y); // Y軸を負に
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y); // Y軸を正に戻す
            transform.localScale = scale;
        }




        // Aボタン押した時の処理
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            
                Vector3 forward = transform.right;
                rb.AddForce(forward * moveForce, ForceMode.Impulse);

               

                // パーティクル表示（1秒で消える）
                if (particleEffectPrefab != null)
                {
                    GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
                    Destroy(effect, 1f); // 1秒後に自動削除
                }

            swimAnimWeight = 1.0f;
        }


        //泳ぐアニメーション
        animator.SetLayerWeight(1, swimAnimWeight);

        swimAnimWeight *= 0.99f;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            if (currentHP < maxHP)
            {
                currentHP++;
                Debug.Log("HP回復！現在: " + currentHP);
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy1"))
        {
            
            currentHP--;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item2"))
        {
     
            Destroy(other.gameObject);
        }

        
    }
}
