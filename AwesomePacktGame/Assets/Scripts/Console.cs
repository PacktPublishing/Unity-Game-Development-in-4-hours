using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : Interactable
{
    public Ladder ladder;

    public override void Interact(Player player)
    {
        UIManager.Instance().DisplayMessage("Lowering the ladder... Setting the emergency pod...");
        ladder.enabled = true;
    }
}
