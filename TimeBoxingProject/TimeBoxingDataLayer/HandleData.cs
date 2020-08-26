using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeBoxingDataLayer
{
    public class HandleData
    {

        #region constructor

        public HandleData(string path)
        {
            Path = path;
        }

        #endregion


        #region methods

        public bool GetData<T>(out T obj)
        {
            obj = default(T);
            if (String.IsNullOrEmpty(Path))
                return false;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(Path);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public bool SaveData(object obj)
        {            
            if (String.IsNullOrEmpty(Path))
                return false;
            try
            {
                obj = JsonConvert.SerializeObject(Path);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion


        #region static Propertis

        public static string Path = string.Empty;

        #endregion 
    }
}
