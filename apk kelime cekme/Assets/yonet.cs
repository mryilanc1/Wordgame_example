using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;


public class yonet : MonoBehaviour
{
    public Text[] error;
    string filepath_String;
    JsonData JsonData_word;
   
    public Text the_word;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            filepath_String = System.IO.File.ReadAllText(Application.dataPath + "/StreamingAssets/json_deneme.json");
            Debug.Log("11");

            JsonData_word = JsonMapper.ToObject(filepath_String);

            error[6].text = JsonData_word.ToString();


            the_word.text = JsonData_word["Kitap1"]["Unite"].ToString();

        }

            if (Application.platform == RuntimePlatform.Android)

        {

            filepath_String = Application.streamingAssetsPath + "/json_deneme.json";

            error[0].text = "after_streaminassetpath";
            WWW reader = new WWW(filepath_String);

            error[1].text = "www before";

            while (!reader.isDone)
            {
                Debug.Log("error WWW");
            }
            error[2].text = "www after";
            string wwwjson = reader.text;
            error[3].text = "wwwjson after";

            error[6].text = wwwjson;
            JsonData_word = JsonMapper.ToObject(wwwjson);

            error[4].text = "jsonmapper after";

            the_word.text = JsonData_word["Kitap1"]["Unite"].ToString();

            error[5].text = "text write after";
        }
    }

    void Update()
    {
        
    }

    public void tik()
    {
        the_word.text = "aaaaa";
    }
}
