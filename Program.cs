using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DrawingNoFind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //获取路径
            Console.WriteLine("请在桌面创建\"DrawingNo.txt\",并将要对比的内容输入到此文本文件中。");
            bool isPathTrue = false;
            string path = "";
            while (!isPathTrue)
            {
                Console.WriteLine("输入文件路径");
                path = Console.ReadLine();
                isPathTrue = Directory.Exists(path);
                if (!isPathTrue)
                {
                    Console.WriteLine("路径有误，请重新输入");
                }
            }

            //获取全部文件及文件夹名称
            string[] filePathNames = Directory.GetFileSystemEntries(path);
            string[] fileNames = new string[filePathNames.Length];
            for (int i = 0; i < filePathNames.Length; i++)
            {
                fileNames[i] = filePathNames[i].Substring(filePathNames[i].LastIndexOf("\\") + 1);
            }

            //读取文件名文本
            string drawingNoTxT = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DrawingNo.txt";
            while (!File.Exists(drawingNoTxT))
            {
                Console.WriteLine("\"DrawingNo.txt\"不在桌面，请创建后按任意键继续");
                Console.ReadLine();
            }
            StreamReader txtReader = new StreamReader(drawingNoTxT);
            List<TxTData> drawingTxTData = new List<TxTData>();
            string line;
            int index = 0;
            while ((line = txtReader.ReadLine()) != null)
            {
                TxTData txTData=new TxTData(line,index);
                drawingTxTData.Add(txTData);
                index++;
            }
            txtReader.Close();

            //
            //对比
            //
            List<TxTData> drawingNullList = new List<TxTData>();
            Dictionary<TxTData, List<string>> drawingAndPath = new Dictionary<TxTData, List<string>>();
            int choose = 0;
            while (choose != 1 && choose != 2)
            {
                Console.WriteLine("请选择对比方式：1、文本与文件对比；2、文件与文本对比");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        //文本与文件对比
                        TXTContrastFile(drawingAndPath, drawingNullList, fileNames, drawingTxTData, filePathNames);
                        break;
                    case 2:
                        //文件与文本对比
                        FileContrastTXT(drawingAndPath, drawingNullList, fileNames, drawingTxTData, filePathNames);
                        break;
                    default:
                        Console.WriteLine("输入有误");
                        break;
                }
            }
            //输出结果
            ResultToTXT(drawingAndPath, drawingNullList);
            Console.WriteLine("已完成，请查看"+ Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DrawingResult.txt");
            Console.WriteLine("按回车键退出");
            Console.ReadLine();

        }
        /// <summary>
        /// 去除文件后缀,"."后去除（包含"."）
        /// </summary>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        private static string RemoveSuffix(string name)
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
        /// <param name="drawingStrings">文本集合</param>
        /// <param name="filePathNames">带有完整路径的文件名数组</param>
        private static void TXTContrastFile(Dictionary<TxTData, List<string>> drawingAndPath, List<TxTData> drawingNullList, string[] fileNames,
            List<TxTData> drawingStrings, string[] filePathNames)
        {
            foreach (TxTData drawingString in drawingStrings)
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
        /// <param name="drawingStrings">文本集合</param>
        /// <param name="filePathNames">带有完整路径的文件名数组</param>
        private static void FileContrastTXT(Dictionary<TxTData, List<string>> pathAndDrawing, List<TxTData> drawingNullList, string[] fileNames,
            List<TxTData> drawingStrings, string[] filePathNames)
        {
            for (int i = 0; i < fileNames.Length; i++)
            {
                var temp = new TxTData(fileNames[i], i);
                pathAndDrawing.Add(temp, new List<string>());
                foreach (TxTData drawingString in drawingStrings)
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
        private static void ResultToTXT(Dictionary<TxTData, List<string>> drawingAndPath, List<TxTData> drawingNullList)
        {
            string drawingResultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DrawingResult.txt";
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
                writer.WriteLine(item + "相同文件数量:" + drawingAndPath[item].Count);
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
        public TxTData(string name,int index) 
        {
            Name = name;
            Index = index;
        }
    }
}
