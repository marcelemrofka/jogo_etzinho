using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyPanelController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public Button closeButton;
    public Slider difficultySlider;
    public TMP_Text difficultyValueText;
    public TMP_Text instructionText;

    void Start()
    {
        if (panel != null) 
            panel.SetActive(false);

        // Carrega dificuldade salva do PlayerPrefs
        int dificuldade = PlayerPrefs.GetInt("Game_Difficulty", 1);

        if (difficultySlider != null)
        {
            difficultySlider.minValue = 1;
            difficultySlider.maxValue = 3; // agora são 3 dificuldades
            difficultySlider.wholeNumbers = true;
            difficultySlider.value = dificuldade;

            UpdateInstructionText(dificuldade);

            difficultySlider.onValueChanged.AddListener(OnSliderChanged);
        }

        if (closeButton != null)
            closeButton.onClick.AddListener(ClosePanel);
    }

    public void OpenPanel()
    {
        if (panel != null) panel.SetActive(true);
    }

    public void ClosePanel()
    {
        if (panel != null) panel.SetActive(false);
    }

    public void OnSliderChanged(float value)
    {
        int v = Mathf.RoundToInt(value);

        PlayerPrefs.SetInt("Game_Difficulty", v);
        PlayerPrefs.Save();

        if (difficultyValueText != null)
            difficultyValueText.text = v.ToString();

        UpdateInstructionText(v);
    }

    private void UpdateInstructionText(int v)
    {
        string tempo = v switch
        {
            1 => "1:30",
            2 => "1:15",
            3 => "1:00",
            _ => "1:30"
        };

        if (instructionText != null)
            instructionText.text = $"Dificuldade {v}\nTempo: {tempo}";
    }
}
