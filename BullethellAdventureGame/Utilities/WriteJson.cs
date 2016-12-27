using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using LitJson;

namespace CoreGame.Utilities
{
    public class WriteJson
    {
        private string jsonString;
        private JsonData itemData;

        public JsonData WriteData(string path, JsonData data)
        {
            itemData = JsonMapper.ToJson(data);
            File.WriteAllText(path, itemData.ToString());

            return itemData;
        }

    }
}
