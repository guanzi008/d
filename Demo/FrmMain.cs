using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DPAnalyzer;
using System.Runtime.InteropServices;



namespace DigitalPulseAnalyzer_Demo

{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public int[] Data;
        private int[] SpecData;
        private string BoardSN;
        private double UsedTime = 0.0;
        private int QuickCount;
        private double OTRTime;
        private int SlowCount;
        private int FPGAVersion;
        private double FPGABaseLine;
        private double DeadTime;
        private int iDetectorVoltage;
        private int iDetectorTemp;
        private double Params_FineGain;
        private int Params_PeakingTime;
        private int Params_FlattopTime;
        private int Params_ResetTime;
        private int Params_CoarseGian;
        private int Params_FastThreshold;
        private int Param_SlowThresholdLow;
        private int Param_SlowThresholdHigh;
        private int Param_ChannelStandard;
        private int Params_BaseLine;
        private int Params_PileUp;
        private int Param_DetectorVoltage;
        private int Param_DetectorTemp;
        private int Params_Time;
        public bool StopFlag;
        public bool ClearFlag;
        private string strFailSet = "连接失败";
        private string strFailCom = "";
        private int _iXMaxChannel;
        Digital_Pulse_Analyzer DPAnalyzer = new Digital_Pulse_Analyzer();
        SerialPort port = new SerialPort();
        private XmlDocument xmlDoc;
        public Thread TestThread;
        private object lockObj = new object();

        public IntPtr OwnerHandle;
        public const int WM_ReceiveData = 95;




        private bool _OnWork = false;
        public bool OnWork
        {
            get { return _OnWork; }
            set
            {
                if (value != _OnWork)
                {
                    _OnWork = value;
                    UpdateUI();
                }
            }
        }

        private DPAnalyzer.PortType _portType;
        public DPAnalyzer.PortType PortType
        {
            get { return _portType; }
            set
            {
                if (value != _portType)
                {
                    _portType = value;
                   
                }
            }
        }

        private bool _Connected = false;//判断连接
        public bool Connected
        {
            get { return _Connected; }
            set
            {
                if (value != _Connected)
                {
                    _Connected = value;
                    UpdateStatus();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Loads(AppDomain.CurrentDomain.BaseDirectory + "SerialPort.xml");
            this.OwnerHandle = base.Handle;
            LoadConfig();
            if (PortType == PortType.RS232)
            {
                //foreach (string portName in SerialPort.GetPortNames())
                //{

                //}
                try
                {
                    DPAnalyzer.GetLoad(port.PortName, port.BaudRate, port.Parity, port.StopBits, port.DataBits);
                }
                catch (Exception err)
                {
                    MessageBox.Show(strFailCom);
                }

            }
            
        }
        public void Loads(string filename)//程序加载串口参数
        {
            if (!System.IO.File.Exists(filename)) return;
            if (!File.Exists(filename)) return;
            XmlTextReader reader = new XmlTextReader(filename);
            reader.MoveToContent();
            reader.ReadStartElement();
            do
            {
                reader.Read();
                if (reader.NodeType != XmlNodeType.Element)
                    continue;
                switch (reader.Name)
                {
                    case "PortName":
                        port.PortName = reader.ReadString();
                        break;
                    case "BaudRate":
                        port.BaudRate = Convert.ToInt32(reader.ReadString());
                        break;
                    case "Parity":
                        // Enum.TryParse<Parity>(reader.Value,  port.Parity);
                        port.Parity = (Parity)Enum.Parse(typeof(Parity), reader.ReadString());
                        break;
                    case "StopBits":
                        port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), reader.ReadString());
                        break;
                    case "DataBits":
                        port.DataBits = Convert.ToInt32(reader.ReadString());
                        break;
                }

            } while (!reader.EOF);
            reader.Close();
        }
        private int Params_CoarseGian_Value(string str)
        {
            int value = 2;
            switch (str)
            {
                case "6.2X":
                    value = 0;
                    break;

                case "12.4X":
                    value = 1;
                    break;

                case "20X":
                    value = 2;
                    break;

                case "40X":
                    value = 3;
                    break;
            }
            return value;
        }
        public static Dictionary<double, int> PeakingTimeDict = new Dictionary<double, int>() {
            { 0.1,0 },{ 0.2,1 },{0.3,2 },{ 0.4,3 },{ 0.6,4 },{ 0.8,5 },
            { 1.0,6 },{ 1.2,7 },{ 1.6,8 },{ 2.0,9 },{ 2.4,10},{ 2.8,11 },{ 3.2,12 },
          { 4,13},{ 4.8,14 },{ 5.6,15 },{ 6.4,16 },{ 7.2,17 },{ 8.0,18 },
            { 9.6,19 },{ 12.8,20 },{ 19.2,21 },{ 25.6,22},{ 32,23}
        };
        public static Dictionary<double, int> FlattopTimeDict = new Dictionary<double, int>() {
            { 0.05,0 },{ 0.1,1 },{ 0.15,2 },{ 0.2,3 },{ 0.25,4 },{ 0.3,5 },{ 0.35,6 },{ 0.4,7 },{ 0.45,8 },{ 0.5,9 },{ 0.55,10 },{ 0.6,11 },{ 0.65,12},{ 0.7,13 },{ 0.75,14 }
        };
        public static Dictionary<string, double> ResetTimeDict = new Dictionary<string, double>()
        {
            { "25μs",2000},{"50μs", 4000},{ "100μs",8000},{ "200μs",16000},
            { "400μs",32000},{ "800μs",64000}
        };



        public static Dictionary<string, int> CoarseGainDict = new Dictionary<string, int>() {
            {"6.2X",0},{"12.4X",1 },{"20X", 2},{"40X", 3}
        };

        private int Params_Coarse_Value(string str)
        {
            int value = 2;
            switch (str)
            {
                case "6.2X":
                    value = 0;
                    break;

                case "12.4X":
                    value = 1;
                    break;

                case "20X":
                    value = 2;
                    break;

                case "40X":
                    value = 3;
                    break;
            }
            return value;
        }

        public static Dictionary<string, int> BaseLineDict = new Dictionary<string, int>() {
            {"VerySlow",8192},{"Slow",4096 },{"Medium", 2048},{"Fast", 1024},{"VeryFast",512}
        };

        public static Dictionary<string, int> PileUpDict = new Dictionary<string, int>() {
            {"ON",0},{"OFF",1 }
        };
        public static Dictionary<string, int> ChannelStandardDict = new Dictionary<string, int>() {
            {"1024",0},{"2048",1 },{"4096",2 }
        };
        private int Params_ResetTime_Value(string str)
        {
            int value = 2000;
            switch (str)
            {
                case "25μs":
                    value = Value_Buffer(25);
                    break;

                case "50μs":
                    value = Value_Buffer(50);
                    break;

                case "100μs":
                    value = Value_Buffer(100);
                    break;

                case "200μs":
                    value = Value_Buffer(200);
                    break;

                case "400μs":
                    value = Value_Buffer(400);
                    break;

                case "800μs":
                    value = Value_Buffer(800);
                    break;

                case "1.6ms":
                    value = Value_Buffer(1600000);
                    break;

                case "3.2ms":
                    value = Value_Buffer(3200000);
                    break;
            }

            return value;
        }
        private int Value_Buffer(int value)
        {
            return value * 80;
        }
        private void LoadConfig()
        {
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");
            XmlNode node = this.xmlDoc.SelectSingleNode("Params/PeakingTime");
            this.Params_PeakingTime = ((node == null) ? 6 :PeakingTimeDict[double.Parse(node.InnerText)]);

            node = this.xmlDoc.SelectSingleNode("Params/FlattopTime");
            this.Params_FlattopTime = ((node == null) ? 3 : FlattopTimeDict[double.Parse(node.InnerText)]);

            node = this.xmlDoc.SelectSingleNode("Params/FineGain");
            this.Params_FineGain = ((node == null) ? 1 : double.Parse(node.InnerText));

            node = this.xmlDoc.SelectSingleNode("Params/Coarse");
            this.Params_CoarseGian = ((node == null) ? Params_Coarse_Value("20X") : Params_Coarse_Value(node.InnerText));

            node = this.xmlDoc.SelectSingleNode("Params/FastThreshold");
            this.Params_FastThreshold = ((node == null) ? 400 : int.Parse(node.InnerText));

            node = this.xmlDoc.SelectSingleNode("Params/ResetTime");
            this.Params_ResetTime = ((node == null) ? Params_ResetTime_Value("25μs") : Params_ResetTime_Value(node.InnerText));

            node = this.xmlDoc.SelectSingleNode("Params/Time");
            this.Params_Time = ((node == null) ? 100 : int.Parse(node.InnerText));

           
            node = this.xmlDoc.SelectSingleNode("Params/BaseLine");
            this.Params_BaseLine = ((node == null) ? 4096 : BaseLineDict[(node.InnerText)]);
            node = xmlDoc.SelectSingleNode("Params/PileUp");
            this.Params_PileUp = ((node == null) ? 1 : PileUpDict[(node.InnerText)]);


            node = xmlDoc.SelectSingleNode("Params/ChannelStandard");
            this._iXMaxChannel = ((node == null) ? 4096 : int.Parse(node.InnerText));



            node = xmlDoc.SelectSingleNode("Params/DetectorTemp");
            this.Param_DetectorTemp = (node == null) ? 300 : int.Parse(node.InnerText);

            node = xmlDoc.SelectSingleNode("Params/DetectorVoltage");
            this.Param_DetectorVoltage = (node == null) ? 300 : int.Parse(node.InnerText);

            node = xmlDoc.SelectSingleNode("Params/ChannelStandard");
            this.Param_ChannelStandard = (node == null) ? 300 : ChannelStandardDict[(node.InnerText)];

            node = xmlDoc.SelectSingleNode("Params/SlowThresholdLow");
           
          this.Param_SlowThresholdLow = (node == null) ? 1 : int.Parse(node.InnerText);
            node = xmlDoc.SelectSingleNode("Params/SlowThresholdHigh");
            this.Param_SlowThresholdHigh = (node == null) ? 1 : int.Parse(node.InnerText);
            node = xmlDoc.SelectSingleNode("Params/PortType");
            try
            {
                PortType = (DPAnalyzer.PortType)Enum.Parse(typeof(DPAnalyzer.PortType), node.InnerText);
            }
            catch
            { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!DPAnalyzer.Connect(_portType))
            {
                Connected = false;
                MessageBox.Show(this.strFailSet);
                timer1.Enabled = false;
                timer1.Stop();
            }
            else
            {
                Connected = true;
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval = 2000;
            }
        }
        private void UpdateStatus()
        {
            if (Connected)
            {
                

                this.lblConnect.Text = "已连接";
                this.lblConnect.BackColor = System.Drawing.Color.Lime;
            }
            else
            {
                OnWork = false;
                this.StopFlag = true;
                    this.lblConnect.Text = "未连接";               
                this.lblConnect.BackColor = System.Drawing.Color.Transparent;
                MessageBox.Show(this.strFailSet);
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Connected = DPAnalyzer.ConnectStatus(PortType);//判断不同接口连接状态
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rs232Device.Open();
            if (!DPAnalyzer.SetParam(PortType, this.Params_FineGain, this.Params_CoarseGian, this.Param_ChannelStandard, this.Params_PeakingTime, this.Params_FlattopTime, this.Params_ResetTime, this.Params_FastThreshold, this.Params_BaseLine, this.Param_SlowThresholdLow, this.Param_SlowThresholdHigh, this.Param_DetectorTemp, this.Param_DetectorVoltage))
            {
                MessageBox.Show(this.strFailSet);
                this.StopFlag = true;
            }
        }

         public void Measure()
        {
            lock (this.lockObj)
            {
                this.StopFlag = false;
                this.TestThread = new Thread(new ParameterizedThreadStart(this.DoTest));               
                this.TestThread.Priority = ThreadPriority.Highest;
                this.TestThread.Start();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (Connected == true)
            {

                this.Measure(); 
                this.Data = new int[4096];
                this.OnWork = true;
            }
            else
            {
                MessageBox.Show(this.strFailSet);
            }


           
        }

            public void DoTest(object obj)
            {

                if (!DPAnalyzer.StartData(PortType, Params_Time))
                {
                    MessageBox.Show(this.strFailSet);
                    this.StopFlag = true;
                    this.ClearFlag = false;
                }
                while (this.UsedTime < (double)this.Params_Time && !this.StopFlag)
                {
                   
                    if (this.ClearFlag)
                    {
                        DPAnalyzer.ClearData(PortType);
                        Thread.Sleep(600);
                        ClearFlag = false;

                    }
                    while (!DPAnalyzer.GetData(PortType, ref this.Data, ref UsedTime, ref QuickCount, ref OTRTime, ref SlowCount, ref FPGABaseLine, ref DeadTime))
                    {
                        Thread.Sleep(50);
                    }
                   // Thread.Sleep(20);
                    while (!DPAnalyzer.GetHardwareParameter(PortType, ref BoardSN, ref FPGAVersion, ref iDetectorVoltage, ref iDetectorTemp))
                    {
                        Thread.Sleep(50);
                    }//获取硬件状态



                //Array.Copy(this.Data, this.SpecData, this.SpecData.Length);
                //if (this.SpecData.Length == 4096)
                //{
                //    Array.Copy(this.Data, this.SpecData, 4096);
                //}
                //else if (this.SpecData.Length == 2048)
                //{
                //    Array.Copy(this.Data, this.SpecData, 2048);

                //}
                //else if (this.SpecData.Length == 1024)
                //{
                //    Array.Copy(this.Data, this.SpecData, 1024);

                //}

                FrmMain.PostMessage(this.OwnerHandle, 95, true, (int)this.UsedTime);
                Thread.Sleep(100);

                }
             FrmMain.PostMessage(this.OwnerHandle, 96, true, (int)this.UsedTime);

        }


               [DllImport("User32.dll")]
                public static extern bool PostMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 95:
                    this.OnReceiveData(m.LParam.ToInt32());
                    break;
                case 96:
                    this.OnTestEnd(m.LParam.ToInt32());
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void OnReceiveData(int useTime)
        {
            this.lblRunTime.Text = this.UsedTime.ToString("f3");
            this.lblRealCount.Text = this.SlowCount.ToString();
            this.lblRealRate.Text = this.QuickCount.ToString();
            this.lblDeadTime.Text = this.DeadTime.ToString("f3");
            this.lblDetectorVoltage.Text = this.iDetectorVoltage.ToString();
            this.lblDetectorTemp.Text = this.iDetectorTemp.ToString();
        }
        private void OnTestEnd(int useTime)
        {
            this.OnWork = false;
            
        }
        private void UpdateUI()
        {
            this.buttonConnect.Enabled = !OnWork;
            this.buttonSet.Enabled = !OnWork;
            this.button3Run.Enabled = !OnWork;
            this.buttonStop.Enabled = OnWork;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.OnWork)
            {
                this.ClearFlag = true;
            }
            else
            {
                DPAnalyzer.ClearData(PortType);
                Thread.Sleep(50);
                this.UsedTime = 0.0;

            }

        }

        private void lblRealRateLabel_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.StopFlag = true;
            this.OnWork =false;
        }
    }
}
