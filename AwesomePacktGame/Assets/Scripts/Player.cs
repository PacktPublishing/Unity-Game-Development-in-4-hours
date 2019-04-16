using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    private Interactable lookingAt;

    public List<Interactable> inventory = new List<Interactable>();

    private bool paused = false;

    public FirstPersonController controller;

    public void TogglePause()
    {
        paused = !paused;
        if(paused)
        {
            UIManager.Instance().SetPanel(Panel.Pause);
        }
        else
        {
            UIManager.Instance().SetPanel(Panel.InGame);
        }

        controller.enabled = !paused;
        SetMouse(paused);
    }

    private void SetMouse(bool state)
    {
        if(state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void AddItem(Interactable item)
    {
        inventory.Add(item);
        UIManager.Instance().indicator.SetActive(true);
    }

    private void Start()
    {
        UIManager.Instance().SetPanel(Panel.InGame);
        SetMouse(paused);
    }

    private void OnDisable()
    {
        SetMouse(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got " + other.name);
        lookingAt = other.GetComponent<Interactable>();
        if(lookingAt != null)
        {
            lookingAt.SetContext(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Stopped looking at " + other.name);
        if(other.GetComponent<Interactable>() == lookingAt && lookingAt != null)
        {
            lookingAt.SetContext(false);
            lookingAt = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lookingAt != null)
        {
            if (lookingAt.isActiveAndEnabled)
                lookingAt.Interact(this);
            else
                lookingAt = null;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
