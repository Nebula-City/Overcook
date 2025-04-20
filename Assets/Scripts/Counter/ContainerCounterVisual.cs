using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour

{
    private Animator anima;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    public void PlayOpenAnimation()
    {
        anima.SetTrigger("OpenClose");
    }
}
