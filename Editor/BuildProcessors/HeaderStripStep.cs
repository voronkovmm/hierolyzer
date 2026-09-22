using Hierolyzer.Runtime;
using UnityEngine;

namespace Hierolyzer.Editor
{
    internal class HeaderStripStep : IHierarchyBuildStep
    {
        public void Process(GameObject go)
        {
            if (go.TryGetComponent<HieroHeader>(out var header))
                Object.DestroyImmediate(header);
        }
    }
}
