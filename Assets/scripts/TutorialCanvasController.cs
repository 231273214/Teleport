using UnityEngine;

public class TutorialCanvasController : MonoBehaviour
{
    [Header("Canvas del tutorial")]
    public GameObject tutorialCanvas; // Arrastra aquí tu Canvas desde el inspector

    // Método que se llama al presionar el botón
    public void CerrarTutorial()
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.SetActive(false); // Oculta el canvas
        }
        else
        {
            Debug.LogWarning("No se asignó el Canvas del tutorial en el inspector.");
        }
    }
}
