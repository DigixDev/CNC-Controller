using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CNC_Controller.Core
{
    class Splitter
    {
        #region private

        private static string[] GetLineParts(string[] lines, string key)
        {
            var line = lines.Single(x => x.Contains(key+":"));

            return GetLineParts(line);
        }

        private static string[] GetLineParts(string line)
        {
            return line.Substring(line.IndexOf(':') + 1)
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region public

        public static void SplitDouble<T>(string[] lines, string key, T[] objs, string propName)
        {
            var parts = GetLineParts(lines, key);
            var index = 0;

            foreach (var part in parts)
            {
                var value = Convert.ToDouble(part);

                if (objs[index] == null)
                    objs[index] = Activator.CreateInstance<T>();

                typeof(T).GetField(propName)
                    .SetValue(objs[index], value);
                index++;
            }
        }

        public static void Split<T>(string[] lines, string key, ref T obj)
        {
            var parts = GetLineParts(lines, key);
            obj = (T) Convert.ChangeType(parts[0], typeof(T));
        }

        public static void Split<T>(string line, ref T obj)
        {
            var parts = GetLineParts(line);
            obj = (T)Convert.ChangeType(parts[0], typeof(T));
        }

        public static void Split<T>(string[] lines, string key, T[] objs, string propName, int index=0)
        {
            var parts = GetLineParts(lines.Single(x=>x.Contains(key+":")));

            foreach (var part in parts)
            {
                if (objs[index] == null)
                    objs[index] = Activator.CreateInstance<T>();

                var field = typeof(T)
                    .GetField(propName);

                var value = Convert.ChangeType(part, field.FieldType);

                field.SetValue(objs[index], value);

                index++;
            }
        }

        public static void Split<T>(string line, T[] objs, string propName, int index = 0)
        {
            var parts = GetLineParts(line);

            foreach (var part in parts)
            {
                if (objs[index] == null)
                    objs[index] = Activator.CreateInstance<T>();

                var field = typeof(T)
                    .GetField(propName);

                var value = Convert.ChangeType(part, field.FieldType);

                field.SetValue(objs[index], value);

                index++;
            }
        }

        public static void SplitDouble(string[] lines, string key, int index, double[] a1, double[] a2, double[] a3, double[] a4,
            double[] a5, double[] a6 = null, double[] a7 = null, double[] a8 = null)
        {
            var parts = GetLineParts(lines, key);

            a1[index] = Convert.ToDouble(parts[0]);
            a2[index] = Convert.ToDouble(parts[1]);
            a3[index] = Convert.ToDouble(parts[2]);
            a4[index] = Convert.ToDouble(parts[3]);
            a5[index] = Convert.ToDouble(parts[4]);
            if (a6 != null)
                a6[index] = Convert.ToDouble(parts[5]);
            if (a7 != null)
                a7[index] = Convert.ToDouble(parts[6]);
            if (a8 != null)
                a8[index] = Convert.ToDouble(parts[7]);
        }

        #endregion
    }
}
