using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AltarBehaviour : MonoBehaviour
{
    GrabManager grabManager;
    [SerializeField] GameObject holder;
    public GameObject heldObject;

    [Header("Audio final")]
    public AudioSource audioSource; // Asigna tu AudioSource con el clip desde el Inspector
    public float delayBeforeExit = 3f; // tiempo en segundos antes de cerrar

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    public void OnPointerClickXR()
    {
        if (grabManager.heldItem != null)
        {
            // Colocar el objeto en el altar
            heldObject = grabManager.heldItem;
            grabManager.heldItem.GetComponent<GrabObject>().Place(holder.transform.position);

            //  No importa si es la cruz u otro objeto, siempre termina la simulación
            EndSimulation();
        }
    }

    void EndSimulation()
    {
        Debug.Log("¡La simulación ha terminado!");

        // Reproducir audio si existe
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Esperar 3 segundos antes de salir
        StartCoroutine(ExitAfterDelay());
    }

    IEnumerator ExitAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeExit);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detener en el editor
#else
        Application.Quit(); // Cerrar el juego compilado
#endif
    }
}

