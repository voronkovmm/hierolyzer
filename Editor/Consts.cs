using UnityEngine;

namespace Hierolyzer.Editor
{
    internal static class Consts
    {
        internal static class Colors
        {
            public static readonly Color DarkThemeBackground = new(0.22f, 0.22f, 0.22f);
            public static readonly Color LightThemeBackground = new(0.76f, 0.76f, 0.76f);
        }

        internal static class Paths
        {
            public const string Root = "GameObject/Hierolyzer";

            public const string CreateHeader    = Root + HeadersDirectory + "/Create";
            public const string ConvertToHeader = Root + HeadersDirectory + "/Convert";
            public const string RevertHeader    = Root + HeadersDirectory + "/Revert";

            private const string HeadersDirectory = "/Headers";
        }

        internal static class Tags
        {
            public const string EditorOnly = "EditorOnly";
            public const string Untagged   = "Untagged";
        }
    }
}