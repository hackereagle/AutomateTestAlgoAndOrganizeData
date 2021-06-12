using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OrganizeData
{
    struct StepSpeedInfo
    {
        public string StepName;
        public double Time; // ms
    }

    class FileData
    {
        public FileData(string file)
        {
            mStepsSpeedInfo = new List<StepSpeedInfo>();

            ExtractInformation(file);
        }

        private void ExtractInformation(string file)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                if (IsRecordSpeedInfo(line))
                {
                    string[] texts = line.Split(' ');
                    StepSpeedInfo temp;
                    temp.StepName = texts[0];
                    temp.Time = Convert.ToDouble(texts[2]);
                    mStepsSpeedInfo.Add(temp);
                }
            }
        }

        private bool IsRecordSpeedInfo(string line)
        {
            bool isRecordSpeedInfo = false;
            int pos = line.IndexOf("spend");
            if (pos > -1)
                isRecordSpeedInfo = true;

            return isRecordSpeedInfo;
        }

        private List<StepSpeedInfo> mStepsSpeedInfo;
        public List<StepSpeedInfo> StepsSpeed { get { return mStepsSpeedInfo; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string folder = args[0];
            string path = AppDomain.CurrentDomain.BaseDirectory + folder;
            string[] files = Directory.GetFiles(path);
            Console.WriteLine($"In {folder}, has {files.Length} files.");

            List<FileData> mData = new List<FileData>();
            foreach (var file in files)
            {
                mData.Add(new FileData(file));
            }

            StreamWriter streamWriter = new StreamWriter("Data.csv");
            int count = mData[0].StepsSpeed.Count;
            for(int i = 0; i < count; i++)
            {
                string oneLine;
                double totalTime = 0;

                oneLine = mData[0].StepsSpeed[i].StepName;
                foreach (var data in mData)
                {
                    double time = data.StepsSpeed[i].Time;
                    oneLine = oneLine + $",{time}";
                    totalTime = totalTime + time;
                }
                oneLine = oneLine + $",{totalTime / Convert.ToDouble(mData.Count)}";

                streamWriter.WriteLine(oneLine);
            }
            streamWriter.Close();

            Console.WriteLine("Complete orgnized data.");
            Console.ReadLine();
        }
    }
}
