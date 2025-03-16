using System;
using UnityEngine;

public class ClearCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private bool testing;
    [SerializeField] private ClearCounter transferTargetCounter;


    private void Update()
    {
        if (testing && Input.GetMouseButtonDown(0))
        {

            TransferKitchenObject(this, transferTargetCounter);
        }
    }
    public void Interact()
    {
        if (GetKitchenObject() == null)
        {
            KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {

            TransferKitchenObject(this, Player.Instance);
        }
        print(this.gameObject + "is interacting......");

    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }

}
