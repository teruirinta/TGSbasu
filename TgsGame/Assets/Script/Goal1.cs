using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal1 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3 targetPosition = Vector3.zero;
    [SerializeField] private ScoreManager scoreManager;

    private bool reachedTarget = false;

    void Update()
    {
        if (!reachedTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                reachedTarget = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("Player"))
        {
            scoreManager.isGoalReached = true; // ƒS[ƒ‹“ž’B‚ð’Ê’m

            PlayerPrefs.SetInt("FinalScore", scoreManager.score);

            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Stage1")
            {
                SceneManager.LoadScene("goal");
            }
            else if (currentScene == "Stage2")
            {
                SceneManager.LoadScene("goal2");
            }

            Destroy(gameObject);
        }



    }
}
