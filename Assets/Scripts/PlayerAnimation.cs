using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private const string IS_Walking = "iswalking";
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        //獲取animator功能
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_Walking, player.Iswalking);
        //查找在animator裡面的iswalking，並且附值player 裡的public Iswalking
    }
}
