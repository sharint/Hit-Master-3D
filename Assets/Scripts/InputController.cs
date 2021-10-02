using UnityEngine;

public class InputController : MonoBehaviour
{
    private const int tapIndex = 0;

    public bool isUserTapOnScreen()
    {
        if (Input.touchCount > 0)
        {
            return isTapBegan();
        }
        return false;
    }

    private bool isTapBegan()
    {
        Touch touch = Input.GetTouch(tapIndex);
        if (touch.phase == TouchPhase.Began)
        {
            return true;
        }
        return false;
    }
}
