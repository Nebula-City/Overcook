using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
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
    public override void InteractOperate(Player player)
    {
        if (IsHaveKitchenObject())
        {
            DestorykitchenObject();
            CreateKitchenObject(cutKitchenObjectSO.prefab);
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