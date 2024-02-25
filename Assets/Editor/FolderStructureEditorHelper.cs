using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FolderStructureEditorHelper : EditorWindow
{
    string name;
    [MenuItem("Window/Outland/FolderStructure/Gameplay")]
    public static void showWindow()
    {
        GetWindow<FolderStructureEditorHelper>("Gameplay");
    }

    void OnGUI()
    {
        name = EditorGUILayout.TextField("Folder Name", name);
        if(GUILayout.Button("Create"))
        {
            CreateFeatureFolders(name);
        }
    }

    private static void CreateFeatureFolders(string folderName)
    {
        List<string> folders = new List<string>()
            {
                "Scripts",
                "Animations",
                "Materials",
                "Prefabs",
                "Scenes",
                "Sounds",
                "Textures",
                "VFX",
            };

        CreateFolders(folders, folderName);
    }

    private static void CreateFolders(List<string> folders, string folderName)
    {


        string path = "Assets/Features/Gameplay";
        AssetDatabase.CreateFolder(path, folderName);
        path = path + "/" + folderName;

        if (!string.IsNullOrEmpty(path))
        {
            if (Directory.Exists(path))
            {
                Debug.Log($"Folder = {path}");
                foreach (var item in folders)
                {
                    if (!Directory.Exists(Path.Combine(path, item)))
                        AssetDatabase.CreateFolder(path, item);

                }
            }
            else
            {
                Debug.Log("File");
            }
        }
        else
        {
            Debug.Log("Not in assets folder");
        }
    }

}

