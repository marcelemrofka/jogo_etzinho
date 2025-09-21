using UnityEngine;

public class ParedeUmLado : MonoBehaviour
{
    public Transform entrada; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direcao = (collision.transform.position - entrada.position).normalized;

            if (Vector3.Dot(direcao, transform.forward) < 0)
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), false);
            }
            else
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            }
        }
    }
}
