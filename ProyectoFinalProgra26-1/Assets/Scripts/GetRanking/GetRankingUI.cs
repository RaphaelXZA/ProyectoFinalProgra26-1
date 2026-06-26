using TMPro;
using UnityEngine;

public class GetRankingUI : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    private GetRankingController controller;

    private void Awake()
    {
        controller = GetComponent<GetRankingController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(PlayerResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (PlayerData player in result.data)
            {
                GameObject item = Instantiate(prefab, container);
                item.GetComponent<TextMeshProUGUI>().text = $"{player.player_name} - {player.player_highscore}";
            }
        }
    }

}