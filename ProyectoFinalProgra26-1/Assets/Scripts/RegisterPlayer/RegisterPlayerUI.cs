using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playernameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button registerButton;
    private RegisterPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<RegisterPlayerController>();
        registerButton.onClick.AddListener(Send);
    }

    private void Send()
    {
        string playername = playernameInputField.text;
        string email = emailInputField.text;
        string password = passwordInputField.text;

        controller.Send(playername, email, password, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}
