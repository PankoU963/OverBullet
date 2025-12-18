using UnityEngine;

public class IsFloor : MonoBehaviour
{
    public bool isFloor = false;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Floor"))
        {
            isFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isFloor = false;
    }
}
