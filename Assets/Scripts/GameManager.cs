using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text coinText;
    private int coinCount = 0;

    // dificuldade
    [Range(1,3)]
    public int difficulty = 1;

    private const string PREF_DIFFICULTY = "Game_Difficulty";

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        difficulty = PlayerPrefs.GetInt(PREF_DIFFICULTY, 1);
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }

    public void SetDifficulty(int value)
    {
        difficulty = Mathf.Clamp(value, 1, 3);
        PlayerPrefs.SetInt(PREF_DIFFICULTY, difficulty);
        PlayerPrefs.Save();
        Debug.Log("Dificuldade setada para: " + difficulty);
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public int GetTimeByDifficulty()
    {
        switch (difficulty)
        {
            case 1: return 90; // Fácil → 1:30
            case 2: return 75; // Médio → 1:15
            case 3: return 60; // Difícil → 1:00
        }

        return 90;
    }

    public string GetFormattedTime()
    {
        int total = GetTimeByDifficulty();
        int min = total / 60;
        int sec = total % 60;

        return $"{min}:{sec:00}";
    }
}
