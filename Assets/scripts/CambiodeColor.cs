using UnityEngine;

public class CambiodeColor : MonoBehaviour
{

    public Color violeta = Color.violet;
    public Color naranja = Color.orange;
    public Material Materialcubo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Materialcubo = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambioColor()
    {
        Materialcubo.color = violeta;
    }
}
