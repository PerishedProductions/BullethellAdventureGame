using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using LitJson;

namespace CoreGame.Utilities
{
    public class ReadJson
    {

        private string jsonString;
        private JsonData itemData;

        public JsonData ReadData(string path)
        {
            jsonString = File.ReadAllText(path);
            itemData = JsonMapper.ToObject(jsonString);

            return itemData;
        }

    }
}
