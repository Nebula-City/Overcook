using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 directon = new Vector3(horizontal, 0, vertical);
        //前後左右的移動變數設置
        directon = directon.normalized;
        //單位向量化，使左上右上更準確
        transform.position += directon * Time.deltaTime * moveSpeed;
        //更改Player位置
        if (directon != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, directon, Time.deltaTime * rotateSpeed);
        }
        //更改player朝向
    }
}
