using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector3 GetMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        //前後左右的移動變數設置
        direction = direction.normalized;
        //單位向量化，使左上右上更準確
        return direction;
    }
}
