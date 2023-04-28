using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace M3Ueditor.Class
{
    class About
    {
        public static bool isDebugMode { get; set; } =
#if DEBUG
            true;
#else
            false;
#endif

        #region Методы доступа к атрибутам сборки

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyProductAttribute titleAttribute = (AssemblyProductAttribute)attributes[0];
                    if (titleAttribute.Product != "")
                    {
                        return titleAttribute.Product;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                if (isDebugMode)
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                else
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.Major.ToString()
                        + "."
                        + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                }

            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion


    }
}
