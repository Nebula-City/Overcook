using System;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform TopPoint;
    [SerializeField] private bool testing;
    [SerializeField] private ClearCounter transferTargetCounter;
    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetMouseButtonDown(0))
        {

            TransferKitchenObject(this, transferTargetCounter);
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, TopPoint).GetComponent<KitchenObject>();
            kitchenObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("已經有了-" + gameObject);
            Destroy(kitchenObject.gameObject);
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
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void TransferKitchenObject(ClearCounter sourceCounter, ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("沒有東西可以轉移");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("目標位置已經有東西了");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        sourceCounter.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(TopPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        if (kitchenObject != null)
        {
            this.kitchenObject = null;
        }
    }
}
