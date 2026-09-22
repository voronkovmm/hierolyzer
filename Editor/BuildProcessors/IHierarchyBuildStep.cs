using UnityEngine;

namespace Hierolyzer.Editor
{
    internal interface IHierarchyBuildStep
    {
        void Process(GameObject go);
    }
}
