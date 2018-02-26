using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(AudioManager))]
public class AudioDataEditor : Editor
{
    private AudioManager _audioManager;

    private void OnEnable()
    {
        _audioManager = target as AudioManager;
        if (_audioManager.AudioData == null)
        {
            _audioManager.AudioData = new SAudioData();
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ImportAndExport(_audioManager, _audioManager.gameObject.name);
    }

    private void ImportAndExport(AudioManager am, string name)
    {
        // import button
        if(GUILayout.Button("Import")){
            SAudioData getData = null;
            getData = Resources.Load(PathTool.txtPath + "dynConfig_model_" + name) as SAudioData;
            getData = Instantiate(getData) as SAudioData;
            if(getData != null){
                am.AudioData = getData;
            }
        }

        // export button
        if(GUILayout.Button("Export")){
            string dataPath = "Assets/Resources/" + PathTool.txtPath;
            string filePath = dataPath + "dynConfig_model_" + name + ".asset";
            if(!Directory.Exists(dataPath)){
                Directory.CreateDirectory(dataPath);
            }
            if(File.Exists(filePath)){
                AssetDatabase.DeleteAsset(filePath);
                AssetDatabase.SaveAssets();
            }
            SAudioData newData = Instantiate(am.AudioData) as SAudioData;
            AssetDatabase.CreateAsset(newData, filePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
