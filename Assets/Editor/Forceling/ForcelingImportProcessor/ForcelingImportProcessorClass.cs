using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_ForcelingImportProcessor_Profile", menuName = "Forceling/Import Processor Profile", order = 1)]
public class ForcelingImportProcessorClass : ScriptableObject
{
    [Header ("FBX Import Setting")]
    [Tooltip("The identifying label of your FBX files. This is used to find which files are fbx")]
    public string FbxSuffix = ".fbx";
    public bool UseEmbeddedMaterials = false;
    public bool ImportCamera = false;
    public bool ImportLights = false;

    [Space(10)]

    [Header("Normal Map Import Settings")]
    [Tooltip("The identifying label for your normal maps, this is used to find which files are supposed to be set as normal maps on import")]
    public string NormalMapSuffix = "_n.tga";

    [Space(10)]

    [Header("Skybox Import Settings")]
    [Tooltip("The identifying label for your skyboxes, this is used to find which files are supposed to be set as cubemaps")]
    public string SkyboxSuffix = "_sky.tga";
}
