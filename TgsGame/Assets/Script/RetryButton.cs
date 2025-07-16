using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Update()
    {
        // Xbox コントローラーの X ボタン（通常 "Fire2"）を押したら
        if (Input.GetButtonDown("Fire2"))
        {
            // 現在のシーンを再読み込みする
            SceneManager.LoadScene("SampleScene");
        }
    }
}
