using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    public Rigidbody rb;
    public LayerMask CounterLayerMask;
    private bool iswalking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameInput.OnInterAction += GameInput_OnInterAction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        HandheldMovement();
    }
    private void HandheldMovement()
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
    private void Handleinteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, CounterLayerMask))
        {
            if (hitinfo.transform.TryGetComponent(out ClearCounter counter))
            {

                counter.Interact();
            }
        }
    }
    private void GameInput_OnInterAction(object sende, System.EventArgs e)
    {
        Handleinteraction();
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
