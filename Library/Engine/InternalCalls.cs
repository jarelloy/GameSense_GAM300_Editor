using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class InternalCalls
{
    #region Mesh

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Mesh_EnableDisable(ulong entity, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Mesh_GetEnabled(ulong entity);

    #endregion

    #region Particles

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Particle_Start(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Particle_Stop(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Particle_Restart(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Particle_EnableDisabled(ulong entity, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Particle_GetEnabled(ulong entity);

    #endregion

    #region BoxCollider

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool BoxCollider_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_GetHalfExtents(ulong entity, int index, out Vector3 outvec3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_SetHalfExtents(ulong entity, int index, ref Vector3 invec3);

    #endregion

    #region CapsuleCollider

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool CapsuleCollider_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float CapsuleCollider_GetRadius(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_SetRadius(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float CapsuleCollider_GetHalfHeights(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_SetHalfHeights(ulong entity, int index, float value);

    #endregion

    #region SphereCollider

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SphereCollider_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool SphereCollider_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float SphereCollider_GetRadius(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SphereCollider_SetRadius(ulong entity, int index, float value);

    #endregion

    #region MeshCollider

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MeshCollider_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool MeshCollider_GetEnabled(ulong entity, int index);

    #endregion

    #region AnimatorAgent

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Animator_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_EnableDisable(ulong entity, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_SetBool(ulong entity, string name, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Animator_GetBool(ulong entity, string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_SetFloat(ulong entity, string name, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Animator_GetFloat(ulong entity, string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_SetTrigger(ulong entity, string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_ResetTrigger(ulong entity, string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_PlayAnim(ulong entity, string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Pause(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Stop(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Play(ulong entity);

    #endregion

    #region Physics

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Physics_Raycast(ref Vector3 inraypos, ref Vector3 inraydir, float raylength, out ulong entityHit, out Vector3 hitpos, out Vector3 hitnormal);

    #endregion

    #region SceneManager

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string SceneManager_GetCurrentSceneName();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SceneManager_ChangeScene(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SceneManager_PreloadScene(string name, uint sleepDelay);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float SceneManager_GetPreloadingSceneLoadPercentage(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float SceneManager_GetPreloadingSceneInitPercentage(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool SceneManager_GetPreloadingSceneCompleted(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SceneManager_QuitGame();

    #endregion

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

    #region Graphics

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Graphics_GetAmbientIntensity();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Graphics_SetAmbientIntensity(float ambientIntensity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Graphics_GetAmbientColor(out Vector3 ambientColor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Graphics_SetAmbientColor(ref Vector3 ambientColor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Graphics_GetGamma();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Graphics_SetGamma(float gamma);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Graphics_GetExposure();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Graphics_SetExposure(float exposure);

    #endregion

    #region PostProcessing

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int PostProcessing_GetEnabled();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_SetEnabled(int value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_GetColorGrading(out ColorGrading bloom);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_SetColorGrading(ref ColorGrading bloom);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_GetBloom(out Bloom bloom);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_SetBloom(ref Bloom bloom);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_GetVignette(out Vignette bloom);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PostProcessing_SetVignette(ref Vignette bloom);

    #endregion

    #region Camera

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Camera_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Camera_EnableDisable(ulong entity, bool value);

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

    #region UIImage

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetEnabled(ulong entity, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_GetColor(ulong entity, out Vector4 outcolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetColor(ulong entity, ref Vector4 incolor);

    #endregion

    #region TextObject

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool TextObject_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void TextObject_SetEnabled(ulong entity, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void TextObject_GetColor(ulong entity, out Vector4 outcolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void TextObject_SetColor(ulong entity, ref Vector4 incolor);

    #endregion

    #region Rigidbody

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Rigidbody_EnableDisable(ulong entity, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Rigidbody_GetEnabled(ulong entity);

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

    #region UITransform
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_GetPosition(ulong entity, out Vector3 outPosition, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_SetPosition(ulong entity, ref Vector3 inPosition, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_GetRotation(ulong entity, out Vector3 outRotation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_SetRotation(ulong entity, ref Vector3 inRotation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_GetScale(ulong entity, out Vector3 outScale, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_SetScale(ulong entity, ref Vector3 inScale, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_Translate(ulong entity, ref Vector3 inTranslation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_Rotate(ulong entity, ref Vector3 inRotate, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UITransform_ScaleUp(ulong entity, ref Vector3 inScale, bool isGlobal);
    #endregion

    #region Transform
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetPosition(ulong entity, out Vector3 outPosition, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetPosition(ulong entity, ref Vector3 inPosition,  bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetRotation(ulong entity, out Vector3 outRotation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetRotation(ulong entity, ref Vector3 inRotation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetScale(ulong entity, out Vector3 outScale, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_SetScale(ulong entity, ref Vector3 inScale,  bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetForward(ulong entity, out Vector3 forward, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetUp(ulong entity, out Vector3 up, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_GetRight(ulong entity, out Vector3 right, bool isGlobal);
    /*
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetTransformZDepth_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetTransformZDepth_Native(ulong entity, string inZDepth);
    
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GetGlobalTransform_Native(ulong entity, out Transform outTransform);
    */

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_Translate(ulong entity, ref Vector3 inTranslation, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_Rotate(ulong entity, ref Vector3 inRotate, bool isGlobal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Transform_ScaleUp(ulong entity, ref Vector3 inScale, bool isGlobal);
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

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Input_GetMousePosition(out Vector2Int outPosition);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Input_GetMouseWheelDelta();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseLButton();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseMButton();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseRButton();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseLButtonTriggered();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseMButtonTriggered();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Input_GetMouseRButtonTriggered();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Input_GetMouseX();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Input_GetMouseY();

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
    public static extern int GetComponentsCount_Native(ulong entity, Type type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool AddComponent_Native(ulong entity, Type type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void AddTransform_Native(ulong entity);

    #endregion

    #region Audio

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Play(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Stop(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Mute(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Unmute(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Pause(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Unpause(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Audio_GetSoundGroup(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetSoundGroup(ulong entity, int value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetVolume(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetVolume(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetLoop(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetLoop(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetStereo(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetStereo(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetMinDistance(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetMinDistance(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetMaxDistance(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetMaxDistance(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetFadeIn(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetFadeIn(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetFadeOut(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetFadeOut(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetFadeInTimer(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetFadeInTimer(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetFadeOutTimer(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetFadeOutTimer(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetLPF(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetLPF(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetLPFCutoff(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetLPFCutoff(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetLPFResonance(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetLPFResonance(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetReverb(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetReverb(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetReverbDelay(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetReverbDelay(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetReverbFeedback(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetReverbFeedback(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetReverbWetLevel(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetReverbWetLevel(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetReverbDryLevel(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetReverbDryLevel(ulong entity, int index, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetDistortion(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetDistortion(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetDistortionLevel(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_SetDistortionLevel(ulong entity, int index, float value);

    #endregion
}