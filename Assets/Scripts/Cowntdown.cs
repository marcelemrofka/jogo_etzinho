using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text TextoContador;
    public float tempo = 60f;

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

    // 🔥 MÉTODO NOVO → permite adicionar tempo (+5, +10, etc.)
    public void AdicionarTempo(float quantidade)
    {
        tempo += quantidade;
    }
}
