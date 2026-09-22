using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hierolyzer.Editor
{
    internal class BuildProcessor : IProcessSceneWithReport
    {
        private static readonly IHierarchyBuildStep[] Steps =
        {
            new HeaderStripStep()
        };

        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            if (!BuildPipeline.isBuildingPlayer) return;

            foreach (var root in scene.GetRootGameObjects())
                ProcessRecursive(root);
        }

        private static void ProcessRecursive(GameObject go)
        {
            foreach (var step in Steps)
                step.Process(go);

            foreach (Transform child in go.transform)
                ProcessRecursive(child.gameObject);
        }
    }
}
