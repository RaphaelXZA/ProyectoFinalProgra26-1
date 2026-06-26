using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
[RequireComponent(typeof(Button))]
public class DynamicTestButton : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    private Button button;

    private void OnEnable()
    {
        UpdateLabel();
    }

    private void OnValidate()
    {
        UpdateLabel();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!Application.isPlaying)
            UpdateLabel();
    }
#endif

    private void UpdateLabel()
    {
        if (button == null)
            button = GetComponent<Button>();

        if (label == null)
            return;

#if UNITY_EDITOR
        int eventCount = button.onClick.GetPersistentEventCount();

        if (eventCount == 0)
        {
            label.text = "(Sin método)";
            return;
        }

        string text = "";

        for (int i = 0; i < eventCount; i++)
        {
            Object target = button.onClick.GetPersistentTarget(i);
            string method = button.onClick.GetPersistentMethodName(i);

            if (target != null)
            {
                text += $"{target.name}.{method}";
            }
            else
            {
                text += $"(Sin objeto).{method}";
            }

            if (i < eventCount - 1)
                text += "\n";
        }

        label.text = text;
#endif
    }
}