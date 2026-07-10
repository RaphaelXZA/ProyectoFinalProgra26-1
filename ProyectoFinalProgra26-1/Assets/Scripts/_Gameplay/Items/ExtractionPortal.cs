using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractionPortal : ObstacleBase
{
    protected override void ExtraMovement() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<ScoreCounter>().SaveScore();
            SceneManager.LoadScene("GameExtracted");
        }
    }

}