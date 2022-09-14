using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class ForcelingImportProcessor : AssetPostprocessor
{
    public ForcelingImportProcessorClass DefaultProfile;
    public static ForcelingImportProcessorClass SelectedProfile;

    public string FbxSuffix;
    public string NormalSuffix;
    public string SkySuffix;
    static string DataPath = Application.dataPath + "/Editor/Forceling/ForcelingImportProcessor/ForcelingImportProcessor_Data.txt";
    static string RelDataPath = DataPath.Substring(Application.dataPath.Length - "Assets".Length);
    public static string DataContent;
    public bool hasFbxID;

    public void OnPreprocessModel()
    {
        if (SelectedProfile == null)
        {
            CheckDataFile();
            ImportFBX();
        }
        else
        {
            ImportFBX();
        }
    }

    
    public void OnPreprocessTexture()
    {
        if (SelectedProfile == null)
        {
            CheckDataFile();
            ImportTexture();
        }
        else
        {
            ImportTexture();
        }
    }



    [MenuItem("Forceling/Create Import Processor Data file",false, 100)]
    static void CreateDataFile()
    {
        //CREATE DATA FILE


        if(DataContent == null)
        {
            CheckDataFile();
        }

        if (!File.Exists(DataPath))
        {
            File.WriteAllText(DataPath, "");
            //ADD CONTENT TO FILE
            File.WriteAllText(DataPath, DataContent);
            //REIMPORT DATA FILE
        }
        AssetDatabase.ImportAsset(RelDataPath);
    }

    [MenuItem("Forceling/Find Import Processor Profile", false, 2)]
    static void FindProfile()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Import Processor Profile", "", "");

        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            SelectedProfile = (ForcelingImportProcessorClass)AssetDatabase.LoadAssetAtPath(relPath, typeof(ForcelingImportProcessorClass));

            //CONTENT FOR DATA FILE
            string SelectedProfilePath = relPath;
            //ADD CONTENT TO FILE
            File.WriteAllText(DataPath, SelectedProfilePath);

            if (SelectedProfile)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }

            AssetDatabase.ImportAsset(RelDataPath);
        }
    }

    [MenuItem("Forceling/New Import Processor Profile", false, 1)]
    static void NewProfile()
    {
        //WHEN DETECTED DATA LEADS TO NON EXISTING FILE
        ForcelingImportProcessorClass asset = ScriptableObject.CreateInstance<ForcelingImportProcessorClass>();
        AssetDatabase.CreateAsset(asset, "Assets/Editor/Forceling/ForcelingImportProcessor/New_ForcelingImportProcessor_Profile.asset");
        AssetDatabase.SaveAssets();
    }

    static void CheckDataFile()
    {
        if (File.Exists(DataPath))
        {
            DataContent = File.ReadAllText(DataPath);

            if (File.Exists(DataContent))
            {
                if (DataContent == "Assets/Editor/Forceling/ForcelingImportProcessor/ForcelingImportProcessor_Profile_Default.asset")
                {
                    SelectedProfile = (ForcelingImportProcessorClass)AssetDatabase.LoadAssetAtPath(DataContent, typeof(ForcelingImportProcessorClass));
                }
                else
                {
                    //WHEN DATA IS EMPTY
                    FindProfile();
                }
            }
            else
            {
                //WHEN DETECTED DATA LEADS TO NON EXISTING FILE
                ForcelingImportProcessorClass asset = ScriptableObject.CreateInstance<ForcelingImportProcessorClass>();
                AssetDatabase.CreateAsset(asset, "Assets/Editor/Forceling/ForcelingImportProcessor/ForcelingImportProcessor_Profile_Default.asset");
                AssetDatabase.SaveAssets();

                SelectedProfile = (ForcelingImportProcessorClass)AssetDatabase.LoadAssetAtPath("Assets/Editor/Forceling/ForcelingImportProcessor/ForcelingImportProcessor_Profile_Default.asset", typeof(ForcelingImportProcessorClass));
            }

        }
        else
        {
            EditorUtility.DisplayDialog("Import Processor Data Not Found!", "The needed Import processor data file was not found, a new one will be created", "OK");
            CreateDataFile();
        }
    }

    public void ImportFBX()
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        hasFbxID = lowerCaseAssetPath.IndexOf(SelectedProfile.FbxSuffix) != -1;

        ModelImporter FbxImporter = (ModelImporter)assetImporter;

        //IMPORTING .FBX FILES WITH MATERIAL MODE BASED ON SELECTED PROFILE
        if (hasFbxID)
        {
            //MATERIAL MODE
            if (SelectedProfile.UseEmbeddedMaterials == true)
            {
                FbxImporter.materialLocation = ModelImporterMaterialLocation.InPrefab;
            }
            else
            {
                FbxImporter.materialLocation = ModelImporterMaterialLocation.External;
            }
            //IMPORT CAMERAS
            if (SelectedProfile.ImportCamera == true)
            {
                FbxImporter.importCameras = true;
            }
            else
            {
                FbxImporter.importCameras = false;
            }
            //IMPORT LIGHTS
            if (SelectedProfile.ImportLights == true)
            {
                FbxImporter.importLights = true;
            }
            else
            {
                FbxImporter.importLights = false;
            }
        }
    }

    public void ImportTexture()
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        bool hasNormalID = lowerCaseAssetPath.IndexOf(SelectedProfile.NormalMapSuffix) != -1;
        bool hasSkyID = lowerCaseAssetPath.IndexOf(SelectedProfile.SkyboxSuffix) != -1;

        TextureImporter NormalImporter = (TextureImporter)assetImporter;
        TextureImporter SkyImporter = (TextureImporter)assetImporter;

        //IMPORTING AS NORMAL MAPS
        if (hasNormalID && NormalImporter.textureType != TextureImporterType.NormalMap)
        {
            NormalImporter.textureType = TextureImporterType.NormalMap;
        }

        //IMPORTING FILES AS CUBEMAPS WITH REPEATING WRAPMODE
        if (hasSkyID)
        {
            SkyImporter.textureType = TextureImporterType.Default;
            SkyImporter.textureShape = TextureImporterShape.TextureCube;
            SkyImporter.wrapMode = TextureWrapMode.Repeat;
        }
    }
}
