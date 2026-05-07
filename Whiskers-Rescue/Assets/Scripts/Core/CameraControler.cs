using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPositionY;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 target = new Vector3(transform.position.x, currentPositionY, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, speed);

        // 👇 ова спречува микро-offset
        if (Mathf.Abs(transform.position.y - currentPositionY) < 0.05f)
        {
            transform.position = target;
            velocity = Vector3.zero;
        }
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPositionY = _newRoom.position.y;
        velocity = Vector3.zero;
    }
}
