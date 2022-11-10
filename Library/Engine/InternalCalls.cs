using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class InternalCalls
{
    #region Time

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Time_GetDeltaTime();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Time_GetGameTime();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern long Time_GetCurrentTime();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int Time_GetFPS();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PauseDT();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UnPauseDT();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsDTPaused();

    #endregion

    #region Camera

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetViewPortSize(ulong entity, out Vector2 outresult);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetViewPortSize(ulong entity, ref Vector2 invalue);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetViewPortOffset(ulong entity, out Vector2 outresult);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetViewPortOffset(ulong entity, ref Vector2 invalue);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetUpVector(ulong entity, out Vector3 outresult);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetRightVector(ulong entity, out Vector3 outresult);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetForwardVector(ulong entity, out Vector3 outresult);

    /*[MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_GetOrientation(ulong entity, out Vector3 outresult);*/

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetPitch(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetPitch(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetYaw(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetYaw(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetRoll(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetRoll(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetZNear(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetZNear(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetZFar(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetZFar(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetAspectRatio(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetAspectRatio(ulong entity, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Camera_GetFieldOfView(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_SetFieldOfView(ulong entity, float value);

    #endregion

    #region Rigidbody
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Rigidbody_GetMass(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetMass(ulong entity, float mass);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetLinearVelocity(ulong entity, out Vector3 outVelocity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetLinearVelocity(ulong entity, ref Vector3 inVelocity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetAngularVelocity(ulong entity, out Vector3 outVelocity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetAngularVelocity(ulong entity, ref Vector3 inVelocity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetLocalInertiaTensor(ulong entity, out Vector3 outInertia);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetLocalInertiaTensor(ulong entity, ref Vector3 inInertia);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetLocalCenterOfMass(ulong entity, out Vector3 outCoord);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetLocalCenterOfMass(ulong entity, ref Vector3 inCoord);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_CalculateLocalCenterOfMass(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_CalculateLocalInertiaTensor(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_CalculateMass(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_CalculateMassProperties(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int Rigidbody_GetType(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetType(ulong entity, int type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool Rigidbody_IsGravityEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_EnableGravity(ulong entity, bool isEnabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool Rigidbody_IsAllowedToSleep(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetIsAllowedToSleep(ulong entity, bool isAllowedToSleep);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool Rigidbody_IsSleeping(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetIsSleeping(ulong entity, bool isSleeping);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Rigidbody_GetLinearDamping(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetLinearDamping(ulong entity, float linearDamping);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Rigidbody_GetAngularDamping(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetAngularDamping(ulong entity, float angularDamping);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetLinearLockFactor(ulong entity, out Vector3 outLockFactor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetLinearLockFactor(ulong entity, ref Vector3 inLockFactor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetAngularLockFactor(ulong entity, out Vector3 outLockFactor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_SetAngularLockFactor(ulong entity, ref Vector3 inLockFactor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyLocalForceAtCenterOfMass(ulong entity, ref Vector3 force);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyWorldForceAtCenterOfMass(ulong entity, ref Vector3 force);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyLocalForceAtLocalPosition(ulong entity, ref Vector3 force, ref Vector3 point);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyWorldForceAtLocalPosition(ulong entity, ref Vector3 force, ref Vector3 point);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyLocalForceAtWorldPosition(ulong entity, ref Vector3 force, ref Vector3 point);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_ApplyWorldForceAtWorldPosition(ulong entity, ref Vector3 force, ref Vector3 point);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetForce(ulong entity, out Vector3 force);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Rigidbody_GetTorque(ulong entity, out Vector3 torque);
    #endregion

    #region Transform
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetPosition(ulong entity, out Vector3 outPosition);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetPosition(ulong entity, ref Vector3 inPosition);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetRotation(ulong entity, out Vector3 outRotation);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetRotation(ulong entity, ref Vector3 inRotation);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetScale(ulong entity, out Vector3 outScale);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetScale(ulong entity, ref Vector3 inScale);

    /*
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetTransformZDepth_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetTransformZDepth_Native(ulong entity, string inZDepth);
    
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GetGlobalTransform_Native(ulong entity, out Transform outTransform);
    */

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_Translate(ulong entity, ref Vector3 inTranslation);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_Rotate(ulong entity, ref Vector3 inRotate);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_ScaleUp(ulong entity, ref Vector3 inScale);
    #endregion

    #region Debug

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Log(string message);

    #endregion

    #region Input

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsKeyDown(char key);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsKeyTriggered(char key);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool AnyKeyTriggered();

    #endregion

    #region GameObject

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong CreateEntity_Native(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DestroyEntity_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityParentID_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityChildID_Native(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityIDByName_Native(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetEntityNameByID_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void EnableDisable_Native(ulong entity, bool isEnabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasComponent_Native(ulong entity, Type type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool AddComponent_Native(ulong entity, Type type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void AddTransform_Native(ulong entity);

    #endregion
}