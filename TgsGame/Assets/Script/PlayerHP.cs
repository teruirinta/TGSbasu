using UnityEngine;

public class PlayerEffectController : MonoBehaviour
{
    [Header("エフェクトPrefabをここに設定")]
    public GameObject item1Effect;
    public GameObject item2Effect;
    public GameObject scoreUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            SpawnEffect(item1Effect);
        }
        else if (other.CompareTag("Item2"))
        {
            SpawnEffect(item2Effect);
        }
        else if (other.CompareTag("ItemScore"))
        {
            SpawnEffect(scoreUpEffect);
        }
    }

    // エフェクトをPlayerの位置に1秒間表示
    private void SpawnEffect(GameObject effectPrefab)
    {
        if (effectPrefab == null) return;

        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 2f); // 1秒後に削除
    }
}
