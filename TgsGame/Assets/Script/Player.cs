using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float recoverDelay = 2f;
    public float recoverRate = 2f;
    public Slider staminaSlider;
    public GameObject particleEffectPrefab;
    private float lastPressTime;
    private float recoverTimer;
    private int currentHP = 5;
    public int maxHP = 5;
    private Rigidbody rb;
    public float blinkDuration = 2f;
    public float blinkInterval = 0.2f;
    private List<Renderer> childRenderers = new List<Renderer>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPressTime = -recoverDelay;
        Renderer[] allRenderers = GetComponentsInChildren<Renderer>();
        Renderer parentRenderer = GetComponent<Renderer>();
        foreach (Renderer r in allRenderers)
        {
            if (r != parentRenderer) // 親の Renderer を除外
            {
                childRenderers.Add(r);
            }
        }
        if (childRenderers.Count == 0)
        {
            Debug.LogWarning("子オブジェクトの Renderer が見つかりません。点滅できません。");
        }
    }
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = 0;
        transform.position = newPosition;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zRotation = transform.rotation.eulerAngles.z;
        if (horizontal != 0 || vertical != 0)
        {
            Vector2 direction = new Vector2(horizontal, vertical);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
        }
        if (zRotation > 90f && zRotation < 270f)
        {
            Vector3 scale = transform.localScale;
            scale.y = -Mathf.Abs(scale.y);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y);
            transform.localScale = scale;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 inputDirection = new Vector2(horizontal, vertical);
            if (inputDirection.magnitude > 0.1f)
            {
                inputDirection.Normalize();
                Vector3 forceDirection = new Vector3(inputDirection.x, inputDirection.y, 0f);
                rb.AddForce(forceDirection * moveForce, ForceMode.Impulse);
                if (particleEffectPrefab != null)
                {
                    GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
                    Destroy(effect, 1f);
                }
            }
        }
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
            StartCoroutine(BlinkEffect());
        }
        if (other.CompareTag("Item2"))
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator BlinkEffect()
    {
        float timer = 0f;
        while (timer < blinkDuration)
        {
            foreach (Renderer r in childRenderers)
            {
                r.enabled = !r.enabled;
            }
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }
        foreach (Renderer r in childRenderers)
        {
            r.enabled = true;
        }
    }
}