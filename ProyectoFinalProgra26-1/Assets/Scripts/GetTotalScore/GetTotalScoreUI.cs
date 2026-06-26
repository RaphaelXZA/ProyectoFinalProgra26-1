using TMPro;
using UnityEngine;

public class GetTotalScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScoreText;
    private GetTotalScoreController controller;

    private void Awake()
    {
        controller = GetComponent<GetTotalScoreController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(TotalScoreResultData result)
    {
        if (result != null)
        {
            totalScoreText.text = $"Total Score: {result.data}";
        }
        else
        {
            totalScoreText.text = "Error getting total score.";
        }
    }

}
