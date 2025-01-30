using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public bool isNotebookActive;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public GameObject Notebook;
    public bool _cursorLocked;
    public AudioSource breathingRegular;
    public AudioSource breathingSprint;
    public YokaiTrigger notebookDisable;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;
    public int charCount = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isNotebookActive = false;
        _cursorLocked = true;
    }

    void Update()
    {
        bool notebookStatus = notebookDisable.returnNotebookStatus();
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (!isRunning)
        {
            // Play the first sound if it's not already playing
            if (!breathingRegular.isPlaying)
            {
                breathingRegular.Play();
                breathingRegular.loop = true; // Set to loop
            }

            // Stop the second sound if it's playing
            if (breathingSprint.isPlaying)
            {
                breathingSprint.Stop();
            }
        }
        else
        {
            // Play the second sound if it's not already playing
            if (!breathingSprint.isPlaying)
            {
                breathingSprint.Play();
                breathingSprint.loop = true; // Set to loop
            }

            // Stop the first sound if it's playing
            if (breathingRegular.isPlaying)
            {
                breathingRegular.Stop();
            }
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        

        // Notebook Interactions
        // to open the notebook
        Debug.Log(notebookStatus);
        if (notebookStatus == true) {
            if (isNotebookActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //Time.timeScale = 0;
                    Hide_ShowMouseCursor();
                    Notebook.SetActive(true);
                    isNotebookActive = true;
                    canMove = false;
                }
            //to close the notebook
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //Time.timeScale = 1;
                    Hide_ShowMouseCursor();
                    Notebook.SetActive(false);
                    isNotebookActive = false;
                    canMove = true;
                }
            }
        }
        

    }

    // to allow the player to see the cursor when the notebook is opened
    public void Hide_ShowMouseCursor()
    {
        if (!_cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cursorLocked = true;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _cursorLocked = false;
            Cursor.visible = true;
        }
    }

    public void addChar()
    {
        charCount += 1;
    }

    public int getCharCount()
    {
        return charCount;
    }

    public void freezeMovement()
    {
        canMove = false;
    }

    public void bringMovement()
    {
        canMove = true;
    }
}