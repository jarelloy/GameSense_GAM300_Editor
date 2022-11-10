using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RigidBody : Component
{
    public float mass
    {
        get
        {
            return InternalCalls.Rigidbody_GetMass(entity);
        }
        set
        {
            InternalCalls.Rigidbody_SetMass(entity, value);
        }
    }

    public Vector3 force
    {
        get
        {
            InternalCalls.Rigidbody_GetForce(entity, out Vector3 result);
            return result;
        }
    }

    public Vector3 torque
    {
        get
        {
            InternalCalls.Rigidbody_GetTorque(entity, out Vector3 result);
            return result;
        }
    }

    public Vector3 velocity
    {
        get
        {
            InternalCalls.Rigidbody_GetLinearVelocity(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetLinearVelocity(entity, ref value);
        }
    }

    public Vector3 angularVelocity
    {
        get
        {
            InternalCalls.Rigidbody_GetAngularVelocity(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetAngularVelocity(entity, ref value);
        }
    }

    public Vector3 centerOfMass
    {
        get
        {
            InternalCalls.Rigidbody_GetLocalCenterOfMass(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetLocalCenterOfMass(entity, ref value);
        }
    }

    public Vector3 inertiaTensor
    {
        get
        {
            InternalCalls.Rigidbody_GetLocalInertiaTensor(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetLocalInertiaTensor(entity, ref value);
        }
    }

    public int rigidbodyType
    {
        get
        {
            return InternalCalls.Rigidbody_GetType(entity);
        }
        set
        {
            InternalCalls.Rigidbody_SetType(entity, value);
        }
    }

    public bool isGravityEnabled
    {
        get
        {
            return InternalCalls.Rigidbody_IsGravityEnabled(entity);
        }
        set
        {
            InternalCalls.Rigidbody_EnableGravity(entity, value);
        }
    }

    public bool isAllowedToSleep
    {
        get
        {
            return InternalCalls.Rigidbody_IsAllowedToSleep(entity);
        }
    }

    public bool isSleeping
    {
        get
        {
            return InternalCalls.Rigidbody_IsSleeping(entity);
        }
        set
        {
            InternalCalls.Rigidbody_SetIsSleeping(entity, value);
        }
    }

    public float linearDamping
    {
        get
        {
            return InternalCalls.Rigidbody_GetLinearDamping(entity);
        }
        set
        {
            InternalCalls.Rigidbody_SetLinearDamping(entity, value);
        }
    }

    public float angularDamping
    {
        get
        {
            return InternalCalls.Rigidbody_GetAngularDamping(entity);
        }
        set
        {
            InternalCalls.Rigidbody_SetAngularDamping(entity, value);
        }
    }

    public Vector3 linearLockFactor
    {
        get
        {
            InternalCalls.Rigidbody_GetLinearLockFactor(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetLinearLockFactor(entity, ref value);
        }
    }

    public Vector3 angularLockFactor
    {
        get
        {
            InternalCalls.Rigidbody_GetAngularLockFactor(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Rigidbody_SetAngularLockFactor(entity, ref value);
        }
    }

    public void SetGravity(bool isEnabled)
    {
        InternalCalls.Rigidbody_EnableGravity(entity, isEnabled);
    }

    public void SetIsAllowedToSleep(bool isAllowedToSleep)
    {
        InternalCalls.Rigidbody_SetIsAllowedToSleep(entity, isAllowedToSleep);
    }

    // To arrange these AddForce into more suitable function names similar to Unity (?)
    public void AddLocalForceAtCOM(ref Vector3 force)
    {
        InternalCalls.Rigidbody_ApplyLocalForceAtCenterOfMass(entity, ref force);
    }

    public void AddWorldForceAtCOM(ref Vector3 force)
    {
        InternalCalls.Rigidbody_ApplyWorldForceAtCenterOfMass(entity, ref force);
    }

    public void AddLocalForceAtLocalPosition(ref Vector3 force, ref Vector3 point)
    {
        InternalCalls.Rigidbody_ApplyLocalForceAtLocalPosition(entity, ref force, ref point);
    }

    public void AddWorldForceAtLocalPosition(ref Vector3 force, ref Vector3 point)
    {
        InternalCalls.Rigidbody_ApplyWorldForceAtLocalPosition(entity, ref force, ref point);
    }

    public void AddLocalForceAtWorldPosition(ref Vector3 force, ref Vector3 point)
    {
        InternalCalls.Rigidbody_ApplyLocalForceAtLocalPosition(entity, ref force, ref point);
    }

    public void AddWorldForceAtWorldPosition(ref Vector3 force, ref Vector3 point)
    {
        InternalCalls.Rigidbody_ApplyWorldForceAtWorldPosition(entity, ref force, ref point);
    }

    /* // low priority functions; will get to sorting them soon
    Rigidbody_CalculateLocalCenterOfMass
    Rigidbody_CalculateLocalInertiaTensor
    Rigidbody_CalculateMass
    Rigidbody_CalculateMassProperties
    */
}
