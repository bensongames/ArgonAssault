using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{

    [Tooltip("In m/s")][SerializeField] float xSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 6f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float throwPitchFactor = -20f;
    [SerializeField] float positionYawFactor = +5f;
    [SerializeField] float throwRollFactor = -20f;
    float xThrow = 0f;
    float yThrow = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessUserInput();
        ProcessPosition();
        ProcessRotation();
    }

    private void ProcessUserInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void ProcessPosition()
    {
        transform.localPosition = new Vector3(GetXPos(), GetYPos(), transform.localPosition.z);
    }

    private float GetXPos()
    {        
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        return clampedXPos;
    }

    private float GetYPos()
    {        
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        return clampedYPos;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * throwPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToThrow;  // x
        float yaw = transform.localPosition.x * positionYawFactor;   // y
        float roll = xThrow * throwRollFactor; // z
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
