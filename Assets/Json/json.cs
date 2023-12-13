using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public enum E_jsontype 
{
jsonUtility,
LitJson 
}
public class Json 
{
    private Json js=new Json();
    private Json Js 
    {
        get { return js; }
    }
    private Json() { }
    public void SaveData(object deta,string filename,E_jsontype type= E_jsontype.LitJson)
    {
        string str = Application.persistentDataPath + "/" + filename + ".json";
        string jsonstr = "";
        switch (type) 
        {
        case E_jsontype.jsonUtility:
                jsonstr=JsonUtility.ToJson(str);
                break;
        case E_jsontype.LitJson:
                jsonstr=JsonMapper.ToJson(str);
                break;
        }
        File.WriteAllText(str, jsonstr);
    }
    public T LoadData<T>(string filename, E_jsontype type = E_jsontype.LitJson)  where T:new ()
    {
        string str = Application.streamingAssetsPath+ "/" + filename + ".json";
        if (!File.Exists(str)) 
        {  str = Application.persistentDataPath + "/" + filename + ".json"; }
        if (!File.Exists(str))
        { return new T(); }
        string jsonstr=File.ReadAllText(str);
        T t = default(T);
        switch (type) 
        {    
                case E_jsontype.jsonUtility:
                t = JsonUtility.FromJson<T>(str);    
                break;
                 case E_jsontype.LitJson:
                t = JsonMapper.ToObject<T>(str);
                break;
        }
    return t;
        
        
    }
}
