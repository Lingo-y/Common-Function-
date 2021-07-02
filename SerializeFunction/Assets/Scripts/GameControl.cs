using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public GameObject save;
    public GameObject load;

    private void Awake()
    {

        save = GameObject.Find("ButtonManager/Canvas/Save");
        load = GameObject.Find("ButtonManager/Canvas/Load");
        #region 二进制
        //save.GetComponent<Button>().onClick.AddListener(SaveBySerialization);
        //load.GetComponent<Button>().onClick.AddListener(LoadByDeserialization);
        #endregion

        #region Json
        //save.GetComponent<Button>().onClick.AddListener(SaveByJson);
        //load.GetComponent<Button>().onClick.AddListener(LoadByJson);
        #endregion

        #region XML
        save.GetComponent<Button>().onClick.AddListener(SaveByXML);
        load.GetComponent<Button>().onClick.AddListener(LoadByXML);
        #endregion


    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.posX = gameObject.transform.position.x;
        save.posY = gameObject.transform.position.y;
        return save;

    }

    #region 二进制方法
    private void SaveBySerialization()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        //步骤：创建文件流——序列化Save对象并写入硬盘——关闭文件流
        //文件在assets目录下
        FileStream fileStream = File.Create(Application.dataPath + "/Data.text");

        bf.Serialize(fileStream, save);
        fileStream.Close();
        Debug.Log("save:   " + gameObject.transform.position);
    }

    private void LoadByDeserialization()
    {
        //首先检查安全性
        if (File.Exists(Application.dataPath + "/Data.text"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + "/Data.text", FileMode.Open);
            Save save = bf.Deserialize(fileStream) as Save;
            fileStream.Close();
            gameObject.transform.position = new Vector2(save.posX, save.posY);
            Debug.Log("load:   " + gameObject.transform.position);
        }
        else
        {
            Debug.Log("NOT FOUND THIS FILE!");
        }

    }
    #endregion


    #region Json方法 
    //Json是String类型
    private void SaveByJson()
    {
        Save save = CreateSaveGameObject();
        string jsonString = JsonUtility.ToJson(save);
        //不同文本有不同的编码格式，StreamWriter会自动处理，不需要关心文本文件的编码是什么
        //FileStream读取的是字节数组，使用非文本文件，所以它适合读取二进制文件
        StreamWriter sw = new StreamWriter(Application.dataPath + "/JsonData.text");
        sw.Write(jsonString);
        sw.Close();
        Debug.Log("-------Save------");


    }

    private void LoadByJson()
    {
        if (File.Exists(Application.dataPath + "/JsonData.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/JsonData.text");
            //从当前位置读到结束，Read方法只会读一个字符
            string jsonString = sr.ReadToEnd();
            sr.Close();
            Save save = JsonUtility.FromJson<Save>(jsonString);
            gameObject.transform.position = new Vector2(save.posX, save.posY);
            Debug.Log("-------Load------");

        }
        else
        {
            Debug.Log("NOT FOUND THIS FILE!");
        }
    }


    #endregion

    #region xml
    private void SaveByXML() {
        Save save = CreateSaveGameObject();
        XmlDocument xmlDocument = new XmlDocument();
        #region CreateXML elements
        //创建根节点
        XmlElement root = xmlDocument.CreateElement("Save"); // <Save>....elements....</Save>
        root.SetAttribute("FileName", "File_01");//可选

        XmlElement posXElement = xmlDocument.CreateElement("posX");
        posXElement.InnerText = save.posX.ToString();
        root.AppendChild(posXElement);

        XmlElement posYElement = xmlDocument.CreateElement("posY");
        posYElement.InnerText = save.posY.ToString();
        root.AppendChild(posYElement);

        #endregion
        xmlDocument.AppendChild(root);
        xmlDocument.Save(Application.dataPath + "/DataXML.text");
        Debug.Log("------Save--------");

    
    }
    private void LoadByXML() {
        if (File.Exists(Application.dataPath + "/DataXML.text"))
        {
            Save save = new Save();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/DataXML.text");
            //通过Tag标签访问元素中具体的数值,返回的是List列表，第一个是posX[0],第二个是posX[1];
            XmlNodeList posX = xmlDocument.GetElementsByTagName("posX");
            float pos_X = float.Parse(posX[0].InnerText);
            save.posX = pos_X;

            XmlNodeList posY = xmlDocument.GetElementsByTagName("posY");
            float pos_Y = float.Parse(posY[0].InnerText);
            save.posY = pos_Y;
            gameObject.transform.position = new Vector2(save.posX, save.posY);
            Debug.Log("------Load-------");
        } 
        else 
        {
            Debug.Log("NOT FOUND THIS FILE!");
        }

    }


    #endregion


}
