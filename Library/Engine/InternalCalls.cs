using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class InternalCalls
{
    #region Layer

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetLayerName(ulong id);

    #endregion

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
    public static extern void Particle_Burst(ulong entity, int count, float probability);

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_GetOffset(ulong entity, int index, out Vector3 outoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_SetOffset(ulong entity, int index, ref Vector3 inoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BoxCollider_SetFriction(ulong entity, int index, float friction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float BoxCollider_GetFriction(ulong entity, int index);

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_GetOffset(ulong entity, int index, out Vector3 outoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_SetOffset(ulong entity, int index, ref Vector3 inoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CapsuleCollider_SetFriction(ulong entity, int index, float friction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float CapsuleCollider_GetFriction(ulong entity, int index);

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SphereCollider_GetOffset(ulong entity, int index, out Vector3 outoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SphereCollider_SetOffset(ulong entity, int index, ref Vector3 inoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SphereCollider_SetFriction(ulong entity, int index, float friction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float SphereCollider_GetFriction(ulong entity, int index);

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
    public static extern void Animator_PlayAnim(ulong entity, string name, bool toBlend, float blendduration, bool staticBlend);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Pause(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Stop(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_Play(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Animator_SetAnimStateSpeed(ulong entity, string stateName, float speed);

    #endregion

    #region Physics

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Physics_Raycast(ref Vector3 inraypos, ref Vector3 inraydir, float raylength, out ulong entityHit, out Vector3 hitpos, out Vector3 hitnormal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Physics_RaycastLayers(string layer, bool end, ref Vector3 inraypos, ref Vector3 inraydir, float raylength, out ulong entityHit, out Vector3 hitpos, out Vector3 hitnormal);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Physics_GetGravity(out Vector3 outgravity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Physics_SetGravity(ref Vector3 ingravity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Physics_IsColliding(ulong entity1, ulong entity2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Physics_GetContactPoint(ulong entity1, ulong entity2, out Vector3 contactPt);

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
    internal static extern float Time_GetFixedDeltaTime();

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Time_GetUnscaledDeltaTime();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float Time_GetTimeScale();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Time_SetTimeScale(float scale);

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Camera_Shake(ulong entity, ref Vector2 dir, float intensity, float fade);

    #endregion

    #region UIImage

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetEnabled(ulong entity, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float UIImage_GetWidth(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float UIImage_SetWidth(ulong entity, float inwidth);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float UIImage_GetHeight(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float UIImage_SetHeight(ulong entity, float inheight);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_GetColor(ulong entity, out Vector4 outcolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetColor(ulong entity, ref Vector4 incolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_GetRemapUVX(ulong entity, out Vector2 outremapx);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetRemapUVX(ulong entity, ref Vector2 inremapx);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_GetRemapUVY(ulong entity, out Vector2 outremapy);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetRemapUVY(ulong entity, ref Vector2 inremapy);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_GetCurrentFrame(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_SetCurrentFrame(ulong entity, int incurrentframe);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_GetStartFrame(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_SetStartFrame(ulong entity, int instartframe);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_GetEndFrame(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_SetEndFrame(ulong entity, int inendframe);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_GetLooping(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_SetLooping(ulong entity, bool inlooping);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_GetFPS(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int UIImage_SetFPS(ulong entity, int infps);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_GetReverseAnim(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_SetReverseAnim(ulong entity, bool inreverseanim);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_PlayAnim(ulong entity, bool looping, int start, int end, int current);
    
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UIImage_StopAnim(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UIImage_IsAnimPlaying(ulong entity);

    #endregion

    #region PointLight

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool PointLight_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PointLight_SetEnabled(ulong entity, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float PointLight_GetIntensity(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PointLight_SetIntensity(ulong entity, float inintensity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float PointLight_GetRadius(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PointLight_SetRadius(ulong entity, float inradius);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PointLight_GetColor(ulong entity, out Vector3 outcolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PointLight_SetColor(ulong entity, ref Vector3 incolor);

    #endregion

    #region ShaderGraphComponent

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool ShaderGraphComponent_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetEnabled(ulong entity, int index, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetOverwriteParameter(ulong entity, int index, string param_name, bool overwrite);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetParameterValueFloat(ulong entity, int index, string param_name, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetParameterValueVec2(ulong entity, int index, string param_name, ref Vector2 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetParameterValueVec3(ulong entity, int index, string param_name, ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_SetParameterValueVec4(ulong entity, int index, string param_name, ref Vector4 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float ShaderGraphComponent_GetParameterValueFloat(ulong entity, int index, string param_name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_GetParameterValueVec2(ulong entity, int index, string param_name, out Vector2 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_GetParameterValueVec3(ulong entity, int index, string param_name, out Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ShaderGraphComponent_GetParameterValueVec4(ulong entity, int index, string param_name, out Vector4 value);


    #endregion

    #region UICollider

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool UICollider_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_SetEnabled(ulong entity, bool inenabled);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern float UICollider_GetRadius(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_SetRadius(ulong entity, float inradius);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_GetOffset(ulong entity, out Vector3 outoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_SetOffset(ulong entity, ref Vector3 inoffset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_GetHalfExtent(ulong entity, out Vector3 outhalfextent);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UICollider_SetHalfExtent(ulong entity, ref Vector3 inhalfextent);

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string TextObject_GetText(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void TextObject_SetText(ulong entity, string intext);

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

    #region Window

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Window_GetWidth();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Window_GetHeight();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Window_GetCursorVisibility();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Window_SetCursorVisibility(bool visible);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Window_LockCursor(ref Vector2Int position);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Window_UnlockCursor();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Window_IsCursorLocked();

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

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Input_GetMouseXDelta();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int Input_GetMouseYDelta();

    #endregion

    #region GameObject

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong CreateEntity_Native(ulong id);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong CreateEntityUI_Native(ulong id);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong CreateEntityPrefab_Native(string prefab);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DestroyEntity_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityLayerID(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityParentID_Native(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong GetEntityChildID_Native(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetEntityChildrenCount_Native(ulong entity);

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
    public static extern bool HasScriptComponent_Native(ulong entity, string scriptName);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern object GetScriptComponent_Native(ulong entity, string scriptName);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern object GetGlobalScriptComponent_Native(string scriptName);

    #endregion

    #region Audio

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_EnableDisable(ulong entity, int index, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_GetEnabled(ulong entity, int index);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Audio_Play(ulong entity, int index);
    
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Audio_IsPlaying(ulong entity, int index);

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
    public static extern void Audio_SetSoundGroupVolume(int sg, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Audio_GetSoundGroupVolume(int sg);

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

    #region Material

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_EnableDisable(ulong entity, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Material_GetEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong Material_GetMaterialAsset(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetMaterialAsset(ulong entity, ulong material_id);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Material_GetOverwriteMaterialReference(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetOverwriteMaterialReference(ulong entity, bool overwrite);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_GetDiffuseTint(ulong entity, out Vector4 diffuse);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetDiffuseTint(ulong entity, ref Vector4 diffuse);

	[MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Material_GetGlossiness(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetGlossiness(ulong entity, float glossiness);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Material_GetSpecular(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetSpecular(ulong entity, float specular);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Material_GetEmissionEnabled(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetEmissionEnabled(ulong entity, bool enableemission);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_GetEmissionColor(ulong entity, out Vector3 emissioncolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetEmissionColor(ulong entity, ref Vector3 emissioncolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Material_GetEmissionIntensity(ulong entity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetEmissionIntensity(ulong entity, float emissionintensity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong Material_GetTexture(ulong entity, int type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Material_SetTexture(ulong entity, int type, ulong textureid);

    #endregion

    #region MaterialObject

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_GetDiffuseTint(ulong materialid, out Vector4 diffuse);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetDiffuseTint(ulong materialid, ref Vector4 diffuse);

	[MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float MaterialObject_GetGlossiness(ulong materialid);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetGlossiness(ulong materialid, float glossiness);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float MaterialObject_GetSpecular(ulong materialid);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetSpecular(ulong materialid, float specular);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool MaterialObject_GetEmissionEnabled(ulong materialid);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetEmissionEnabled(ulong materialid, bool enableemission);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_GetEmissionColor(ulong materialid, out Vector3 emissioncolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetEmissionColor(ulong materialid, ref Vector3 emissioncolor);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float MaterialObject_GetEmissionIntensity(ulong materialid);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetEmissionIntensity(ulong materialid, float emissionintensity);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong MaterialObject_GetTexture(ulong materialid, int type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void MaterialObject_SetTexture(ulong materialid, int type, ulong textureid);

    #endregion
}