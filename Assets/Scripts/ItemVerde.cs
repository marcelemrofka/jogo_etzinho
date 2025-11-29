using UnityEngine;

public class ItemVerde : MonoBehaviour
{
    public float tempoAdicionar = 5f;

    private void OnTriggerEnter(Collider other)
    {
        // testa pelo componente Player (não precisa usar Tag)
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            Countdown cont = FindObjectOfType<Countdown>();
            cont.AdicionarTempo(tempoAdicionar);
            Destroy(gameObject);
        }
    }
}
