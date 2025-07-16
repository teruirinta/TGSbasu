using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aボタンが押されたらstage1に移動
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Stage1");
        }
        // Bボタンが押されたらstage2に移動
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
