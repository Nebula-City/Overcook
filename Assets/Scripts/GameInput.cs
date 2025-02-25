using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameControl gamecontrol;
    void Awake()
    {
        gamecontrol = new GameControl();
        gamecontrol.Player.Enable();
        //啟用新inpute
    }
    public Vector3 GetMovement()
    {
        Vector2 inputVector2 = gamecontrol.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);
        //前後左右的移動變數設置
        direction = direction.normalized;
        //單位向量化，使左上右上更準確
        return direction;
    }
}
