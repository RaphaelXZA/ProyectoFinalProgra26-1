using TMPro;
using UnityEngine;

public class GetTotalPlayersUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalPlayersText;
    private GetTotalPlayersController controller;

    private void Awake()
    {
        controller = GetComponent<GetTotalPlayersController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(TotalPlayersResultData result)
    {
        if (result != null)
        {
            totalPlayersText.text = $"Total Players: {result.data}";
        }
        else
        {
            totalPlayersText.text = "Error getting total players.";
        }
    }

}
