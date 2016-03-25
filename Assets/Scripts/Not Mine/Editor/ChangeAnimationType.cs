using UnityEngine;
using UnityEditor;

class ChangeAnimationType
{
    enum AnimationType { Legacy = 1, Generic = 2, Humanoid = 3 }

    [MenuItem("Mecanim/Change Animation Clip Type")]
    static void DoChangeAnimationClipType()
    {
        AnimationClip clip = Selection.activeObject as AnimationClip;
        if (clip != null)
        {
            SerializedObject serializedClip = new SerializedObject(clip);
            SerializedProperty animationType = serializedClip.FindProperty("m_AnimationType");
            if (animationType == null)
            {
                Debug.Log("SerializedProperty m_AnimationType not found");
                return;
            }

            animationType.intValue = (int)AnimationType.Legacy;
            serializedClip.ApplyModifiedProperties();
        }
    }
}

