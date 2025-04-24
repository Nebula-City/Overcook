using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectedCounter;
    public virtual void Interact(Player player)
    {
        Debug.Log("交互方法沒有重寫...");
    }
    public virtual void InteractOperate(Player player)
    {

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
