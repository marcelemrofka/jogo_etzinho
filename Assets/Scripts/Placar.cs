using UnityEngine;
using TMPro; // Para mexer com o texto

public class Placar : MonoBehaviour
{
    public TMP_Text textoMoedas; // Aqui vamos colocar o texto da tela

    private int moedas = 0;

    public void AdicionarMoeda()
    {
        moedas++; // Soma uma moeda
        textoMoedas.text = "Moedas: " + moedas; // Atualiza o texto na tela
    }
}
