using UnityEngine;

public class bomba : MonoBehaviour
{
    public float tempoRemover = 15f;

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            Countdown cont = FindObjectOfType<Countdown>();
           cont.RemoverTempo(tempoRemover);
            Destroy(gameObject);
        }
    }
}
