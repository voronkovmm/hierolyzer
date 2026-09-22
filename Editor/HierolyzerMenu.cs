using Hierolyzer.Runtime;
using UnityEditor;
using UnityEngine;

namespace Hierolyzer.Editor
{
    internal static class HierolyzerMenu
    {
        [MenuItem(Consts.Paths.CreateHeader, false, 0)]
        public static void CreateHeader()
        {
            var go = new GameObject("NEW HEADER");
            go.AddComponent<HieroHeader>();

            Undo.RegisterCreatedObjectUndo(go, "Create Header");
            Selection.activeGameObject = go;
        }
        
        [MenuItem(Consts.Paths.ConvertToHeader, false, 0)]
        public static void ConvertToHeader()
        {
            var go = Selection.activeGameObject;
            if (go == null || go.TryGetComponent<HieroHeader>(out _)) return;

            Undo.AddComponent<HieroHeader>(go);
        }
        
        [MenuItem(Consts.Paths.RevertHeader, false, 0)]
        public static void RevertHeader()
        {
            var go = Selection.activeGameObject;
            if (go == null || !go.TryGetComponent<HieroHeader>(out var header)) return;

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Revert Header");
            int group = Undo.GetCurrentGroup();

            Undo.RegisterCompleteObjectUndo(go, "Revert Header");
            if (go.CompareTag(Consts.Tags.EditorOnly))
                go.tag = Consts.Tags.Untagged;
            Undo.DestroyObjectImmediate(header);

            Undo.CollapseUndoOperations(group);
        }
    }
}