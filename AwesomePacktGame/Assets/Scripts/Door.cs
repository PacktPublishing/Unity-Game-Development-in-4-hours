using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 openRotation;
    public Vector3 closedRotation;

    private Vector3 desiredRotation;

    public GameObject doorObject;
    public float openSpeed = 5;

    private Player player;
    public Interactable keyCard;

    public AudioSource source;
    public AudioClip openClip;
    public AudioClip closeClip;

    private bool closing = false;

    private void Start()
    {
        desiredRotation = closedRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " Enter");
        player = other.GetComponent<Player>();
        if (player != null && player.inventory.Contains(keyCard))
        {
            if(Mathf.Abs(doorObject.transform.localEulerAngles.y - closedRotation.y) < 5)
            {
                source.PlayOneShot(openClip);
            }
            desiredRotation = openRotation;
        }
        else
            UIManager.Instance().DisplayMessage("Need a keycard");

        closing = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " Quit");
        desiredRotation = closedRotation;
        closing = true;
    }

    private void OpenClose()
    {
        if(closing && Mathf.Abs(doorObject.transform.localEulerAngles.y - closedRotation.y) < 5)
        {
            closing = false;
            source.PlayOneShot(closeClip);
        }
        doorObject.transform.localRotation = Quaternion.Euler(Vector3.Lerp(doorObject.transform.localEulerAngles, desiredRotation, Time.deltaTime * openSpeed));
    }

    private void Update()
    {
        OpenClose();
    }
}
