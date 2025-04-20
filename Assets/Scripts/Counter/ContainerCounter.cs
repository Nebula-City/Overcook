using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContainerCounterVisual containerCounterVisual;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        CreateKitchenObject(kitchenObjectSO.prefab);
        TransferKitchenObject(this, player);
        print(this.gameObject + "is interacting......");
        containerCounterVisual.PlayOpenAnimation();
    }
    
}