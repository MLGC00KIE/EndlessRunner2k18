using UnityEngine;

public class MouseLock : MonoBehaviour {

	public void setLockStatus(bool isLocked)
    {
        if (isLocked)
            Cursor.lockState = CursorLockMode.Locked;

        if (!isLocked)
            Cursor.lockState = CursorLockMode.None;

    }
}