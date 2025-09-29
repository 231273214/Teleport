using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //  no se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject); //  evita duplicados si regresas a la primera escena
        }
    }
}
