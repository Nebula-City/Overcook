using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    public Rigidbody rb;
    public LayerMask CounterLayerMask;
    private bool iswalking = false;
    private BaseCounter selectedCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameInput.OnInterAction += GameInput_OnInterAction;
        gameInput.OnOperateAction += GameInput_OnOperateAction;
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }
    void FixedUpdate()
    {

        HandleMovement();
    }
    private void GameInput_OnInterAction(object sende, System.EventArgs e)
    {
        selectedCounter?.Interact(this);
    }
    private void GameInput_OnOperateAction(object sender, System.EventArgs e)
    {
        selectedCounter?.InteractOperate(this);
    }
    public bool Iswalking
    {
        get
        {
            return iswalking;
        }
    }
    private void HandleMovement()
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
    private void HandleInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, CounterLayerMask))
        {
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {

                SetSelectCounter(counter);

            }
            else
            {
                SetSelectCounter(null);
            }
        }
        else
        {
            SetSelectCounter(null);
        }
    }
    public void SetSelectCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
            this.selectedCounter = counter;
        }

    }
    //讓其他cs調用
}
