using System.Collections.Generic;
using Hierolyzer.Runtime;
using UnityEditor;
using UnityEngine;

namespace Hierolyzer.Editor.Drawers
{
    [InitializeOnLoad]
    internal static class HierarchyHeaderDrawer
    {
        private const string RenameControl = "RenameOverlayField";
        private static readonly Dictionary<HieroHeader, GUIStyle> _styleCache = new();

        static HierarchyHeaderDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += _styleCache.Clear;
        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            var header = go?.GetComponent<HieroHeader>();
            if (header == null) return;

            var isRenaming = Selection.Contains(instanceID) && GUI.GetNameOfFocusedControl() == RenameControl;
            if (isRenaming)
                return;
            
            var backgroundColor = EditorGUIUtility.isProSkin
                ? Consts.Colors.DarkThemeBackground
                : Consts.Colors.LightThemeBackground;
            EditorGUI.DrawRect(selectionRect, backgroundColor);
            EditorGUI.DrawRect(selectionRect, header.color);
            
            var style = GetStyle(header);
            EditorGUI.LabelField(selectionRect, go.name.ToUpper(), style);
        }
        
        private static GUIStyle GetStyle(HieroHeader header)
        {
            if (!_styleCache.TryGetValue(header, out var style))
            {
                style = new GUIStyle();
                _styleCache[header] = style;
            }

            style.alignment = header.textAnchor;
            style.normal.textColor = header.textColor;
            style.fontStyle = header.fontStyle;

            return style;
        }
    }
}