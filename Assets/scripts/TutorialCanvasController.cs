using UnityEngine;

public class TutorialCanvasController : MonoBehaviour
{
    [Header("Canvas del tutorial")]
    public GameObject tutorialCanvas; // Arrastra aqu� tu Canvas desde el inspector

    // M�todo que se llama al presionar el bot�n
    public void CerrarTutorial()
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.SetActive(false); // Oculta el canvas
        }
        else
        {
            Debug.LogWarning("No se asign� el Canvas del tutorial en el inspector.");
        }
    }
}
