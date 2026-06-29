using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreView : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerIdInputField;
    [SerializeField] private TMP_InputField scoreInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private UpdateScoreController controller;

    private void Awake()
    {
        controller = GetComponent<UpdateScoreController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int playerId = int.Parse(playerIdInputField.text);
        int score = int.Parse(scoreInputField.text);

        controller.Send(playerId, score, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}