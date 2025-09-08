using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject objetoBolinha;
    private Vector3 positionInicial;
    void Start()
    {
        positionInicial = this.transform.position - objetoBolinha.transform.position;
    }
    void Update()
    {
        transform.position = objetoBolinha.transform.position + positionInicial;
    }
}