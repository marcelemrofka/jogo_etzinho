using UnityEngine;

public class relogio : MonoBehaviour
{
    public float tempoAdicionar = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            Countdown cont = FindObjectOfType<Countdown>();
            cont.AdicionarTempo(tempoAdicionar);
            Destroy(gameObject);
        }
    }
}
