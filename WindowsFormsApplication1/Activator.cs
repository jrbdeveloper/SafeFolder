using System;
using System.IO;
using System.Reflection;

namespace SafeFolder
{
    public class Activator
    {
        public static dynamic CreateInstance(string assemblyName, string typeName, string path = "") //"DMUtil.dll", "DMS.SDK.IntegrationManager"
        {

            try
            {
                Type mgrType = GetType(assemblyName, typeName, path);
                if (mgrType != null)
                {
                    dynamic mgr = System.Activator.CreateInstance(mgrType);
                    return mgr;
                }

            }
            catch (Exception ex)
            {
                //ConfigurationManager.LogError("", ex);
            }

            return null;
        }

        public static Type GetType(string assemblyName, string typeName, string path = "")
        {
            string currentDirectory = "";
            try
            {
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    currentDirectory = path;
                }
                else
                {
                    currentDirectory = System.IO.Directory.GetCurrentDirectory(); //
                }

                if (!string.IsNullOrEmpty(currentDirectory))
                {
                    System.IO.Directory.SetCurrentDirectory(currentDirectory);
                    string filename = System.IO.Path.Combine(currentDirectory, assemblyName);
                    if (File.Exists(filename))
                    {
                        System.Reflection.Assembly dmUtilAssembly = System.Reflection.Assembly.LoadFrom(filename);
                        Type mgrType = dmUtilAssembly.GetType(typeName);
                        return mgrType;
                    }
                }
            }
            catch (Exception ex)
            {
                //ConfigurationManager.LogError("", ex);
            }
            return null;
        }

        public static bool FileExists(string filename, string path = "")
        {
            try
            {
                string currentDirectory = "";
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    currentDirectory = path;
                }
                else
                {
                    currentDirectory = System.IO.Directory.GetCurrentDirectory(); //
                }
                System.IO.Directory.SetCurrentDirectory(currentDirectory);
                string filePath = System.IO.Path.Combine(currentDirectory, filename);
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                //ConfigurationManager.LogError("", ex);
            }
            return false;
        }

        public static void SetEnumValue(object entity, string entityTypeName, string enumTypePropertyName, int enumValue, string enumTypeName, string assemblyName, string path = "")
        {
            Type enumType = Activator.GetType(assemblyName, enumTypeName);  //This gets the System Type of the Enum
            Type entityType = Activator.GetType(assemblyName, entityTypeName); //This gets the System Type of the Entity that will be set
            PropertyInfo entityPropertyType = entityType.GetProperty(enumTypePropertyName);  //This gets the Property Info for the property on the entity that will be set
            object enumValueAsObject = Enum.ToObject(enumType, enumValue); //This sets the enumValue as an object
            entityPropertyType.SetValue(entity, enumValueAsObject, null); //This actually sets the property
        }
    }
}
