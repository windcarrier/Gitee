# Usefull Code

## FID用到的

### 调用Wamit软件进行计算

```c#
//调用WAMIT进行分析
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            //p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            bool dsfsw = p.StartInfo.CreateNoWindow;

            p.Start();//启动程序

            //向cmd窗口发送输入信息
            string CmdStr = @"C:";
            p.StandardInput.WriteLine(CmdStr);
            p.StandardInput.AutoFlush = true;


            CmdStr = @"cd C:\WAMITv6\FPSOF";
            p.StandardInput.WriteLine(CmdStr);
            p.StandardInput.AutoFlush = true;

            CmdStr = @"copy fpso.wam fnames.wam";
            p.StandardInput.WriteLine(CmdStr);
            p.StandardInput.AutoFlush = true;


            CmdStr = @"C:\WAMITv6\wamit.exe";
            p.StandardInput.WriteLine(CmdStr);
            p.StandardInput.AutoFlush = true;

            //定义一个进程
            Process WamitProcess = null;
            while (true)
            {
                //获得所有的进程
                Process[] ps = Process.GetProcesses();
                System.Threading.Thread.Sleep(1000);
                //遍历找到进程名字为wamit的进程然后赋值给之前的
                foreach (Process p1 in ps)
                {
                    System.Threading.Thread.Sleep(10);
                    if (p1.ProcessName == "wamit")
                    {
                        WamitProcess = p1;
                        break;
                    }
                }

                if (WamitProcess != null)
                {
                    break;
                }
            }
            //wamit运行结束
            while (true)
            {
                System.Threading.Thread.Sleep(10);
                string vvww = p.StandardOutput.ReadLine();
                Console.WriteLine(vvww);
                if (WamitProcess.HasExited)
                {
                    break;
                }
            }
            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;

            p.WaitForExit();                                  //等待程序执行完退出进程
            p.Close();
            System.Threading.Thread.Sleep(500);

```

### 写输入文件

```c#
 string ResultPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assem.Location), @"MooringAnalysisResult");
            //if (!System.IO.Directory.Exists(ResultPath))
            //{
            //    System.IO.Directory.CreateDirectory(ResultPath);
            //}
            if (System.IO.Directory.Exists(ResultPath))
            {
                System.IO.Directory.Delete(ResultPath, true);
            }
            System.IO.Directory.CreateDirectory(ResultPath);
            // 给之前定义的目录赋值
            m_Workdir = ResultPath;
            ///输出用于计算的文本文件
            ///
            // string bbb = System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.dat");
            TxtWriteTemplateObj.MakeResultTxtFile("MooringRunData.txt", TxtSectionObj, System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.dat"), TemplateResouceInAssemblyRelInfObj);
            //TxtWriteTemplateObj.MakeResultTxtFile("MooringRunData.txt", TxtSectionObj, @"E:\MooringAnalysisFile.dat", TemplateResouceInAssemblyRelInfObj); //在外面测试时所选择的路径
            //TxtWriteTemplateObj.MakeResultTxtFile(@"D:\海工分析中性化\RiserExampleRunData - 删除刚度部分.txt", TxtSectionObj, @"E:\RiserExampleResult.dat");
```

### 表格数据绑定

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace FIDContralBase
{
    /// <summary>表格数据绑定</summary>
    public class TableDataBinding
    {
        //各列对应的信息,与gridControl1中的列数保持一致
        public List<TableDataBindingColumn> m_ColumnsInf = new List<TableDataBindingColumn>();

        public DevExpress.XtraGrid.GridControl gridControl1 = null;

        //原始数据输入
        private DataTable Datadt = null;

        //关联数据,必须为List<A>方式
        public object m_EidtListObj = null;


        public bool Intrial()
        {
            Datadt = new DataTable("CurrentData");
            Datadt.RowChanged += new DataRowChangeEventHandler(CurrentDataRowChangeEventHandler);
            //关联行单击事件
            if(gridControl1.Views.Count>0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView RelGridView = gridControl1.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                if (RelGridView != null)
                {
                    RelGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(RowClick);
                }
            }


            gridControl1.DataSource = Datadt;

            //根据gridControl1列信息初始化
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = gridControl1.ViewCollection[0] as DevExpress.XtraGrid.Views.Grid.GridView;
            for (int i = 0; i < gridView1.Columns.Count; i++ )
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = gridView1.Columns[i];
                Type ColType = null;
                if (gridColumn1.UnboundType == DevExpress.Data.UnboundColumnType.Integer)
                {
                    ColType = typeof(int);
                }
                else if (gridColumn1.UnboundType == DevExpress.Data.UnboundColumnType.String)
                {
                    ColType = typeof(string);
                }
                else if (gridColumn1.UnboundType == DevExpress.Data.UnboundColumnType.Decimal)
                {
                    ColType = typeof(double);
                }
                else if (gridColumn1.UnboundType == DevExpress.Data.UnboundColumnType.Boolean)
                {
                    ColType = typeof(bool);
                }

                Datadt.Columns.Add(gridColumn1.Name, ColType);
            }
            return true;
        }
        private bool UpdataEidtCell = true;

        //通过参数所在根节点，根据名称路径索引具体的对象相关信息，包括具体对象，对象类型，对象所在的对象等
        private void GetParTypeInf(Object RootObj, TableDataBindingColumn BindingInf,
            out object ParColObj, out Type ParObjType,
            out object ParParentObj,
            out FieldInfo FieldParIn, out PropertyInfo PropertyParIn)
        {
            RTDevSoftFucFrame.RtReflectionHelp.GetParTypeInf(RootObj, BindingInf.m_dataMember, BindingInf.m_MemberParentName,
                                                            out  ParColObj, out  ParObjType,
                                                            out  ParParentObj,
                                                            out  FieldParIn, out  PropertyParIn);
        }


        private bool HaveAddColUnitFlagShow = false;

        public void UpdataView()
        {
            UpdataEidtCell = false;

            try
            {
                Datadt.Clear();

                DevExpress.XtraGrid.Views.Grid.GridView gridView1 = gridControl1.ViewCollection[0] as DevExpress.XtraGrid.Views.Grid.GridView;

                Type ParType = m_EidtListObj.GetType();
                Type[] ListGenTypes = ParType.GetGenericArguments();
                Type GenType = ListGenTypes[0];

                dynamic ListObj = m_EidtListObj;
                for (int j = 0; j < ListObj.Count; j++)
                {
                    Object ItemObj = ListObj[j] as Object;
                    Type ItemObjType = ItemObj.GetType();

                    object[] NewRowData = new object[m_ColumnsInf.Count];
                    for (int k = 0; k < m_ColumnsInf.Count; k++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = gridView1.Columns[k];


                        object ThisColObj = null;
                        Type ThisObjType = null;

                        object ParParentObj = null;
                        FieldInfo FieldParIn = null;
                        PropertyInfo PropertyParIn = null;
                        GetParTypeInf(ItemObj, m_ColumnsInf[k], out ThisColObj, out ThisObjType, out ParParentObj, out  FieldParIn, out  PropertyParIn);

                        //如果直接是值类型
                        if (ThisColObj == null)
                        {
                            continue;
                        }
                        else if (!ThisObjType.IsClass || ThisObjType.FullName == "System.String")
                        {
                            if(ThisColObj is double)
                            {
                                NewRowData[k] = CDimensionValHelp.GetShowDimensionVal(double.Parse(ThisColObj.ToString()), m_ColumnsInf[k].ParType, m_ColumnsInf[k].UnitFlag, m_ColumnsInf[k].IsSteelStructSizeShow);
                            }
                            else
                            {
                                NewRowData[k] = ThisColObj;
                            }

                            //初始化列标题上的单位标签
                            if (!HaveAddColUnitFlagShow)
                            {

                                gridColumn1.Caption +=  "(" + (string.IsNullOrEmpty(m_ColumnsInf[k].ShowLocalDimension) ? CDimensionValHelp.GetPublicDimFlag(m_ColumnsInf[k].ParType) : m_ColumnsInf[k].ShowLocalDimension) + ")";
                            }
                        }
                        else if (ThisColObj is FIDDataBase.FIDDouble)
                        {
                            FIDDataBase.FIDDouble FIDDoubleVal = ThisColObj as FIDDataBase.FIDDouble;
                            double YHBmn = FIDDoubleVal.GetDimensionVal(m_ColumnsInf[k].ShowLocalDimension);
                            NewRowData[k] = YHBmn;

                            //初始化列标题上的单位标签
                            if (!HaveAddColUnitFlagShow)
                            {
                                gridColumn1.Caption += "(" + (string.IsNullOrEmpty(m_ColumnsInf[k].ShowLocalDimension) ? CDimensionValHelp.GetPublicDimFlag(FIDDoubleVal.ParType) : m_ColumnsInf[k].ShowLocalDimension) + ")";
                            }
                        }
                        else if(ThisColObj is FIDDataBase.FIDInt)
                        {
                            FIDDataBase.FIDInt FIDIntVal = ThisColObj as FIDDataBase.FIDInt;
                            int ThiVal = FIDIntVal.InnerValue;
                            NewRowData[k] = ThiVal;

                            //初始化列标题上的单位标签
                            if (!HaveAddColUnitFlagShow)
                            {
                                gridColumn1.Caption += "(" + (string.IsNullOrEmpty(m_ColumnsInf[k].ShowLocalDimension) ? CDimensionValHelp.GetPublicDimFlag(FIDIntVal.ParType) : m_ColumnsInf[k].ShowLocalDimension) + ")";
                            }
                        }
                    }
                    HaveAddColUnitFlagShow = true;



                    DataRow ddw = Datadt.Rows.Add(NewRowData);
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                UpdataEidtCell = true;
            }
        }


        /// <summary>选择某个对象所在的行作为高亮对象</summary>
        /// <param name="DataObj"></param>
        public void SelRowRelDataObj(object DataObj)
        {
            if (gridControl1 == null)
            {
                return;
            }

            if (gridControl1.Views.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView RelGridView = gridControl1.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                if (RelGridView != null)
                {
                    Type ParType = m_EidtListObj.GetType();
                    Type[] ListGenTypes = ParType.GetGenericArguments();
                    Type GenType = ListGenTypes[0];

                    dynamic ListObj = m_EidtListObj;
                    int ObjIndexInList = -1;
                    for (int i = 0; i < ListObj.Count; i++)
                    {
                        if (ListObj[i] == DataObj)
                        {
                            ObjIndexInList = i;
                            break;
                        }
                    }

                    if (ObjIndexInList >= 0)
                    {
                        RelGridView.FocusedRowHandle = ObjIndexInList;
                    }
                }
            }



        }

        private void CurrentDataRowChangeEventHandler(object sender, DataRowChangeEventArgs e)
        {
            if (UpdataEidtCell)
            {
                int RowIndex = e.Row.Table.Rows.IndexOf(e.Row);

                Type ParType = m_EidtListObj.GetType();
                Type[] ListGenTypes = ParType.GetGenericArguments();
                Type GenType = ListGenTypes[0];

                dynamic ListObj = m_EidtListObj;
                Object ItemObj = ListObj[RowIndex] as Object;
                Type ItemObjType = ItemObj.GetType();

                for (int k = 0; k < m_ColumnsInf.Count; k++)
                {
                    if (string.IsNullOrEmpty(e.Row.ItemArray[k].ToString()))
                    {
                        continue;
                    }

                    object ThisColObj = null;
                    Type ThisObjType = null;


                    object ThisColObjParent = null;
                    FieldInfo ThisField22 = null;
                    PropertyInfo ThisProperty22 = null;
                    GetParTypeInf(ItemObj, m_ColumnsInf[k], out ThisColObj, out ThisObjType, out ThisColObjParent, out  ThisField22, out  ThisProperty22);


                    if (!ThisObjType.IsClass || ThisObjType.FullName == "System.String")
                    {
                        if (ThisColObj is double)
                        {
                            double DDD1 = CDimensionValHelp.GetOriDimensionVal(m_ColumnsInf[k].ParType, e.Row.ItemArray[k].ToString(), m_ColumnsInf[k].UnitFlag, m_ColumnsInf[k].IsSteelStructSizeShow);

                            if (ThisField22 != null)
                            {
                                ThisField22.SetValue(ThisColObjParent, DDD1);
                            }
                            else if(ThisProperty22 != null)
                            {
                                ThisProperty22.SetValue(ThisColObjParent, DDD1, null);
                            }
                        }
                        else
                        {
                            if (ThisField22 != null)
                            {
                                ThisField22.SetValue(ThisColObjParent, e.Row.ItemArray[k]);
                            }
                            else if(ThisProperty22 != null)
                            {
                                ThisProperty22.SetValue(ThisColObjParent, e.Row.ItemArray[k], null);
                            }
                        }
                    }
                    else if (ThisColObj is FIDDataBase.FIDDouble)
                    {
                        FIDDataBase.FIDDouble FIDDoubleVal = ThisColObj as FIDDataBase.FIDDouble;
                        FIDDoubleVal.SetDimensionVal(e.Row.ItemArray[k].ToString(), m_ColumnsInf[k].ShowLocalDimension);
                    }
                    else if (ThisColObj is FIDDataBase.FIDInt)
                    {
                        FIDDataBase.FIDInt FIDIntVal = ThisColObj as FIDDataBase.FIDInt;
                        FIDIntVal.InnerValue = int.Parse(e.Row.ItemArray[k].ToString());
                    }
                }

                //在所有视图中更新指定行对应的展示
                FIDTextBoxInputControl.UpdataParentObjectEditBaseControl(gridControl1, ItemObj);
            }
        }
        private void RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (UpdataEidtCell)
            {
                int RowIndex = e.RowHandle;

                Type ParType = m_EidtListObj.GetType();
                Type[] ListGenTypes = ParType.GetGenericArguments();
                Type GenType = ListGenTypes[0];

                dynamic ListObj = m_EidtListObj;
                Object ItemObj = ListObj[RowIndex] as Object;

                FIDTextBoxInputControl.SelectStatuseObjectEditBaseControl(gridControl1, ItemObj);

            }
        }
    }

    /// <summary>一列信息</summary>
    public class TableDataBindingColumn
    {
        public TableDataBindingColumn(FIDDataBase.ParUnitType ParTypeFlag = FIDDataBase.ParUnitType.None, string ParUnit = "", bool IsSteelStructSize = false)
        {
            m_ParType = ParTypeFlag;
            m_UnitFlag = ParUnit;
            m_IsSteelStructSizeShow = IsSteelStructSize;
        }

        //如果是外部变量,用一下参数限定相关信息
        private FIDDataBase.ParUnitType m_ParType = FIDDataBase.ParUnitType.None;
        public FIDDataBase.ParUnitType ParType
        {
            get { return m_ParType; }
        }

        private string m_UnitFlag = "";
        public string UnitFlag
        {
            get { return m_UnitFlag; }
        }

        private bool m_IsSteelStructSizeShow = false;
        public bool IsSteelStructSizeShow
        {
            get { return m_IsSteelStructSizeShow; }
        }

        private string m_ShowLocalDimension = "";
        /// <summary>强制显示的量纲</summary>
        public string ShowLocalDimension
        {
            get { return m_ShowLocalDimension; }
            set { m_ShowLocalDimension = value; }
        }





        //外部变量引用
        public List<string> m_MemberParentName = new List<string>();      //不直接在List包含的下面的
        public string m_dataMember;

    }
}

```