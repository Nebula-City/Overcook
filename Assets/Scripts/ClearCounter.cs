using System;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private GameObject kitchenObjectPrefab;
    [SerializeField] private Transform TopPoint;
    public void Interact()
    {
        print(this.gameObject + "is interacting......");
        GameObject go = GameObject.Instantiate(kitchenObjectPrefab, TopPoint);
        go.transform.localPosition = Vector3.zero;
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
