using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeListSO;
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
            KitchenObjectSO output = cuttingRecipeListSO.GetOutput(GetKitchenObject().GetKitchenObjectSO());
            if (output != null)
            {
                DestorykitchenObject();
                CreateKitchenObject(output.prefab);
            }
        }
    }
}