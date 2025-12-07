using UnityEngine;
using TMPro;

public class Placar : MonoBehaviour
{
    public TMP_Text textoMoedas; 

    private int pecas = 0;

    public void AdicionarMoeda()
    {
        pecas++; 
        textoMoedas.text = "Peças: " + pecas; 
    }
}
