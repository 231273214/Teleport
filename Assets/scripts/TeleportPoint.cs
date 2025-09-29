using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    [Header("Sound Settings")]
    public AudioClip footstepClip;   
    private AudioSource audioSource; 

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        
        if (TeleportManager.Instance != null && TeleportManager.Instance.Player != null)
        {
            audioSource = TeleportManager.Instance.Player.GetComponent<AudioSource>();
        }
    }

    public void OnPointerEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }

    public void OnPointerClickXR()
    {
        ExecuteTeleportation();
        OnTeleport?.Invoke();
        TeleportManager.Instance.DisableTeleportPoint(gameObject);
    }

    public void OnPointerExitXR()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleportation()
    {
        GameObject player = TeleportManager.Instance.Player;
        Camera camera = player.GetComponentInChildren<Camera>();

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

       
        player.transform.position = transform.position;

        
        float rotY = transform.rotation.eulerAngles.y - camera.transform.localEulerAngles.y;
        player.transform.rotation = Quaternion.Euler(0, rotY, 0);

        if (cc != null) cc.enabled = true;

        
        if (audioSource != null && footstepClip != null)
        {
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
