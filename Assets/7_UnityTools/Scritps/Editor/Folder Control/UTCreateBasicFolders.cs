using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UTCreateBasicFolders: EditorWindow{

    static List<string> m_FolderNames = new List<string>();

    static UTCreateBasicFolders m_Window;

    /// <summary>
    /// Create basic folders under the selected folder
    /// </summary>
    /// <remarks>
    /// Only Static function can be a menu
    /// </remarks>
    [MenuItem("UnityTools/Create Basic Folders %&c")]
    static void CreateBasicFoldersMenu()
    {
        Debug.Log("Start Create Basic Folders");

        if (m_Window == null)
        {
        
            m_Window = (UTCreateBasicFolders)GetWindow(typeof(UTCreateBasicFolders));
        }
        
        // Set hardcoded folder name
      if(EditorPrefs.HasKey("UTCreateBasicFolders"))
      {
         // To Be Added	
      }
      else
      {
           m_FolderNames.Add("Scenes");
   
           m_FolderNames.Add("Scritps");
   
           m_FolderNames.Add("Models");
           m_FolderNames.Add("Materials");
           m_FolderNames.Add("Shaders");
           m_FolderNames.Add("Textures");
   
         m_FolderNames.Add("Prefabs");
      }
      
        m_Window.Show();           
    }


    /// <summary>
    /// GUI on editor window
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("Create below directories under the selected folder(s)");

        for (int i = 0; i < m_FolderNames.Count; i++)
      {
            m_FolderNames[i] = EditorGUILayout.TextField(m_FolderNames[i]);
      }

        // Add more folders
        if (GUILayout.Button("Add a folder to list"))
        {
            m_FolderNames.Add("");
            m_FolderNames[m_FolderNames.Count - 1] = EditorGUILayout.TagField("");
        }

        // Remove folders
        if (GUILayout.Button("Remove a folder from list"))
        {
            m_FolderNames.RemoveAt(m_FolderNames.Count - 1);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Separator();

        if (GUILayout.Button("Create Folders"))
        {
            CreateFolders();
        }

    }

    /// <summary>
    /// The real function which will create folders
    /// </summary>
    void CreateFolders()
    {
        Debug.Log("Create Basic Folders");

        // Create folder only on top level of selection
        foreach (UnityEngine.Object o in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel))
        {
            string root = AssetDatabase.GetAssetPath(o);
            // Create directory to store generated materials.


            foreach (string folderName in m_FolderNames)
            {
                string path = root + "/" + folderName + "/";

                if (!Directory.Exists(path))
                {
                    Debug.Log("Create folder: " + path);
                    Directory.CreateDirectory(path);
                }
                else
                {
                    Debug.Log("Create folder fail. Already Exist: " + path);
                }
            }
            
            // Refresh AssetDatabase. So we can see the change
            AssetDatabase.Refresh();
        }
    }
}
