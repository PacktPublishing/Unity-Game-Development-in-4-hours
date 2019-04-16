using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject context;

    public virtual void SetContext(bool state)
    {
        if (context != null)
            context.SetActive(state);
    }

    public virtual void Interact(Player player)
    {
        UIManager.Instance().DisplayMessage("Clicked on interactable");
    }
}
