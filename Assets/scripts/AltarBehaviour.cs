using UnityEngine;
using UnityEngine.SceneManagement; 

public class AltarBehaviour : MonoBehaviour
{
    GrabManager grabManager;
    [SerializeField] GameObject holder;
    public GameObject heldObject;

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    public void OnPointerClickXR()
    {
        if (grabManager.heldItem != null)
        {
            // Colocar la cruz
            heldObject = grabManager.heldItem;
            grabManager.heldItem.GetComponent<GrabObject>().Place(holder.transform.position);

            // Chequear si lo que se colocó es la cruz
            if (heldObject.GetComponent<GrabObject>().type == "Cross")
            {
                EndSimulation();
            }
        }
    }

    void EndSimulation()
    {
        Debug.Log("¡La simulación ha terminado!");
        // Aquí puedes:
        // - Mostrar un Canvas con mensaje final
        // - Reproducir un sonido
        // - Cambiar a otra escena:
        // SceneManager.LoadScene("EndScene");
    }
}
