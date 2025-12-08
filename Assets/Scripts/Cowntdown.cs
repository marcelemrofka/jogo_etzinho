using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text TextoContador;
    private float tempo;

    void Start()
    {
        int dificuldade = PlayerPrefs.GetInt("Game_Difficulty", 2);

        switch (dificuldade)
        {
            case 1: tempo = 120f; break;  // 2:00
            case 2: tempo = 90; break;  // 1:30
            case 3: tempo = 60f; break;  // 1:00
        }
    }


    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempo / 60);
            int segundos = Mathf.FloorToInt(tempo % 60);

            TextoContador.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        }
        else
        {
            TextoContador.text = "00:00";
            SceneManager.LoadScene("derrota");
        }
    }

    public void AdicionarTempo(float quantidade)
    {
        tempo += quantidade;
    }

    public void RemoverTempo(float quantidade)
    {
        tempo -= quantidade;

        if (tempo < 0)
            tempo = 0;
    }
}
