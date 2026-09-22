using UnityEngine;

namespace Hierolyzer.Runtime
{
    [DisallowMultipleComponent]
    public class HieroHeader : MonoBehaviour
    {
        private const string EditorOnlyTag = "EditorOnly";
        private const string UntaggedTag = "Untagged";

        [Tooltip("Header color")]
        public Color color = new Color(0.2f, 0.4f, 0.8f, 1f);
        public Color textColor = Color.white;
        public FontStyle fontStyle = FontStyle.Normal;
        public TextAnchor textAnchor = TextAnchor.MiddleCenter;
        [Tooltip("If enabled, the header is removed from the build together with all its child objects.")]
        public bool removeFromBuild;

#if UNITY_EDITOR
        private void Reset() => SyncTag();
        private void OnValidate() => SyncTag();

        private void SyncTag()
        {
            var isEditorOnly = gameObject.CompareTag(EditorOnlyTag);

            if (removeFromBuild && !isEditorOnly)
                gameObject.tag = EditorOnlyTag;
            else if (!removeFromBuild && isEditorOnly)
                gameObject.tag = UntaggedTag;

            if (removeFromBuild && transform.childCount > 0)
                Debug.LogWarning($"Header '{name}' has child objects. They will be removed from the build together with the header!", this);
        }
#endif
    }
}