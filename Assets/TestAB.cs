using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestAB : MonoBehaviour
{
    public Button btn;
    GameObject imgGO;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(LoadTextures);
        Debug.Log(this.GetMD5($"{Application.dataPath}/AB/PC/PC"));
    }
    void LoadTextures()
    {
        GameObject gameObject1 = Instantiate(imgGO);
        gameObject1.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public string GetMD5(string filePath)
    {
        using (FileStream file = new FileStream(filePath,FileMode.Open))
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(file);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
