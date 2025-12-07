using UnityEngine;

public class Coin : MonoBehaviour
{
    public float floatAmplitude = 0.2f; 
    public float floatSpeed = 1f;       
    public float hoverHeight = 0.9f;    

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        startPos.y += hoverHeight; 
    }

    void Update()
    {
        float newY = startPos.y + Mathf.PingPong(Time.time * floatSpeed, floatAmplitude);
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        transform.Rotate(Vector3.up * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Placar placar = FindObjectOfType<Placar>();
        if (placar != null)
        {
            placar.AdicionarMoeda();
        }

        Destroy(gameObject);
    }
}
