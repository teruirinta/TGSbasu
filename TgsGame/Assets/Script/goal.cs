using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{

    private float timer = 0f;
    public float switchTime = 180f; // 3���i180�b�j

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            SceneManager.LoadScene("goal");
        }
    }
}
