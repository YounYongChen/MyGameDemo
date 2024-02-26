#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class FolderUtil_Editor
{
    // 功能：如果某个folder 不存在，则创建。
    // parentPath： 相对于project路径
    // eg. AssetDatabase.CreateFolder("Assets", "Test");
    private static void CreateFolder(string parentPath, string folderName)
    {
        string ret;

        ret = AssetDatabase.AssetPathToGUID(parentPath + "/" + folderName);
        ret = AssetDatabase.GUIDToAssetPath(ret);
        if (ret == "")
        {
            ret = AssetDatabase.CreateFolder(parentPath, folderName);
            Debug.Log("Folder asset created:" + parentPath + "/" + folderName);
        }
    }

    public static void CreateFolder(string folderPath)
    {
        if (folderPath == null)
            return;

        string[] strArray = folderPath.Split('/');

        string parent = "";
        for (int i = 0; i < strArray.Length - 1; i++)
        {
            parent += strArray[i] + "/";
            CreateFolder(parent.Substring(0, parent.Length - 1), strArray[i + 1]);
        }


    }

    public static T[] LoadAtPathRecursive<T>(string path)
    {
        ArrayList al = new ArrayList();

        List<string> pathList = new List<string>();
        FolderUtil.GetFullPathListRecursive(Application.dataPath + "/" + path, ".prefab", ref pathList);

        foreach (string fileName in pathList)
        {
            int assetPathIndex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathIndex);

            UnityEngine.Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

            if (t != null)
                al.Add(t);
        }
        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (T)al[i];

        return result;
    }
}
#endif