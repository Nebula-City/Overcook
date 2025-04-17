using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField] private Transform HoldPoint;
    private KitchenObject kitchenObject;
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;
    }
    public Transform GetHoldPoint()
    {
        return HoldPoint;
    }
    public void TransferKitchenObject(KitchenObjectHolder SourceHolder, KitchenObjectHolder TargetHolder)
    {
        if (SourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("沒有東西可以轉移");
            return;
        }
        if (TargetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目標位置已經有東西了");
            return;
        }
        TargetHolder.AddKitchenObject(SourceHolder.GetKitchenObject());
        SourceHolder.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(HoldPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }


    public bool IsHaveKitchenObject()
    {
        return kitchenObject != null;
    }
    public void ClearKitchenObject()
    {
        if (kitchenObject != null)
        {
            this.kitchenObject = null;
        }
    }
}
