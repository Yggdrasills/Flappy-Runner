using System.IO;
using UnityEditor;
using UnityEngine;

namespace BaseCore.Utils.Editor
{
    public class NamespaceModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", string.Empty);

            if (!path.Contains(".cs")) return;

            int index = Application.dataPath.LastIndexOf("Assets");
            path = Application.dataPath.Substring(0, index) + path;

            if (!File.Exists(path)) return;

            string fileContent = File.ReadAllText(path);

            fileContent = fileContent.Replace("#NAMESPACE#", BuildNamespaceByPath(path));

            File.WriteAllText(path, fileContent);
            AssetDatabase.Refresh();
        }

        private static string BuildNamespaceByPath(string path)
        {
            string[] pathFolders = path.Replace(Application.dataPath, string.Empty).Split('/');
            string nameSpace = "FlappyRunner.";

            for (int i = 2; i < pathFolders.Length - 1; i++)
            {
                pathFolders[i] = pathFolders[i].Replace(' ', '_');
                nameSpace += pathFolders[i] + ".";
            }

            return nameSpace.Substring(0, nameSpace.Length - 1);
        }
    }
}