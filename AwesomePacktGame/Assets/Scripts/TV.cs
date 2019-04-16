using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactable
{
    public string message;
    public float messageTime;

    public override void Interact(Player player)
    {
        UIManager.Instance().DisplayMessage(message, messageTime);
    }
}
