using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEngine;

public class ScriptFile
{
    private string fileName; // 文本文件名字
    //private string directory= "./TempLuaScripts/";
    
    public ScriptFile(string fileName)
    {
        this.fileName = fileName;
        if (File.Exists(fileName) == false)
        {
            FileStream fs = new FileStream(fileName, 
                FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
        }
    }

    public string getFileName()
    {   
        return fileName;
    }

    public string getFileInfo()
    {
        return File.ReadAllText(fileName);  
    }

    // 向脚本文件添加代码
    public void AddScript(string script)
    {
        File.AppendAllText(fileName,script+"\r\n");
         
    }
    // 清空脚本文件
    public void ClearAllScripts()
    {
        File.Delete(fileName);
       
        FileStream fs = new FileStream(fileName,
            FileMode.OpenOrCreate, FileAccess.ReadWrite);
        fs.Close();
    }

}
