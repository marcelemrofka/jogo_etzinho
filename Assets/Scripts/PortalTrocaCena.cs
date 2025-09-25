using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrocaCena : MonoBehaviour
{
    [SerializeField] private string nomeCena = "saída"; 

    private void OnTriggerEnter(Collider other)
    {
        // Se o objeto que encostou tiver o script Player, troca de cena
        if (other.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}
