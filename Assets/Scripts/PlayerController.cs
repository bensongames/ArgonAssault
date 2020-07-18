using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m/s")][SerializeField] float controlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 6f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;

    [Header("Weapons")]
    [SerializeField] private GameObject[] lasers;

    [Header("Screen Position Control")]
    [SerializeField] float positionPitchFactor = -5f;    
    [SerializeField] float positionYawFactor = +5f;

    [Header("Throw Control")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow = 0f;
    float yThrow = 0f;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessUserInput();
            ProcessPosition();
            ProcessRotation();
            ProcessFiring();
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Called from SendMessage")]
    private void OnPlayerDeath() // Called by String reference
    {
        isControlEnabled = false;
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
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        return clampedXPos;
    }

    private float GetYPos()
    {        
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        return clampedYPos;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToThrow;  // x
        float yaw = transform.localPosition.x * positionYawFactor;   // y
        float roll = xThrow * controlRollFactor; // z
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            FireWeapons(true);
        }
        else
        {
            FireWeapons(false);
        }
    }

    private void FireWeapons(bool fire)
    {
        foreach (GameObject laser in lasers)
        {
            var laserEmission = laser.GetComponent<ParticleSystem>().emission;
            laserEmission.enabled = fire;
        }

    }

}
