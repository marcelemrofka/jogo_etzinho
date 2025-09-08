using UnityEngine;

public class Coin : MonoBehaviour
{
    // Chamada quando o player coleta a moeda
    public void Collect()
    {
        GameManager.instance.AddCoin(); // Atualiza o placar
        Destroy(gameObject);            // Remove a moeda da cena
    }
}
