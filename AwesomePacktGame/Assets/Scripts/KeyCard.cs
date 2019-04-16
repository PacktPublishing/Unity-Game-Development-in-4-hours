using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : Interactable
{
    public override void Interact(Player player)
    {
        player.AddItem(this);
        gameObject.SetActive(false);
        base.Interact(player);
        UIManager.Instance().DisplayMessage("Keycard: Clearence Level C");
    }
}
