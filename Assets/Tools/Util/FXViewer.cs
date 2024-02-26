#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FXViewer : MonoBehaviour
{
    public Text curFXName;

    //public string path;

    private GameObject[] prefabs;

    public GameObject curFXInst;

    private void Awake()
    {
        //Prefabs
        prefabs = FolderUtil_Editor.LoadAtPathRecursive<GameObject>("Data/FX/VFX/Prefabs/");
        
        Debug.Log(prefabs);
    }

    public void OnSetPath()
    {
        //path = EditorUtility.OpenFolderPanel("打开特效文件夹", "", Application.dataPath + "/Data/FX/VFX/");
    }

    public void OnSelPrefab()
    {
        if (index < 0 || index >= prefabs.Length)
            return;

        Selection.activeGameObject = prefabs[index];
    }

    int index = -1;
    public void OnLeftClick()
    {
        if (prefabs.Length == 0)
            return;

        index--;
        if (index < 0)
        {
            index = prefabs.Length - 1;
        }

        Inst();
    }

    public void OnRightClick()
    {
        if (prefabs.Length == 0)
            return;

        index++;
        if (index >= prefabs.Length)
        {
            index = 0;
        }

        Inst();
    }

    public void OnPlaySel()
    {
        if (Selection.activeGameObject == null)
            return;

        if (curFXInst != null)
        {
            Destroy(curFXInst);
        }
        
        curFXInst = Instantiate(Selection.activeGameObject);

        curFXName.text = Selection.activeGameObject.name;

        index = Array.IndexOf(prefabs, Selection.activeGameObject);

        Debug.Log(index);
    }

    public void OnReplayClick()
    {
        if (index < 0 || index >= prefabs.Length)
            return;

        Inst();
    }

    void Inst()
    {
        if (curFXInst != null)
        {
            Destroy(curFXInst);
        }

        curFXInst = Instantiate(prefabs[index]);

        curFXName.text = prefabs[index].name;

        Selection.activeGameObject = prefabs[index];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            OnLeftClick();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            OnRightClick();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)
            || Input.GetKeyUp(KeyCode.DownArrow))
        {
            OnPlaySel();
        }
    }
}
#endif