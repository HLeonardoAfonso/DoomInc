using UnityEngine;

public class WeaponBobPro : MonoBehaviour
{
    [Header("References")]
    public CharacterController characterController;

    [Header("Airborne Physics")]
    public float tiltAmount       = 6.0f;
    public float airSmoothing     = 5.0f;
    [Range(0, 0.05f)]
    public float verticalWeight   = 0.015f;

    [Header("Landing Spring")]
    public float springStrength     = 150f;
    public float springDamping      = 18f;
    public float impactSensitivity  = 0.02f;

    Vector3    _restPos;
    Quaternion _restRot;

    float _airTilt;         // current smoothed tilt angle
    float _verticalOffset;  // current smoothed vertical position offset

    float _springPos;       // spring displacement (drives the landing bounce)
    float _springVel;       // spring velocity

    bool  _wasGrounded;
    float _lastVerticalVel;

    void Start()
    {
        _restPos = transform.localPosition;
        _restRot = transform.localRotation;

        if (!characterController)
            characterController = GetComponentInParent<CharacterController>();
    }

    void Update()
    {
        if (!characterController) return;

        bool  grounded    = characterController.isGrounded;
        float verticalVel = characterController.velocity.y;

        UpdateAirTilt(grounded, verticalVel);
        UpdateSpring(grounded);
        ApplyMotion();

        _wasGrounded    = grounded;
        _lastVerticalVel = verticalVel;
    }

    void UpdateAirTilt(bool grounded, float verticalVel)
    {
        bool rising  = verticalVel > 0f;
        bool falling = verticalVel < 0f;

        float targetTilt   = grounded ? 0f
                           : rising   ?  tiltAmount    // nose up on jump
                           :             -tiltAmount;  // nose down on fall

        float targetOffset = grounded ? 0f
                           : rising   ?  verticalWeight
                           :             -verticalWeight;

        float t = Time.deltaTime * airSmoothing;
        _airTilt       = Mathf.Lerp(_airTilt,        targetTilt,   t);
        _verticalOffset = Mathf.Lerp(_verticalOffset, targetOffset, t);
    }

    void UpdateSpring(bool grounded)
    {
        if (grounded && !_wasGrounded)
        {
            float impact = Mathf.Abs(_lastVerticalVel) * impactSensitivity;
            _springVel += impact * 100f;
        }

        _springVel += (-_springPos * springStrength) * Time.deltaTime;
        _springVel  =  Mathf.Lerp(_springVel, 0f, Time.deltaTime * springDamping);
        _springPos +=  _springVel * Time.deltaTime;
    }

    void ApplyMotion()
    {
        float pitch = _airTilt + _springPos;

        transform.localRotation = _restRot * Quaternion.Euler(pitch, 0f, 0f);
        transform.localPosition = _restPos + new Vector3(0f, _verticalOffset, 0f);
    }
}