using System;
using UnityEngine;

public class ClearCounter : BaseCounter
{


    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject() == false)
            {
                TransferKitchenObject(player, this);
            }
        }
        else
        {
            if (IsHaveKitchenObject() != false)
            {
                TransferKitchenObject(this, player);
            }
        }

    }

}
