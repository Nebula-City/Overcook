using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool iswalking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = gameInput.GetMovement();
        //獲取輸入
        iswalking = direction != Vector3.zero;
        //設置iswalking狀態

        transform.position += direction * Time.deltaTime * moveSpeed;
        //更改Player位置
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
        //更改player朝向
    }
    public bool Iswalking
    {
        get
        {
            return iswalking;
        }
    }
    //讓其他cs調用
}
