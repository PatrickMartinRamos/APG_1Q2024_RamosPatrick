using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class forcemode : MonoBehaviour
{
    [SerializeField] private Rigidbody2D manualforceObjRb;
    [SerializeField] private Rigidbody autoForceObjRb;
    [SerializeField] private Vector2 force;

    [SerializeField] private Rigidbody autoAcceRb;
    [SerializeField] private Rigidbody manualAcceRb;
    [SerializeField] private Vector3 accel;

    [SerializeField] private Rigidbody manualImpulseRb;
    [SerializeField] private Rigidbody autoImpulseRb;
    [SerializeField] private Vector3 forceImpulse;

    [SerializeField] private Rigidbody manualVelChangeRb;
    [SerializeField] private Rigidbody autoVelChangeRb;
    [SerializeField] private Vector3 VelChange;

    private void Start()
    {
        manualImpulse();
        autoImpulse();
        manualVelChange();
        autoVelChange();
    }
    private void Update()
    {
        manualForce();
        manualAcce();
    }

    private void FixedUpdate()
    {
        autoForce();
        autoAcce();
    }
    #region force auto/manual
    void autoForce()
    {
        autoForceObjRb.AddForce(force, ForceMode.Force);
    }
    void manualForce()
    {
        manualforceObjRb.velocity += force * Time.deltaTime / manualforceObjRb.mass;
    }
    #endregion

    #region acceleration auto/manual
    void manualAcce()
    {
        manualAcceRb.velocity += accel * Time.deltaTime;
    }

    void autoAcce()
    {
        autoAcceRb.AddForce(accel, ForceMode.Acceleration);
    }
    #endregion

    #region Impulse auto/manual
    void manualImpulse()
    {
        manualImpulseRb.velocity += forceImpulse / manualImpulseRb.mass;
    }
    void autoImpulse()
    {
        autoImpulseRb.AddForce(forceImpulse, ForceMode.Impulse);
    }
    #endregion

    #region Velocity Change auto/manual
    void autoVelChange()
    {
        autoVelChangeRb.AddForce(VelChange , ForceMode.VelocityChange);
    }

    void manualVelChange()
    {
        manualVelChangeRb.velocity += VelChange; 
    }
    #endregion
}
