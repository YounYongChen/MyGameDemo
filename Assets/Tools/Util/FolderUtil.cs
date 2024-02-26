using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class FolderUtil
{
    /***********************  Single File **********************/
#if UNITY_EDITOR
    public static GameObject LoadFBX(string name, string ext)
    {
        string modelPath = FolderUtil.GetFilePathRelProject(name, ext);
        if (modelPath == "")
        {
            Debug.LogError("找不到（.FBX文件）: " + name + " ！");
            return null;
        }

        return AssetDatabase.LoadAssetAtPath(modelPath, typeof(GameObject)) as GameObject;
    }

    public static T LoadAsset<T>(string name, string ext) where T : class
    {
        string filePath = FolderUtil.GetFilePathRelProject(name, ext);
        if (filePath == "")
        {
            Debug.LogError("找不到文件: " + name + ext + " ！");
            return null;
        }

        return AssetDatabase.LoadAssetAtPath(filePath, typeof(T)) as T;
    }
#endif

    public static string GetPrefabPathRelProject(string fileName)
    {
        return GetFilePathRelProject(fileName, ".prefab");
    }

    public static string GetFBXPathRelProject(string fileName)
    {
        return GetFilePathRelProject(fileName, ".FBX");
    }

    public static string GetFilePathRelProject(string fileName, string ext)
    {
        fileName += ext;

        string ret = GetFileFullPathRecursive(Application.dataPath, fileName);

        ret = ret.Replace("\\", "/");

        int pos = ret.IndexOf("Assets/");
        if (pos == -1)
            return "";

        ret = ret.Substring(pos);
        Debug.Log(ret);

        return ret;
    }

    private static string GetFileFullPathRecursive(string path, string name)
    {
        string[] fileNames = Directory.GetFiles(path);
        foreach (string file in fileNames)
        {
            if (file.IndexOf(name) != -1)
            {
                return file;
            }
        }

        string[] directories = Directory.GetDirectories(path);
        foreach (string dir in directories)
        {
            string temp = GetFileFullPathRecursive(dir, name);
            if (temp != "")
            {
                return temp;
            }
        }

        return "";
    }

    /*********************** File List **********************/
    public static List<string> GetAllAssetBundlesFullPath()
    {
        string fileName = ".unity3d";

        List<string> pathList = new List<string>();

        GetFullPathListRecursive(Application.dataPath + "/../AssetBundles/", fileName, ref pathList);

        return pathList;
    }

    public static List<string> GetFBXPathListRelProject(string fileName)
    {
        return GetFilePathListRelProject(fileName, ".FBX");
    }

    public static List<string> GetFilePathListRelProject(string fileName, string ext)
    {
        fileName += ext;

        List<string> pathList = new List<string>();

        GetFullPathListRecursive(Application.dataPath, fileName, ref pathList);

        for (int i = 0; i < pathList.Count; i++)
        {
            pathList[i] = pathList[i].Replace("\\", "/");


            int pos = pathList[i].IndexOf("Assets/");
            if (pos == -1)
                continue;

            pathList[i] = pathList[i].Substring(pos);

            Debug.Log(pathList[i]);
        }

        return pathList;

    }

    public static List<string> GetFilePathListRelProject(string path, string fileName, string ext)
    {
        fileName += ext;

        List<string> pathList = new List<string>();

        GetFullPathListRecursive(Application.dataPath + path, fileName, ref pathList);

        for (int i = 0; i < pathList.Count; i++)
        {
            //pathList[i] = pathList[i].Replace("\\", "/");


            int pos = pathList[i].IndexOf("Assets/");
            if (pos == -1)
                continue;

            pathList[i] = pathList[i].Substring(pos);

            Debug.Log(pathList[i]);
        }

        return pathList;

    }

    public static void GetFullPathListRecursive(string path, string name, ref List<string> pathList)
    {
        string[] fileNames = Directory.GetFiles(path);
        foreach (string file in fileNames)
        {
            if (file.IndexOf(name) != -1)
            {
                string t = file.Replace("\\", "/");

                pathList.Add(t);
            }
        }

        string[] directories = Directory.GetDirectories(path);
        foreach (string dir in directories)
        {
            GetFullPathListRecursive(dir, name, ref pathList);
        }
    }


}
