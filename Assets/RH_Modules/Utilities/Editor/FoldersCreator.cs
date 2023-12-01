using RH_Modules.Utilities.Extensions;
using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

namespace RH_Modules.Utilities.Editor
{
    public static class FoldersCreator
    {
        private static readonly string[] _folders = 
        {
            "Logic",
            "Content",
            "Content/Scenes",
            "Content/Prefabs",
            "Content/Materials",
            "Content/Sprites",
            "Content/Resources",
        };
        
        [MenuItem("⚙ Utilities/Create default folders")]
        private static void CreateDefaultFolders()
        {
            string projectFolderPath = Combine(dataPath, "_Project");

            CreateDirectory(projectFolderPath);
            _folders.ForEach(x => CreateDirectory(Combine(projectFolderPath, x)));
            Refresh();
        }
    }
}
