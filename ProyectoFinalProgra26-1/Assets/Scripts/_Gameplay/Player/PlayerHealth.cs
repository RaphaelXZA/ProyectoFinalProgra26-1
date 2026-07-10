using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;

    public void ChangeHealth(int amount)
    {
        health += amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Object.FindFirstObjectByType<ScoreCounter>().SaveScore();
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeHealth(-1);
        }
    }

}