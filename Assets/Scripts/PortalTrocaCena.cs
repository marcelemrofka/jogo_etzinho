using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrocaCena : MonoBehaviour
{
    [SerializeField] private string nomeCena = "saída"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}
