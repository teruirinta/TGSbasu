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
        // A�{�^���������ꂽ��stage1�Ɉړ�
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Stage1");
        }
        // B�{�^���������ꂽ��stage2�Ɉړ�
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
