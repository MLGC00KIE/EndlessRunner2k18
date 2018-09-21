using UnityEngine;

public class MouseLock : MonoBehaviour {

    private bool isLocked;

	public void setLockStatus(bool newLockStatus)
    {
        isLocked = newLockStatus;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            setLockStatus(true);
        if (Input.GetKeyDown(KeyCode.Escape))
            setLockStatus(false);

        if (isLocked)
            Cursor.lockState = CursorLockMode.Locked;

        if (!isLocked)
            Cursor.lockState = CursorLockMode.None;
    }
}