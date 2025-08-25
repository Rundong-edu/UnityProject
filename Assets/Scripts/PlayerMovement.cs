using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float minX = -7f;
    private float maxX = 7f;
    private Vector2 moveInput;

    // // Called by Player Input component when Move action is triggered
    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     moveInput = context.ReadValue<Vector2>();
    // }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        float newX = transform.position.x + moveInput.x * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}