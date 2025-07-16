using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DrawingNoFindWindow
{
    internal class Core
    {
        //获取路径

        //获取全部文件及文件夹名称

        //读取文件名文本

        //对比

        //输出结果
        public static List<TxTData> GetDrawingDataList(string[] userInputString)
        {
            List<TxTData> drawingTxTData = new List<TxTData>();
            for (int i = 0; i < userInputString.Length; i++)
            {
                drawingTxTData.Add(new TxTData(userInputString[i], i));
            }
            return drawingTxTData;
        }
        public static void GetFileNameAndFilePath(string path, out string[] filePathNames, out string[] fileNames)
        {
            filePathNames = Directory.GetFileSystemEntries(path);
            fileNames = new string[filePathNames.Length];
            for (int i = 0; i < filePathNames.Length; i++)
            {
                fileNames[i] = filePathNames[i].Substring(filePathNames[i].LastIndexOf("\\") + 1);
            }
        }
        /// <summary>
        /// 去除文件后缀,"."后去除（包含"."）
        /// </summary>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        public static string RemoveSuffix(string name)
        {
            int index = name.LastIndexOf(".");
            if (index == -1)
                return name;
            string newName = name.Substring(0, index);
            return newName;
        }
        /// <summary>
        /// 文本与文件对比
        /// </summary>
        /// <param name="drawingAndPath">单一文本与文件路径集合 字典</param>
        /// <param name="drawingNullList">不存在文件路径文本集合</param>
        /// <param name="fileNames">单独文件名数组</param>
        /// <param name="userInputList">文本集合</param>
        /// <param name="filePathNames">带有完整路径的文件名数组</param>
        public static void TXTContrastFile( Dictionary<TxTData, List<string>> drawingAndPath, List<TxTData> drawingNullList, string[] fileNames,
            List<TxTData> userInputList, string[] filePathNames)
        {
            foreach (TxTData drawingString in userInputList)
            {
                drawingAndPath.Add(drawingString, new List<string>());
                for (int i = 0; i < fileNames.Length; i++)
                {
                    if (drawingString.Name != string.Empty && fileNames[i].Replace(" ", "").IndexOf(drawingString.Name.Replace(" ", "")) >= 0)
                    {
                        drawingAndPath[drawingString].Add(fileNames[i] + ":" + filePathNames[i]);
                    }
                }
                if (drawingAndPath[drawingString].Count <= 0)
                {
                    drawingNullList.Add(drawingString);
                }
            }
        }
        /// <summary>
        /// 文件与文本对比
        /// </summary>
        /// <param name="drawingAndPath">单一文本与文件路径集合 字典</param>
        /// <param name="drawingNullList">不存在文件路径文本集合</param>
        /// <param name="fileNames">单独文件名数组</param>
        /// <param name="userInputList">文本集合</param>
        /// <param name="filePathNames">带有完整路径的文件名数组</param>
        public static void FileContrastTXT(Dictionary<TxTData, List<string>> pathAndDrawing, List<TxTData> drawingNullList, string[] fileNames,
            List<TxTData> userInputList, string[] filePathNames)
        {
            for (int i = 0; i < fileNames.Length; i++)
            {
                var temp = new TxTData(fileNames[i], i);
                pathAndDrawing.Add(temp, new List<string>());
                foreach (TxTData drawingString in userInputList)
                {
                    if (drawingString.Name != string.Empty && fileNames[i].Replace(" ", "").IndexOf(drawingString.Name.Replace(" ", "")) >= 0)
                    {
                        pathAndDrawing[temp].Add(drawingString + ":" + filePathNames[i]);
                    }
                }
                if (pathAndDrawing[temp].Count <= 0)
                {
                    drawingNullList.Add(temp);
                }
            }
        }
        /// <summary>
        /// 输出结果为文本
        /// </summary>
        /// <param name="drawingAndPath">单一文本与文件路径集合</param>
        /// <param name="drawingNullList">不存在文件路径文本集合</param>
        public static void ResultToTXT(Dictionary<TxTData, List<string>> drawingAndPath, List<TxTData> drawingNullList, ResultFormEnum resultFormEnum)
        {
            string drawingResultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ((resultFormEnum == ResultFormEnum.TXTVSFILE) ? "\\DrawingTxtVSFileResult.txt" : "\\DrawingFileVSTxtResult.txt");
            File.Create(drawingResultPath).Close();
            if (!File.Exists(drawingResultPath)) return;
            StreamWriter writer = new StreamWriter(drawingResultPath);
            foreach (var item in drawingAndPath.Keys)
            {
                writer.WriteLine(item.Name);
                foreach (var dr in drawingAndPath[item])
                {
                    writer.WriteLine(dr);
                }
                writer.WriteLine(item.Name + "相同文件数量:" + drawingAndPath[item].Count);
                writer.WriteLine();
                writer.WriteLine();
            }
            writer.WriteLine("无文件文本名:");
            foreach (var item in drawingNullList)
            {
                writer.WriteLine(item.Name);
            }
            writer.WriteLine("无文件文本数量:" + drawingNullList.Count);
            writer.Close();
        }
    }
    internal class TxTData
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public TxTData(string name, int index)
        {
            Name = name;
            Index = index;
        }
    }
    internal enum ResultFormEnum
    {
        TXTVSFILE,
        FILEVSTXT
    }
}
