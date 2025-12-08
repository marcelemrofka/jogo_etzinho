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

        int dificuldade = PlayerPrefs.GetInt("Game_Difficulty", 2);

        SetupSlider(dificuldade); // <<< CHAMAR AQUI TAMBÉM

        if (closeButton != null)
            closeButton.onClick.AddListener(ClosePanel);

        if (difficultyValueText != null)
            difficultyValueText.text = GetDifficultyName(dificuldade);

    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);

            int dificuldade = PlayerPrefs.GetInt("Game_Difficulty", 2);
            SetupSlider(dificuldade); // <<< GARANTE QUE ABRE CORRETO
        }
    }

    public void ClosePanel()
    {
        if (panel != null) panel.SetActive(false);
    }

    private void SetupSlider(int dificuldade)
    {
        if (difficultySlider != null)
        {
            difficultySlider.minValue = 1;
            difficultySlider.maxValue = 3;
            difficultySlider.wholeNumbers = true;

            difficultySlider.onValueChanged.RemoveAllListeners();
            difficultySlider.value = dificuldade;

            // ATUALIZA O TEXTO DO VALOR IMEDIATAMENTE
            if (difficultyValueText != null)
                difficultyValueText.text = GetDifficultyName(dificuldade);

            UpdateInstructionText(dificuldade);

            difficultySlider.onValueChanged.AddListener(OnSliderChanged);
        }
    }

    private string GetDifficultyName(int v)
    {
        return v switch
        {
            1 => "Fácil",
            2 => "Médio",
            3 => "Difícil",
            _ => "Médio"
        };
    }


    public void OnSliderChanged(float value)
    {
        int v = Mathf.RoundToInt(value);

        PlayerPrefs.SetInt("Game_Difficulty", v);
        PlayerPrefs.Save();

        if (difficultyValueText != null)
            difficultyValueText.text = GetDifficultyName(v);


        UpdateInstructionText(v);
    }

    private void UpdateInstructionText(int v)
    {
        string tempo = v switch
        {
            1 => "2:00",
            2 => "1:30",
            3 => "1:00",
            _ => "1:30"
        };

        if (instructionText != null)
            instructionText.text = $"Dificuldade {v}\nTempo: {tempo}";
    }
}
