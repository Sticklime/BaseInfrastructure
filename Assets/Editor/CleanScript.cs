using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CleanMissingScript : EditorWindow
    {
        [MenuItem("Auto/CleanMissingScript")]
        private static void FindAndRemoveMissingInSelected()
        {
            var deepSelection = EditorUtility.CollectDeepHierarchy(Selection.gameObjects);
            var compCount = 0;
            var goCount = 0;
            
            foreach (var script in deepSelection)
            {
                if (script is not GameObject currentGameObject) 
                    continue;
                
                var count = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(currentGameObject);

                if (count <= 0)
                    continue;
                
                Undo.RegisterCompleteObjectUndo(currentGameObject, "Remove missing scripts");
                GameObjectUtility.RemoveMonoBehavioursWithMissingScript(currentGameObject);
                compCount += count;
                goCount++;
            }

            Debug.Log($"Found and removed {compCount} missing scripts from {goCount} GameObjects");
        }
    }
}