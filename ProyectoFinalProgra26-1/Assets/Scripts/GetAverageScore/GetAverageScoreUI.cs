using TMPro;
using UnityEngine;

public class GetAverageScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI averageScoreText;
    private GetAverageScoreController controller;

    private void Awake()
    {
        controller = GetComponent<GetAverageScoreController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(AverageScoreResultData result)
    {
        if (result != null)
        {
            averageScoreText.text = $"Average Score: {result.data}";
        }
        else
        {
            averageScoreText.text = "Error getting average score.";
        }
    }

}