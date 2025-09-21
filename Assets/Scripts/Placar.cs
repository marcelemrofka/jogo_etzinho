using UnityEngine;
using TMPro; // Para mexer com o texto

public class Placar : MonoBehaviour
{
    public TMP_Text textoMoedas; // Aqui vamos colocar o texto da tela

    private int pecas = 0;

    public void AdicionarMoeda()
    {
        pecas++; // Soma uma moeda
        textoMoedas.text = "Peças: " + pecas; // Atualiza o texto na tela
    }
}
