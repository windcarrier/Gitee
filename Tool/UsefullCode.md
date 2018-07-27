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

### 写软件输入文件的模板

```c#
 override protected bool MakeCalFileDo(CMooringModelParameters ModelParameterObj, CAnalyCalResult OutResult)
        {

            #region ShanshanWang

            TxtWriteTemplate.TemplateResouceInAssemblyRelInf TemplateResouceInAssemblyRelInfObj = new TxtWriteTemplate.TemplateResouceInAssemblyRelInf();

            TemplateResouceInAssemblyRelInfObj.ResouceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            {
                TxtWriteTemplate.TemplateResouceInAssemblyRelInf.OneTemplateFile AA = new TxtWriteTemplate.TemplateResouceInAssemblyRelInf.OneTemplateFile();
                AA.TemplateFileName = "MooringRunData.txt";
                AA.TemplateFullPathInAssembly = "OrcaflexMooringRiserDomainModel.MooringRiserTemplate.MooringRunData.txt";
                TemplateResouceInAssemblyRelInfObj.TemplateFileResouceRelList.Add(AA);
            }



            TxtWriteTemplate TxtWriteTemplateObj = new TxtWriteTemplate();
            TxtSection TxtSectionObj = TxtWriteTemplateObj.InitrialFromTxtTemplate("MooringRunData.txt", TemplateResouceInAssemblyRelInfObj);

            //TxtWriteTemplate TxtWriteTemplateObj = new TxtWriteTemplate();
            //TxtSection TxtSectionObj = TxtWriteTemplateObj.InitrialFromTxtTemplate(@"D:\海工分析中性化\RiserExampleRunData - 删除刚度部分.txt");


            TxtSection RootSectionInstance = TxtSectionObj.AddOneSelfInstance();



            ///计算文件的信息
            // RootSectionInstance.m_ParList.Find(p1 => p1.m_Name == "DescribeInformation").m_ValueStr = "%YAML 1.1\r\n# Type: Model\r\n# Program: OrcaFlex 10.1a\r\n# File: E:\\project\\安装公司orcaflex培训方案\\Examples\\A Production Risers\\A05 Steel Catenary Riser Systems\\A05 Catenary with Spar.yml\r\n# Created: 16:06 on 2017-7-3\r\n# User: ajxu\r\n# Machine: DESKTOP-242";

            ///General
            #region
            {
                TxtSection General = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "General");
                TxtSection GeneralInstance = General.AddOneSelfInstance();
                {
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "UnitsSystem").m_ValueStr = "SI";
                    //GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "BuoysIncludedInStatics").m_ValueStr = "Individually Specified";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "DynamicsSolutionMethod").m_ValueStr = "Implicit Time Domain";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "ImplicitUseVariableTimeStep").m_ValueStr = "No";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "ImplicitConstantTimeStep").m_ValueStr = (0.1).ToString();
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "LogPrecision").m_ValueStr = "Single";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "TargetLogSampleInterval").m_ValueStr = "0.2";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "LogStartTime").m_ValueStr = "~";
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "SimulationStage1").m_ValueStr = ModelParameterObj.General.SimulationStage[0].ToString();
                    GeneralInstance.m_ParList.Find(p1 => p1.m_Name == "SimulationStage2").m_ValueStr = ModelParameterObj.General.SimulationStage[1].ToString();
                }
            }
            #endregion

            //Enviornment
            #region Enviornment
            {
                TxtSection Environment = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "Environment");
                TxtSection EnvironmentInstance = Environment.AddOneSelfInstance();
                {
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaterSurfaceZ").m_ValueStr = (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "KinematicViscosity").m_ValueStr = ModelParameterObj.Environment.KinematicViscosity.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeaTemperature").m_ValueStr = ModelParameterObj.Environment.SeaTemperature.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "ReynoldsNumberCalculation").m_ValueStr = "Flow Direction";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "HorizontalWaterDensityFactor").m_ValueStr = "~";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "VerticalDensityVariation").m_ValueStr = "Constant";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "Density").m_ValueStr = ModelParameterObj.Environment.Density.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedType").m_ValueStr = "Flat";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedOrigin").m_ValueStr = (0).ToString() + ", " + (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaterDepth").m_ValueStr = ModelParameterObj.Environment.WaterDepth.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedSlopeDirection").m_ValueStr = (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedSlope").m_ValueStr = (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedModel").m_ValueStr = "Elastic";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedNormalStiffness").m_ValueStr = (100).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SeabedShearStiffness").m_ValueStr = "~";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "SimulationTimeOrigin").m_ValueStr = (0).ToString();
                    TxtSection WaveTrain = EnvironmentInstance.m_ChildSection.Find(p1 => p1.m_Name == "WaveTrain");
                    for (int i = 0; i < ModelParameterObj.Environment.WaveTrainList.Count; i++)
                    {
                        TxtSection WaveTrainInstance = WaveTrain.AddOneSelfInstance();
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "AAAName").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].Name;
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "WaveType").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].WaveSpectrum.ToString();
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "WaveDirection").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].WaveDirection.ToString();
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "Hs").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].WaveHeight.ToString();
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "Tz").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].WavePeriod.ToString();
                        //WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "WaveOrigin").m_ValueStr = (0).ToString() + ", " + (0).ToString();
                        //WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "WaveTimeOrigin").m_ValueStr = (0).ToString();
                        WaveTrainInstance.m_ParList.Find(p1 => p1.m_Name == "Gamma").m_ValueStr = ModelParameterObj.Environment.WaveTrainList[i].Gamma.ToString();
                    }
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaveKinematicsCutoffDepth").m_ValueStr = "Infinity";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaveCalculationMethod").m_ValueStr = "Instantaneous Position (exact)";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaveCalculationTimeInterval").m_ValueStr = (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WaveCalculationSpatialInterval").m_ValueStr = (0).ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "MultipleCurrentDataCanBeDefined").m_ValueStr = "No";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "CurrentRamp").m_ValueStr = "No";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "HorizontalCurrentFactor").m_ValueStr = "~";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "CurrentApplyVerticalStretching").m_ValueStr = "No";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "CurrentMethod").m_ValueStr = "Interpolated";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "RefCurrentSpeed").m_ValueStr = ModelParameterObj.Environment.RefCurrentSpeed.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "RefCurrentDirection").m_ValueStr = ModelParameterObj.Environment.RefCurrentDirection.ToString();
                    TxtSection CurrentProfile = EnvironmentInstance.m_ChildSection.Find(p1 => p1.m_Name == "CurrentProfile");
                    for (int i = 0; i < ModelParameterObj.Environment.currentProfile.Count; i++)
                    {
                        TxtSection CurrentProfileInstance = CurrentProfile.AddOneSelfInstance();
                        CurrentProfileInstance.m_ParList.Find(p1 => p1.m_Name == "ProfileParameter").m_ValueStr = ModelParameterObj.Environment.currentProfile[i].depth + "," + ModelParameterObj.Environment.currentProfile[i].factor + "," + ModelParameterObj.Environment.currentProfile[i].rotation;
                    }
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeVesselWindLoads").m_ValueStr = "Yes";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeLineWindLoads").m_ValueStr = "Yes";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeBuoyWingWindLoads").m_ValueStr = "Yes";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "VerticalWindVariationFactor").m_ValueStr = "~";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "AirDensity").m_ValueStr = ModelParameterObj.Environment.AirDensity.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WindType").m_ValueStr = "Constant";
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WindSpeed").m_ValueStr = ModelParameterObj.Environment.WindSpeed.ToString();
                    EnvironmentInstance.m_ParList.Find(p1 => p1.m_Name == "WindDirection").m_ValueStr = ModelParameterObj.Environment.WindDirection.ToString();
                }
            }
            #endregion
            #region 调用OrcaFlex将WAMIT的结果转换为可用形式
            // 获得FID的bin目录下的FID(这个获得的就是一个主进程)（准确来说，并不是获得具体某个FID或者其他单个程序的bin，而是泛指你所在的是哪个程序来决定的）
            System.Reflection.Assembly Assem = System.Reflection.Assembly.GetExecutingAssembly();
            //(Assem.Location)得到的是FID.exe,然后前面的GetdirectoryName函数也就是去掉了.exe,也就是获得了目录，然后与之后的那个目录文件夹相连，就变成了一个完成的路径。
            string WAMITResultPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assem.Location), @"HydrodynamicResult");
            System.Threading.Thread.Sleep(1000);
            MakeYmlFileWithOrcaFlex((System.IO.Path.Combine(WAMITResultPath, @"fpso.out")), (System.IO.Path.Combine(WAMITResultPath, @"mooring.yml")));
            System.Threading.Thread.Sleep(1000);
            #endregion
            #region 取水动力结果
            //找到需要取结果的文件
            RTTxtDataParseHelp ParseHelper = new RTTxtDataParseHelp((System.IO.Path.Combine(WAMITResultPath, @"mooring.yml")));
            //取结果的规则
            RTTxtDataParseHelp.Rule RuleDisRAO = new RTTxtDataParseHelp.Rule("DisplacementRAOs:", "LoadRAOs:", RTTxtDataParseHelp.Mode.FuzzyMatch, RTTxtDataParseHelp.Mode.FuzzyMatch);

            RTTxtDataParseHelp.Block DisR = ParseHelper.FindBlock(RuleDisRAO);
            StringBuilder DisRA = new StringBuilder();

            for (int i = 3; i < DisR.Rows.Count - 1; i++)
            {
                DisRA.AppendLine(DisR.Rows[i].Value);
            }
            //为避免最后一行有换行符，最后一行单独加入
            if (DisR.Rows.Count > 0)
            {
                DisRA.Append(DisR.Rows[DisR.Rows.Count - 1].Value);
            }

            string DisRAO = DisRA.ToString();

            //取结果的规则
            RTTxtDataParseHelp.Rule RuleLoadRAO = new RTTxtDataParseHelp.Rule("LoadRAOs:", "WaveDriftQTFMethod:", RTTxtDataParseHelp.Mode.FuzzyMatch, RTTxtDataParseHelp.Mode.FuzzyMatch);

            RTTxtDataParseHelp.Block LoadR = ParseHelper.FindBlock(RuleLoadRAO);
            StringBuilder LoadRA = new StringBuilder();

            for (int i = 3; i < LoadR.Rows.Count - 1; i++)
            {
                LoadRA.AppendLine(LoadR.Rows[i].Value);
            }
            //为避免最后一行有换行符，最后一行单独加入
            if (LoadR.Rows.Count > 0)
            {
                LoadRA.Append(LoadR.Rows[LoadR.Rows.Count - 1].Value);
            }

            string LoadRAO = LoadRA.ToString();

            //取结果的规则
            RTTxtDataParseHelp.Rule RuleWaveDriftRAO = new RTTxtDataParseHelp.Rule("WaveDrift:", "SumFrequencyQTFs:", RTTxtDataParseHelp.Mode.FuzzyMatch, RTTxtDataParseHelp.Mode.FuzzyMatch);

            RTTxtDataParseHelp.Block WaveDriftR = ParseHelper.FindBlock(RuleWaveDriftRAO);
            StringBuilder WaveDriftRA = new StringBuilder();

            for (int i = 2; i < WaveDriftR.Rows.Count - 1; i++)
            {
                WaveDriftRA.AppendLine(WaveDriftR.Rows[i].Value);
            }
            //为避免最后一行有换行符，最后一行单独加入
            if (WaveDriftR.Rows.Count > 0)
            {
                WaveDriftRA.Append(WaveDriftR.Rows[WaveDriftR.Rows.Count - 1].Value);
            }

            string WaveDriftRAO = WaveDriftRA.ToString();

            //取结果的规则
            RTTxtDataParseHelp.Rule RuleHydrosRAO = new RTTxtDataParseHelp.Rule("HydrostaticStiffnessz, HydrostaticStiffnessRx, HydrostaticStiffnessRy:", "AMDCutoffTime:", RTTxtDataParseHelp.Mode.FuzzyMatch, RTTxtDataParseHelp.Mode.FuzzyMatch);

            RTTxtDataParseHelp.Block HydrosR = ParseHelper.FindBlock(RuleHydrosRAO);
            StringBuilder HydrosRA = new StringBuilder();

            for (int i = 1; i < HydrosR.Rows.Count - 1; i++)
            {
                HydrosRA.AppendLine(HydrosR.Rows[i].Value);
            }
            //为避免最后一行有换行符，最后一行单独加入
            if (HydrosR.Rows.Count > 0)
            {
                HydrosRA.Append(HydrosR.Rows[HydrosR.Rows.Count - 1].Value);
            }

            string HydrosRAO = HydrosRA.ToString();

            //取结果的规则
            RTTxtDataParseHelp.Rule RuleDampRAO = new RTTxtDataParseHelp.Rule("FrequencyDependentAddedMassAndDamping:", "# Other Damping", RTTxtDataParseHelp.Mode.FuzzyMatch, RTTxtDataParseHelp.Mode.FuzzyMatch);

            RTTxtDataParseHelp.Block DampR = ParseHelper.FindBlock(RuleDampRAO);
            StringBuilder DampRA = new StringBuilder();

            for (int i = 1; i < DampR.Rows.Count - 1; i++)
            {
                DampRA.AppendLine(DampR.Rows[i].Value);
            }
            //为避免最后一行有换行符，最后一行单独加入
            if (DampR.Rows.Count > 0)
            {
                DampRA.Append(DampR.Rows[DampR.Rows.Count - 1].Value);
            }

            string DampRAO = DampRA.ToString();

            #endregion
            //VesselType
            #region VesselType
            {
                TxtSection VesselType = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "VesselType");
                TxtSection VesselTypesInstance = VesselType.AddOneSelfInstance();
                VesselTypesInstance.m_ParList.Find(p1 => p1.m_Name == "Length").m_ValueStr = ModelParameterObj.VesselType.Length.ToString();
                TxtSection Draught = VesselTypesInstance.m_ChildSection.Find(p1 => p1.m_Name == "Draught");
                TxtSection DraughtInstance = Draught.AddOneSelfInstance();
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "AAAName").m_ValueStr = ModelParameterObj.VesselType.Draught.Name;
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "Mass").m_ValueStr = ModelParameterObj.VesselType.Draught.Mass.ToString();
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "MomentOfInertiaTensorRow1").m_ValueStr = ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[0].m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[0].m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[0].m_Z.ToString();
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "MomentOfInertiaTensorRow2").m_ValueStr = ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[1].m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[1].m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[1].m_Z.ToString();
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "MomentOfInertiaTensorRow3").m_ValueStr = ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[2].m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[2].m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.MomentOfInertiaTensor[2].m_Z.ToString();
                DraughtInstance.m_ParList.Find(p1 => p1.m_Name == "CentreOfGravity").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                TxtSection DisplacementRAOs = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "DisplacementRAOs");
                TxtSection DisplacementRAOsInstance = DisplacementRAOs.AddOneSelfInstance();
                DisplacementRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "RAOOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                DisplacementRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "DisplacementRAO").m_ValueStr = DisRAO;
                //DisplacementRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "PhaseOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString()  + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                // TxtSection DisplRAODirection = DisplacementRAOsInstance.m_ChildSection.Find(p1 => p1.m_Name == "DisplRAODirection");
                TxtSection LoadRAOs = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "LoadRAOs");
                TxtSection LoadRAOsInstance = LoadRAOs.AddOneSelfInstance();
                LoadRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "RAOOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                LoadRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "LoadRAO").m_ValueStr = LoadRAO;
                //LoadRAOsInstance.m_ParList.Find(p1 => p1.m_Name == "PhaseOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + "," + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                //TxtSection LoadRAODirection = LoadRAOsInstance.m_ChildSection.Find(p1 => p1.m_Name == "LoadRAODirection");
                TxtSection NewmanMethod = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "NewmanMethod");
                TxtSection NewmanMethodInstance = NewmanMethod.AddOneSelfInstance();
                NewmanMethodInstance.m_ParList.Find(p1 => p1.m_Name == "RAOOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                NewmanMethodInstance.m_ParList.Find(p1 => p1.m_Name == "WaveDriftRAO").m_ValueStr = WaveDriftRAO;
                TxtSection StiffnessAddedMassDamping = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "StiffnessAddedMassDamping");
                TxtSection StiffnessAddedMassDampingInstance = StiffnessAddedMassDamping.AddOneSelfInstance();
                StiffnessAddedMassDampingInstance.m_ParList.Find(p1 => p1.m_Name == "ReferenceOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                StiffnessAddedMassDampingInstance.m_ParList.Find(p1 => p1.m_Name == "ReferenceOriginDatumPosition").m_ValueStr = ModelParameterObj.VesselType.Draught.AdjustFloat.m_X.ToString() + "," + ModelParameterObj.VesselType.Draught.AdjustFloat.m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.AdjustFloat.m_Z.ToString();
                StiffnessAddedMassDampingInstance.m_ParList.Find(p1 => p1.m_Name == "Hydrostatics").m_ValueStr = HydrosRAO;
                StiffnessAddedMassDampingInstance.m_ParList.Find(p1 => p1.m_Name == "Damping").m_ValueStr = DampRAO;
                //TxtSection LoadRAODirection = LoadRAOsInstance.m_ChildSection.Find(p1 => p1.m_Name == "LoadRAODirection");
                TxtSection OtherDamping = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "OtherDamping");
                TxtSection OtherDampingInstance = OtherDamping.AddOneSelfInstance();
                OtherDampingInstance.m_ParList.Find(p1 => p1.m_Name == "OtherDampingOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CentreOfGravity.m_X.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Y.ToString() + ", " + ModelParameterObj.VesselType.Draught.CentreOfGravity.m_Z.ToString();
                TxtSection CurrentLoad = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "CurrentLoad");
                TxtSection CurrentLoadInstance = CurrentLoad.AddOneSelfInstance();
                CurrentLoadInstance.m_ParList.Find(p1 => p1.m_Name == "SurgeArea").m_ValueStr = ModelParameterObj.VesselType.Draught.CurrentArea.SurgeArea.ToString();
                CurrentLoadInstance.m_ParList.Find(p1 => p1.m_Name == "SwayArea").m_ValueStr = ModelParameterObj.VesselType.Draught.CurrentArea.SwayArea.ToString();
                CurrentLoadInstance.m_ParList.Find(p1 => p1.m_Name == "YawArea").m_ValueStr = ModelParameterObj.VesselType.Draught.CurrentArea.YawArea.ToString();
                CurrentLoadInstance.m_ParList.Find(p1 => p1.m_Name == "CurrentDragOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.CurrentDragOrigin.m_X.ToString() + "," + ModelParameterObj.VesselType.Draught.CurrentDragOrigin.m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.CurrentDragOrigin.m_Z.ToString();
                TxtSection WindLoad = DraughtInstance.m_ChildSection.Find(p1 => p1.m_Name == "WindLoad");
                TxtSection WindLoadInstance = WindLoad.AddOneSelfInstance();
                WindLoadInstance.m_ParList.Find(p1 => p1.m_Name == "SurgeArea").m_ValueStr = ModelParameterObj.VesselType.Draught.WindArea.SurgeArea.ToString();
                WindLoadInstance.m_ParList.Find(p1 => p1.m_Name == "SwayArea").m_ValueStr = ModelParameterObj.VesselType.Draught.WindArea.SwayArea.ToString();
                WindLoadInstance.m_ParList.Find(p1 => p1.m_Name == "YawArea").m_ValueStr = ModelParameterObj.VesselType.Draught.WindArea.YawArea.ToString();
                WindLoadInstance.m_ParList.Find(p1 => p1.m_Name == "WindDragOrigin").m_ValueStr = ModelParameterObj.VesselType.Draught.WindDragOrigin.m_X.ToString() + "," + ModelParameterObj.VesselType.Draught.WindDragOrigin.m_Y.ToString() + "," + ModelParameterObj.VesselType.Draught.WindDragOrigin.m_Z.ToString();

            }
            #endregion

            //LineTypes
            #region LineTypes
            {
                TxtSection LineTypes = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "LineTypes");
                for (int i = 0; i < ModelParameterObj.LineTypeList.Count; i++)
                {
                    TxtSection LineTypesInstance = LineTypes.AddOneSelfInstance();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "AAAName").m_ValueStr = ModelParameterObj.LineTypeList[i].Name;
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "Category").m_ValueStr = "General";
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "OD").m_ValueStr = ModelParameterObj.LineTypeList[i].OD.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "ID").m_ValueStr = ModelParameterObj.LineTypeList[i].ID.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "MassPerUnitLength").m_ValueStr = ModelParameterObj.LineTypeList[i].MassPerUnit.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "CompressionIsLimited").m_ValueStr = ModelParameterObj.LineTypeList[i].CompressionIsLimited == true ? "Yes" : "No";
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "EA").m_ValueStr = ModelParameterObj.LineTypeList[i].AxialStiffness.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "ContactDiameter").m_ValueStr = ModelParameterObj.LineTypeList[i].ContactDiameter.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "Ca").m_ValueStr = ModelParameterObj.LineTypeList[i].AddedMassCoefficients.m_X.ToString() + "," + "~" + "," + ModelParameterObj.LineTypeList[i].AddedMassCoefficients.m_Z.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "Cd").m_ValueStr = ModelParameterObj.LineTypeList[i].DragCoefficient.m_X.ToString() + "," + "~" + "," + ModelParameterObj.LineTypeList[i].DragCoefficient.m_Z.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "NormalDragLiftDiameter").m_ValueStr = ModelParameterObj.LineTypeList[i].NormalDragLiftDiameter.ToString();
                    LineTypesInstance.m_ParList.Find(p1 => p1.m_Name == "AxialDragLiftDiameter").m_ValueStr = ModelParameterObj.LineTypeList[i].AxialDragLiftDiameter.ToString();
                }
            }
            #endregion


            //Vessel
            #region Vessel
            {
                TxtSection Vessel = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "Vessel");
                TxtSection VesselInstance = Vessel.AddOneSelfInstance();
                //VesselInstance.m_ParList.Find(p1 => p1.m_Name == "AAAName").m_ValueStr = "Vessel1";
                //VesselInstance.m_ParList.Find(p1 => p1.m_Name == "VesselType").m_ValueStr = "Vessel Type1";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "Draught").m_ValueStr = ModelParameterObj.VesselType.Draught.Name;
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "Length").m_ValueStr = "~";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "InitialPosition").m_ValueStr = (0).ToString() + ", " + (0).ToString() + ", " + (0).ToString();
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "Orientation").m_ValueStr = (0).ToString() + ", " + (0).ToString() + ", " + (0).ToString();
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludedInStatics").m_ValueStr = "6 DOF";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "PrimaryMotion").m_ValueStr = "Calculated (6 DOF)";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "SuperimposedMotion").m_ValueStr = "None";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeAppliedLoads").m_ValueStr = "No";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeWaveLoad1stOrder").m_ValueStr = "Yes";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeWaveDriftLoad2ndOrder").m_ValueStr = "Yes";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeWaveDriftDamping").m_ValueStr = "No";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeSumFrequencyLoad").m_ValueStr = "No";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeAddedMassAndDamping").m_ValueStr = "Yes";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeManoeuvringLoad").m_ValueStr = "No";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeOtherDamping").m_ValueStr = "No";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeCurrentLoad").m_ValueStr = "Yes";
                VesselInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeWindLoad").m_ValueStr = "Yes";
            }

            #endregion


            //Line
            #region Line
            {
                TxtSection Line = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "Line");
                for (int i = 0; i < ModelParameterObj.LineList.Count; i++)
                {
                    TxtSection LineInstance = Line.AddOneSelfInstance();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "AAAName").m_ValueStr = ModelParameterObj.LineList[i].Name;
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeTorsion").m_ValueStr = "No";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "TopEnd").m_ValueStr = "End A";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "PyModel").m_ValueStr = "(none)";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "DragFormulation").m_ValueStr = "Standard";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "StaticsVIV").m_ValueStr = "None";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "DynamicsVIV").m_ValueStr = "None";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "WaveCalculationMethod").m_ValueStr = "Specified by Environment";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "Fairleads").m_ValueStr = ModelParameterObj.LineList[i].Fairleads.m_X.ToString() + "," + ModelParameterObj.LineList[i].Fairleads.m_Y.ToString() + "," + ModelParameterObj.LineList[i].Fairleads.m_Z.ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "AnchorPoint").m_ValueStr = ModelParameterObj.LineList[i].AnchorPoint.m_X.ToString() + "," + ModelParameterObj.LineList[i].AnchorPoint.m_Y.ToString() + "," + ModelParameterObj.LineList[i].AnchorPoint.m_Z.ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "Connection1Stiffness").m_ValueStr = (0).ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "Connection2Stiffness").m_ValueStr = (0).ToString();
                    TxtSection LineSection = LineInstance.m_ChildSection.Find(p1 => p1.m_Name == "LineSection");
                    for (int j = 0; j < ModelParameterObj.LineList[i].LineSectionList.Count; j++)
                    {
                        TxtSection LineSectionInstance = LineSection.AddOneSelfInstance();
                        LineSectionInstance.m_ParList.Find(p1 => p1.m_Name == "LineSectionName").m_ValueStr = ModelParameterObj.LineList[i].LineSectionList[j].LineTypeName;
                        LineSectionInstance.m_ParList.Find(p1 => p1.m_Name == "LineSectionLength").m_ValueStr = ModelParameterObj.LineList[i].LineSectionList[j].LineLength.ToString();

                    }
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "ContentsMethod").m_ValueStr = "Uniform";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeAxialContentsInertia").m_ValueStr = "Yes";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "ContentsDensity").m_ValueStr = (0).ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "ContentsPressureRefZ").m_ValueStr = "~";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "ContentsPressure").m_ValueStr = (0).ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "ContentsFlowRate").m_ValueStr = (0).ToString();
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "IncludedInStatics").m_ValueStr = "Yes";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "StaticsStep1").m_ValueStr = "Catenary";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "StaticsStep2").m_ValueStr = "Full Statics";
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "IncludeSeabedFrictionInStatics").m_ValueStr = "Yes";
                    double Azimuth = ModelParameterObj.LineList[i].LayAzimuth;
                    ///坐标转换
                    if (Azimuth < 180)
                    {
                        LineInstance.m_ParList.Find(p1 => p1.m_Name == "LayAzimuth").m_ValueStr = (ModelParameterObj.LineList[i].LayAzimuth + 180).ToString();
                    }
                    else if (Azimuth >= 180)
                    {
                        LineInstance.m_ParList.Find(p1 => p1.m_Name == "LayAzimuth").m_ValueStr = (ModelParameterObj.LineList[i].LayAzimuth - 180).ToString();
                    }
                    LineInstance.m_ParList.Find(p1 => p1.m_Name == "AsLaidTension").m_ValueStr = (0).ToString();
                }
            }
            #endregion

            #region Structure
            {
                TxtSection Structure = RootSectionInstance.m_ChildSection.Find(p1 => p1.m_Name == "Structure");
                TxtSection StructureInstance = Structure.AddOneSelfInstance();
                TxtSection LineModel = StructureInstance.m_ChildSection.Find(p1 => p1.m_Name == "LineModel");
                for (int i = 0; i < ModelParameterObj.LineList.Count; i++)
                {
                    TxtSection LineModelInstance = LineModel.AddOneSelfInstance();
                    LineModelInstance.m_ParList.Find(p1 => p1.m_Name == "LineModel").m_ValueStr = ModelParameterObj.LineList[i].Name;
                }
            }

            #endregion


            // 获得FID的bin目录下的FID(这个获得的就是一个主进程)（准确来说，并不是获得具体某个FID或者其他单个程序的bin，而是泛指你所在的是哪个程序来决定的）
            //System.Reflection.Assembly Assem = System.Reflection.Assembly.GetExecutingAssembly();
            // 获得bin目录下的具体子目录，更改后一个参数即可  
            //(Assem.Location)得到的是FID.exe,然后前面的GetdirectoryName函数也就是去掉了.exe,也就是获得了目录，然后与之后的那个目录文件夹相连，就变成了一个完成的路径。
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

            #endregion


            #region 调用OrcaFlex进行分析
            //取一个可以进行Orcaflex分析的文本
            OrcaFlexModel model = new OrcaFlexModel(System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.dat"));
            //进行OrcaFlex分析
            model.RunSimulation();
            //将分析的结果文件保存成结果文件
            model.SaveSimulation(System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.sim"));

            // model.SaveSpreadsheet(@"F:\mooringtest\MooringAnalysisFile800sim.xlsx", Orcina.OrcFxAPI.SpreadsheetType.FullResults);

            model.SaveSpreadsheet(System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.xlsx"), Orcina.OrcFxAPI.SpreadsheetType.FullResults);
            System.Threading.Thread.Sleep(1000);

            #endregion


            #region 读取OrcaFlex结果
            CMooringResultGet MooringResultGet = new CMooringResultGet();
            string FIDBinDir = System.IO.Path.Combine(m_Workdir, "MooringAnalysisFile.xlsx");
            //string FIDBinDir = @"D:\mooringResultTest\MooringAnalysisFile.xlsx";
            CMooringAnalysisResult MooringAnalysisResultObj = new CMooringAnalysisResult();
            double VesselDis_X = MooringResultGet.AnalysisMooringFile(ModelParameterObj.LineList.Count, FIDBinDir).VesselDis.PositionX;
            double VesselDis_Y = MooringResultGet.AnalysisMooringFile(ModelParameterObj.LineList.Count, FIDBinDir).VesselDis.PositionY;
            double VesselDis_Z = MooringResultGet.AnalysisMooringFile(ModelParameterObj.LineList.Count, FIDBinDir).VesselDis.PositionZ;
            List<double> FairleadList = new List<double>();
            List<double> AnchorList = new List<double>();
            List<string> Linename = new List<string>();

            OrcaflexMooringRiserDomainModel.CMooringAnalysisResult MooringLineResult = MooringResultGet.AnalysisMooringFile(ModelParameterObj.LineList.Count, FIDBinDir);
            for (int i = 0; i < MooringLineResult.MoorLineForceList.Count; i++)
            {
                FairleadList.Add(MooringLineResult.MoorLineForceList[i].EndAFairForce);
            }

            for (int i = 0; i < MooringLineResult.MoorLineForceList.Count; i++)
            {
                AnchorList.Add(MooringLineResult.MoorLineForceList[i].EndBAnchForce);
            }

            for (int i = 1; i <= MooringLineResult.MoorLineForceList.Count; i++)
            {
                Linename.Add("Line"+i.ToString());
            }

            OutResult.MooringAnalysisResult.VesselDisResult.VesselDis.m_X = VesselDis_X;
            OutResult.MooringAnalysisResult.VesselDisResult.VesselDis.m_Y = VesselDis_Y;
            OutResult.MooringAnalysisResult.VesselDisResult.VesselDis.m_Z = VesselDis_Z;
            OutResult.MooringAnalysisResult.FairleadForce = FairleadList;
            OutResult.MooringAnalysisResult.AnchorForce = AnchorList;
            OutResult.MooringAnalysisResult.LineName = Linename;



            #endregion

            return false;
        }
```

### 调用软件界面

```C#
        /// <summary>
        /// 调用OrcaFlex将WAMIT水动力结果转换为可用形式
        /// </summary>
        /// <param name="InputFileFullPath"></param>需要转化的WAMIT的分析结果
        /// <param name="OutYmlFileFullPath"></param>转化成功的OrcaFlex可用的水动力形式
        static void MakeYmlFileWithOrcaFlex(string InputFileFullPath, string OutYmlFileFullPath)
        {
            System.Diagnostics.Process CadProcess = new System.Diagnostics.Process();
            //找到OrcaFlex软件
            CadProcess.StartInfo.FileName = @"C:\Program Files (x86)\Orcina\OrcaFlex\10.1\OrcaFlex64.exe";
            //启动OrcaFlex软件
            CadProcess.Start();

            CadProcess.WaitForInputIdle();

            //string HCCadTitleStr = "* OrcaFlex 10.1a";
            string HCCadTitleStr = "OrcaFlex 10.1a";
            //句柄、窗口初始值为空
            IntPtr HCCadWndHwnd = IntPtr.Zero;
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                //找到主窗口为"OrcaFlex 10.1a"的一个窗口
                HCCadWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, HCCadTitleStr);

                if (HCCadWndHwnd != IntPtr.Zero)
                {
                    System.Threading.Thread.Sleep(5000);
                    HCCadWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, HCCadTitleStr);
                    break;
                }
            }

            //获得某个窗口的焦点，或者理解为定位某个窗口。
            //RTUIIntegration.WinAPIMethod.SetForegroundWindow(HCCadWndHwnd);
            RTUIIntegration.RtWndContal.SetForegroundWindow(HCCadWndHwnd);

            System.Threading.Thread.Sleep(2000);


            //键盘命令 Alt+M+T+V， 新建Vess Type类型
            {
                //按下Alt
                RTUIIntegration.WinAPIMethod.keybd_event(18, 0, 0, 0);
                System.Threading.Thread.Sleep(10);
                //按下M
                RTUIIntegration.WinAPIMethod.keybd_event(77, 0, 0, 0);
                System.Threading.Thread.Sleep(10);
                //抬起M
                RTUIIntegration.WinAPIMethod.keybd_event(77, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                System.Threading.Thread.Sleep(10);
                //按下T
                RTUIIntegration.WinAPIMethod.keybd_event(84, 0, 0, 0);
                System.Threading.Thread.Sleep(10);
                //抬起T
                RTUIIntegration.WinAPIMethod.keybd_event(84, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                System.Threading.Thread.Sleep(10);
                //按下V
                RTUIIntegration.WinAPIMethod.keybd_event(86, 0, 0, 0);
                System.Threading.Thread.Sleep(10);
                //抬起V
                RTUIIntegration.WinAPIMethod.keybd_event(86, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                System.Threading.Thread.Sleep(10);
                //抬起Alt
                RTUIIntegration.WinAPIMethod.keybd_event(18, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                System.Threading.Thread.Sleep(10);
            }


            #region //导入数据
            {
                //使左侧特征树获得焦点
                {
                    IntPtr Panel1WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(HCCadWndHwnd, IntPtr.Zero, "TPanel", null);
                    IntPtr Panel2WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(HCCadWndHwnd, Panel1WndHwnd, "TPanel", null);


                    IntPtr TModelBrowserWndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Panel2WndHwnd, IntPtr.Zero, null, "Model Browser");


                    IntPtr Panel3WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(TModelBrowserWndHwnd, IntPtr.Zero, "TPanel", null);
                    IntPtr Panel4WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(TModelBrowserWndHwnd, Panel3WndHwnd, "TPanel", null);

                    IntPtr Tree1WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Panel4WndHwnd, IntPtr.Zero, "TTreeViewFrame", null);
                    IntPtr Tree2WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Tree1WndHwnd, IntPtr.Zero, "TOrcTreeView", null);


                    //获得某个窗口的焦点，或者理解为定位某个窗口。
                    RTUIIntegration.WinAPIMethod.SetForegroundWindow(Tree2WndHwnd);
                    System.Threading.Thread.Sleep(10);
                }


                //回车，触发对Vessel Type的编辑
                {
                    //按下回车
                    RTUIIntegration.WinAPIMethod.keybd_event(13, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    //抬起回车
                    RTUIIntegration.WinAPIMethod.keybd_event(13, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                    System.Threading.Thread.Sleep(10);
                }


                //类似上面，这里是找到了名为"Edit Vessel Type Data"的一个窗口
                string EditVesselTitleStr = "Edit Vessel Type Data";
                IntPtr EditVesselWndHwnd = IntPtr.Zero;
                while (true)
                {
                    System.Threading.Thread.Sleep(100);
                    EditVesselWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, EditVesselTitleStr);
                    if (EditVesselWndHwnd != IntPtr.Zero)
                    {
                        System.Threading.Thread.Sleep(100);
                        EditVesselWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, EditVesselTitleStr);
                        break;
                    }
                }
                System.Threading.Thread.Sleep(500);

                {
                    IntPtr But1WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(EditVesselWndHwnd, IntPtr.Zero, null, "Import...");
                    //点击import按钮
                    RTUIIntegration.WinAPIMethod.PostMessage(But1WndHwnd, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                }
                System.Threading.Thread.Sleep(1000);


                IntPtr SelectVesselWndHwnd = IntPtr.Zero;
                {
                    //类似上面，这里是找到了名为"Select Vessel Hydrodynamic Data File"的一个窗口
                    string SelectVesselTitleStr = "Select Vessel Hydrodynamic Data File";
                    while (true)
                    {
                        System.Threading.Thread.Sleep(100);
                        SelectVesselWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, SelectVesselTitleStr);
                        if (SelectVesselWndHwnd != IntPtr.Zero)
                        {
                            System.Threading.Thread.Sleep(100);
                            SelectVesselWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, SelectVesselTitleStr);
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                }

                {
                    IntPtr Com1WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SelectVesselWndHwnd, IntPtr.Zero, "ComboBoxEx32", null);
                    IntPtr Com2WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Com1WndHwnd, IntPtr.Zero, "ComboBox", null);
                    IntPtr EditWndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Com2WndHwnd, IntPtr.Zero, "Edit", null);
                    //找到输入文件的路径
                    RTUIIntegration.WinAPIMethod.SendMessage(EditWndHwnd, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, InputFileFullPath);
                }
                System.Threading.Thread.Sleep(2000);
                {
                    //点击打开
                    IntPtr But2WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SelectVesselWndHwnd, IntPtr.Zero, null, "打开(&O)");
                    RTUIIntegration.WinAPIMethod.SendMessage(But2WndHwnd, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                }
                System.Threading.Thread.Sleep(3000);


                IntPtr ImportVesselDataWndHwnd = IntPtr.Zero;
                {
                    //类似上面，这里是找到了名为"Import Vessel Data"的一个窗口
                    string ImportVesselDataTitleStr = "Import Vessel Data";
                    while (true)
                    {
                        System.Threading.Thread.Sleep(100);
                        ImportVesselDataWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, ImportVesselDataTitleStr);
                        if (ImportVesselDataWndHwnd != IntPtr.Zero)
                        {
                            System.Threading.Thread.Sleep(100);
                            ImportVesselDataWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, ImportVesselDataTitleStr);
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }

                {
                    IntPtr Tb111WndHwnd1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ImportVesselDataWndHwnd, IntPtr.Zero, "TPanel", null);
                    //点击import按钮
                    IntPtr But3WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Tb111WndHwnd1, IntPtr.Zero, null, "&Import");
                    RTUIIntegration.WinAPIMethod.SendMessage(But3WndHwnd, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                    System.Threading.Thread.Sleep(2000);
                    //然后再点击close按钮
                    IntPtr But4WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Tb111WndHwnd1, IntPtr.Zero, null, "&Close");
                    RTUIIntegration.WinAPIMethod.SendMessage(But4WndHwnd, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                }
                System.Threading.Thread.Sleep(1000);


                //关闭EditVess窗口
                {
                    //然后再点击OK按钮
                    IntPtr But1WndHwnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(EditVesselWndHwnd, IntPtr.Zero, null, "OK");
                    RTUIIntegration.WinAPIMethod.SendMessage(But1WndHwnd, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                }


                //键盘命令 Alt+F+D， 保存数据
                {
                    RTUIIntegration.WinAPIMethod.keybd_event(18, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);

                    RTUIIntegration.WinAPIMethod.keybd_event(70, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    RTUIIntegration.WinAPIMethod.keybd_event(70, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                    System.Threading.Thread.Sleep(10);

                    RTUIIntegration.WinAPIMethod.keybd_event(68, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    RTUIIntegration.WinAPIMethod.keybd_event(68, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                    System.Threading.Thread.Sleep(10);

                    RTUIIntegration.WinAPIMethod.keybd_event(18, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                    System.Threading.Thread.Sleep(10);
                }
            }
            #endregion


            #region //Save Data 保存文件
            {
                IntPtr FileSaveDataWndHwnd = IntPtr.Zero;
                {
                    //类似上面，这里是找到了名为"Save Data"的一个窗口
                    string TitleStr = "Save Data";
                    while (true)
                    {
                        System.Threading.Thread.Sleep(100);
                        FileSaveDataWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, TitleStr);
                        if (FileSaveDataWndHwnd != IntPtr.Zero)
                        {
                            System.Threading.Thread.Sleep(100);
                            FileSaveDataWndHwnd = RTUIIntegration.WinAPIMethod.FindWindow(null, TitleStr);
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(2000);
                }
                RTUIIntegration.WinAPIMethod.SetForegroundWindow(FileSaveDataWndHwnd);


                IntPtr Hwnd1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FileSaveDataWndHwnd, IntPtr.Zero, "DUIViewWndClassName", null);
                IntPtr Hwnd2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd1, IntPtr.Zero, "DirectUIHWND", null);
                IntPtr Hwnd3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd2, IntPtr.Zero, "FloatNotifySink", null);

                //修改保存类型 combox选择值
                {
                    IntPtr Hwnd4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd2, Hwnd3, "FloatNotifySink", null);
                    IntPtr Combo1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd4, IntPtr.Zero, "ComboBox", null);

                    //RTUIIntegration.WinAPIMethod.SendMessage(Combo1, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                    RTUIIntegration.WinAPIMethod.SetForegroundWindow(Combo1);
                    System.Threading.Thread.Sleep(100);

                    //下箭头 + 回车
                    {
                        RTUIIntegration.WinAPIMethod.keybd_event(40, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        RTUIIntegration.WinAPIMethod.keybd_event(40, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(10);

                        RTUIIntegration.WinAPIMethod.keybd_event(40, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        RTUIIntegration.WinAPIMethod.keybd_event(40, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(10);

                        RTUIIntegration.WinAPIMethod.keybd_event(13, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        RTUIIntegration.WinAPIMethod.keybd_event(13, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(10);
                    }

                    System.Threading.Thread.Sleep(1000);
                }

                {
                    IntPtr Hwnd4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd3, IntPtr.Zero, "ComboBox", null);
                    IntPtr Edit4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Hwnd4, IntPtr.Zero, "Edit", null);

                    RTUIIntegration.WinAPIMethod.SetForegroundWindow(Edit4);

                    if (System.IO.File.Exists(OutYmlFileFullPath))
                    {
                        System.IO.File.Delete(OutYmlFileFullPath);
                    }

                    string OutFileWithExtendFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(OutYmlFileFullPath), System.IO.Path.GetFileNameWithoutExtension(OutYmlFileFullPath));

                    RTUIIntegration.WinAPIMethod.SendMessage(Edit4, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, OutFileWithExtendFileName);
                    System.Threading.Thread.Sleep(500);
                    //因为直接采用WM_SETTEXT消息时，此对话框不认识输入内容，所以以下对其进行一些键盘输入操作
                    //依次触发右键头，a，退格键
                    RTUIIntegration.WinAPIMethod.SetForegroundWindow(Edit4);
                    {
                        RTUIIntegration.WinAPIMethod.keybd_event(49, 0, 0, 0);
                        System.Threading.Thread.Sleep(100);
                        RTUIIntegration.WinAPIMethod.keybd_event(49, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(100);

                        System.Threading.Thread.Sleep(500);

                        RTUIIntegration.WinAPIMethod.keybd_event(8, 0, 0, 0);
                        System.Threading.Thread.Sleep(100);
                        RTUIIntegration.WinAPIMethod.keybd_event(8, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(100);
                    }

                    System.Threading.Thread.Sleep(500);
                }


                {
                    //点击保存
                    IntPtr OK4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FileSaveDataWndHwnd, IntPtr.Zero, null, "保存(&S)");
                    RTUIIntegration.WinAPIMethod.SendMessage(OK4, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                }
                System.Threading.Thread.Sleep(1000);
                //string PathOrc = @"E:\FFDEW3333.yml";
                //System.IO.File.Copy(@"C:\WAMITv6\FPSOF\FFDEW3333.yml", PathOrc, true);
            }
            #endregion
            //System.Threading.Thread.Sleep(1000);
            //关掉这个进程
            //CadProcess.WaitForExit();                                  //等待程序执行完退出进程
            //CadProcess.Close();
            CadProcess.Kill();  //结束线程

        }
```

### 调用Mars界面问题

```c#
static class RuleCheck
    {
        /// <summary>
        /// 进行规范计算
        /// </summary>
        /// <param name="IptRule">规范类型</param>
        /// <param name="OptFileFullPath">输出文件路径</param>
        /// <returns>校核成功</returns>
        public static bool DoRuleCheck(FIDFPSOData.FIDFPSOData.CRules IptRule,out string OptFileFullPath,out List<string> OptFileNameList)
        {
            //BV船级社规范
            if (IptRule == FIDFPSOData.FIDFPSOData.CRules.BV)
            {
                #region BV Mars软件输入文件模板
                // 摘要:
                //     当模板内容在作为程序集资源文件存在时的对应关系,使用示例入校 // 注意1：在运行前请将目标模板文件的“生成格式”设置为“嵌入的资源”，否则运行会出现异常。
                //     // 具体设置方法：右击目标模板文件，选择“属性”，选择“生成格式”，更改为“嵌入的资源”。 // 注意2：在运行前请将目标模板文件的文件格式更改为“Unicode”，否则运行会出现异常。
                //     // 具体设置方法请参考：https://jingyan.baidu.com/article/46650658001823f548e5f851.html
                TxtWriteTemplate.TemplateResouceInAssemblyRelInf TemplateResouceInAssemblyRelInfObj
                = new TxtWriteTemplate.TemplateResouceInAssemblyRelInf();
                TemplateResouceInAssemblyRelInfObj.ResouceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                {
                    TxtWriteTemplate.TemplateResouceInAssemblyRelInf.OneTemplateFile
                        AA = new TxtWriteTemplate.TemplateResouceInAssemblyRelInf.OneTemplateFile();
                    AA.TemplateFileName = "MarsInputFile.txt";
                    AA.TemplateFullPathInAssembly
                    = "FIDFPSOStructAnlyse.Template.MarsInputFile.txt";
                    TemplateResouceInAssemblyRelInfObj.TemplateFileResouceRelList.Add(AA);
                }
                TxtWriteTemplate WriteFile = new TxtWriteTemplate();
                TxtSection MarsTextSection = WriteFile.InitrialFromTxtTemplate("MarsInputFile.txt", TemplateResouceInAssemblyRelInfObj);
                TxtSection RootSectionInstance = MarsTextSection.AddOneSelfInstance();

                System.Reflection.Assembly Assem = System.Reflection.Assembly.GetExecutingAssembly();
                string MarsInputFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assem.Location), @"MarsFile");
                string WorkDir = MarsInputFilePath;
                string MarsFileName = "MarsInputFile.ma2";
                string MarsWorkDir = MarsInputFilePath + "\\" + MarsFileName;

                ///拷贝模板到目录 此处由于有问题暂时注释掉
                if (System.IO.Directory.Exists(MarsInputFilePath))
                {
                    System.IO.Directory.Delete(MarsInputFilePath, true);
                }
                System.IO.Directory.CreateDirectory(MarsInputFilePath);
                while (System.IO.Directory.Exists(MarsInputFilePath))
                {
                    WriteFile.MakeResultTxtFile("MarsInputFile.txt", MarsTextSection, System.IO.Path.Combine(WorkDir, MarsFileName), TemplateResouceInAssemblyRelInfObj);
                    break;
                }
                #endregion
                string MarsMa2Content = System.IO.File.ReadAllText(MarsWorkDir);
                byte[] buf = System.Text.Encoding.Default.GetBytes(MarsMa2Content);
                System.IO.FileStream af = new System.IO.FileStream(MarsWorkDir, System.IO.FileMode.Create);
                af.Write(buf, 0, buf.Length);
                af.Flush();
                af.Close();
                //调用BV Mars软件
                OptFileFullPath = MarsInputFilePath;
                OptFileNameList = null;
                bool MarsRun = ControlMarsCal(MarsWorkDir, OptFileFullPath, out OptFileNameList);
                if (MarsRun)
                {
                    return true;
                }
                return false;
            }
            //CCS 船级社规范实现
            else if (IptRule == FIDFPSOData.FIDFPSOData.CRules.BV)
            {
                throw new Exception("CCS Rule is not available right now");
            }
            //其他船级社
            else
            {
                throw new Exception("This Rule is not available right now");
            }
            return false;
        }
        /// <summary>
        /// 调用Mars进行计算
        /// </summary>
        /// <param name="IptFileFullPath">输入文件的全部路径</param>
        /// <param name="OutFolderFullPath">输出文件存放地址</param>
        /// <param name="OutFileNameList">输入文件名子</param>
        /// <returns>计算成功</returns>
        private static bool ControlMarsCal(string IptFileFullPath, string OutFolderFullPath,out List<string> OutFileNameList)
        {
            //调用BV Mars软件
            #region 启动BV软件
            ////使用CMD方式启动
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            //p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            //p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            //p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            ////p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            //bool CreatWindowBool = p.StartInfo.CreateNoWindow;

            //p.Start();//启动程序

            ////向cmd窗口发送输入信息
            //string CmdStr = @"C:";
            //p.StandardInput.WriteLine(CmdStr);
            //p.StandardInput.AutoFlush = true;

            //CmdStr = @"C:\BVeritas\Mars2000\Mars2000.exe";
            //p.StandardInput.WriteLine(CmdStr);
            //p.StandardInput.AutoFlush = true;

            //启动Mars
            System.Diagnostics.Process MarsP = new System.Diagnostics.Process();
            MarsP.StartInfo.FileName = @"C:\BVeritas\Mars2000\Mars2000.exe";
            MarsP.Start();
            MarsP.WaitForInputIdle();

            IntPtr MarsHandle = RTUIIntegration.RtWndContal.WaitAndFindWindow(null, "Mars 2000");
            if (MarsHandle.Equals(IntPtr.Zero))
                MarsHandle = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6Main", null);
            if (MarsHandle.Equals(IntPtr.Zero))
            {
                throw new Exception("BV结构计算软件调用异常");
            }
            OutFileNameList = null;
            //IntPtr a = RTUIIntegration.WinAPIMethod

            FIDDataBase.FIDLogData.PrintInfo("正在调用BV软件............");

            //需要开启一个新的进程
            //System.Diagnostics.Process MarsProcesss = new System.Diagnostics.Process();
            //while (true)
            {
                MarsHandle = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", null);
                if (!MarsHandle.Equals(IntPtr.Zero))
                {
                    System.Threading.Thread.Sleep(5000);
                    RTUIIntegration.RtWndContal.SetForegroundWindow(MarsHandle);
                    System.Threading.Thread.Sleep(10);
                    //键盘命令 按下Alt->F->O->Alt+B->文件名处写入输入文件的全路径名
                    {
                        //按下Alt
                        RTUIIntegration.WinAPIMethod.keybd_event(18, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        //F
                        RTUIIntegration.WinAPIMethod.keybd_event(70, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        //!F
                        RTUIIntegration.WinAPIMethod.keybd_event(70, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(10);
                        //O
                        RTUIIntegration.WinAPIMethod.keybd_event(79, 0, 0, 0);
                        System.Threading.Thread.Sleep(10);
                        //!O
                        RTUIIntegration.WinAPIMethod.keybd_event(79, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        System.Threading.Thread.Sleep(10);
                        //!Alt
                        RTUIIntegration.WinAPIMethod.keybd_event(18, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        IntPtr Open = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6FormDC", "Open database");
                        IntPtr Location = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Open, IntPtr.Zero, "ThunderRT6Frame", "Location");
                        IntPtr Browse = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Location, IntPtr.Zero, "ThunderRT6CommandButton", "&Browse...");
                        //RTUIIntegration.RtWndContal.SetForegroundWindow(Open);
                        RTUIIntegration.WinAPIMethod.PostMessage(Browse, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                        //System.Threading.Thread.Sleep(10);
                        //System.Threading.Thread.Sleep(100);
                        ////B
                        //RTUIIntegration.WinAPIMethod.keybd_event(66, 0, 0, 0);
                        //System.Threading.Thread.Sleep(10);
                        ////!B
                        //RTUIIntegration.WinAPIMethod.keybd_event(66, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        //System.Threading.Thread.Sleep(10);
                        ////!Alt
                        //RTUIIntegration.WinAPIMethod.keybd_event(18, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        //System.Threading.Thread.Sleep(10);

                        IntPtr InputFileNameParent2 = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Open database");
                        IntPtr InputFileNameParent = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(InputFileNameParent2, IntPtr.Zero, "ComboBoxEx32", null);
                        IntPtr InputFileWnd = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(InputFileNameParent, IntPtr.Zero, "ComboBox", null);
                        IntPtr EditHandle = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(InputFileWnd, IntPtr.Zero, "Edit", null);

                        //string ssssss = "E:\\RTProject\\bin\\FID\\MarsFile\\MarsInputFile.ma2";
                        //RTUIIntegration.RtWndContal.SetForegroundWindow(EditHandle);
                        while (InputFileNameParent2 != IntPtr.Zero)
                        {
                            RTUIIntegration.WinAPIMethod.SendMessage(EditHandle, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, IptFileFullPath);
                            //IntPtr OpenDatabase = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Open database");
                            System.Threading.Thread.Sleep(500);
                            IntPtr OpenButton = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(InputFileNameParent2, IntPtr.Zero, "Button", @"打开(&O)");
                            //System.Threading.Thread.Sleep(100);
                            RTUIIntegration.WinAPIMethod.PostMessage(OpenButton, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            System.Threading.Thread.Sleep(500);
                            InputFileNameParent2 = RTUIIntegration.WinAPIMethod.FindWindow(@"#32770", "Open database");
                        }

                        {
                            IntPtr Cancel_Open = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Open, IntPtr.Zero, "ThunderRT6CommandButton", @"&Cancel");
                            IntPtr OK_Open = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Open, Cancel_Open, "ThunderRT6CommandButton", "&Ok");
                            RTUIIntegration.WinAPIMethod.SendMessage(OK_Open, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                        }
                        //{
                        //    //RTUIIntegration.RtWndContal.SetForegroundWindow(EditHandle);
                        //    //按下Alt
                        //    RTUIIntegration.WinAPIMethod.keybd_event(18, 0, 0, 0);
                        //    System.Threading.Thread.Sleep(10);
                        //    //O
                        //    RTUIIntegration.WinAPIMethod.keybd_event(79, 0, 0, 0);
                        //    System.Threading.Thread.Sleep(10);
                        //    //!O
                        //    RTUIIntegration.WinAPIMethod.keybd_event(79, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        //    System.Threading.Thread.Sleep(100);
                        //    //
                        //    RTUIIntegration.RtWndContal.SetForegroundWindow(Open);
                        //    System.Threading.Thread.Sleep(100);
                        //    //O
                        //    RTUIIntegration.WinAPIMethod.keybd_event(79, 0, 0, 0);
                        //    System.Threading.Thread.Sleep(100);
                        //    //!O
                        //    RTUIIntegration.WinAPIMethod.keybd_event(79, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        //    System.Threading.Thread.Sleep(100);
                        //    //!Alt
                        //    RTUIIntegration.WinAPIMethod.keybd_event(18, 0, RTUIIntegration.APICode.KEYEVENTF_KEYUP, 0);
                        //    System.Threading.Thread.Sleep(100);
                        //}
                        //打开Rule进行规范校核
                        RTUIIntegration.RtWndContal.SetForegroundWindow(MarsHandle);
                        IntPtr ThunderRT6PictureBoxDC = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(MarsHandle, IntPtr.Zero, "ThunderRT6PictureBoxDC", null);
                        IntPtr Box_RuleHandle = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(MarsHandle, ThunderRT6PictureBoxDC, "ThunderRT6PictureBoxDC", null);
                        IntPtr RuleHandle = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Box_RuleHandle, IntPtr.Zero, "ThunderRT6CommandButton", @"&Rule");
                        RTUIIntegration.WinAPIMethod.PostMessage(RuleHandle, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                        IntPtr ComputSection = RTUIIntegration.RtWndContal.WaitAndFindWindow(null, "Compute section");
                        IntPtr ComputForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputSection, IntPtr.Zero, "ThunderRT6Frame", "COMPUTE");
                        IntPtr HullSCANTLING = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6Frame", "HULL SCANTLING");
                        IntPtr HULL_GIRDER_STRENGTH_CRITERIA = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6Frame", "HULL GIRDER STRENGTH CRITERIA");
                        //选择需要校核的参数
                        IntPtr Ultimate_strength_check = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(HULL_GIRDER_STRENGTH_CRITERIA, IntPtr.Zero, "ThunderRT6CheckBox", @"&Ultimate strength check");
                        //System.Threading.Thread.Sleep(500);

                        IntPtr Transverse_ordinary_stiffeners = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(HullSCANTLING, IntPtr.Zero, "ThunderRT6CheckBox", @"&Transverse ordinary stiffeners");
                        IntPtr StructuralDetail = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(HullSCANTLING, IntPtr.Zero, "ThunderRT6CheckBox", @"Structural details  -  &Fatigue");
                        IntPtr MISCELLANEOUS = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6Frame", "MISCELLANEOUS");
                        IntPtr ReplacementThickness = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(MISCELLANEOUS, IntPtr.Zero, "ThunderRT6CheckBox", @"&Replacement thickness");
                        IntPtr Shear_Gross_Scantling = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(MISCELLANEOUS, IntPtr.Zero, "ThunderRT6CheckBox", @"&Shear (gross scantling)");
                        IntPtr Pressure_Viewer = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(MISCELLANEOUS, IntPtr.Zero, "ThunderRT6CheckBox", @"Pressure &Viewer");

                        IntPtr OK_Comput = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6CommandButton", @"&Ok");
                        IntPtr Cancel_Comput = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6CommandButton", "&Cancel");
                        //RTUIIntegration.WinAPIMethod.SendMessage(Cancel_Comput, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                        System.Threading.Thread.Sleep(500);
                        //IntPtr Pic = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(ComputForm, IntPtr.Zero, "ThunderRT6PictureBoxDC", null);
                        if ((OK_Comput != IntPtr.Zero))//&& (Pic!=IntPtr.Zero))
                        {
                            RTUIIntegration.WinAPIMethod.SendMessage(Ultimate_strength_check, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(Transverse_ordinary_stiffeners, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(StructuralDetail, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(ReplacementThickness, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(Shear_Gross_Scantling, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(Pressure_Viewer, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            RTUIIntegration.WinAPIMethod.SendMessage(OK_Comput, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                        }
                        //System.Windows.Forms.Clipboard.SetDataObject("IptFileFullPath");

                        IntPtr Rule_MainForm = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", "Mars Rule 2000 - MarsInputFile.ma2 - Midship section - (n°1)                  OFFSHORE BV RULES - ON SITE - SELECTED");

                        IntPtr cccc = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Rule_MainForm, IntPtr.Zero, "MDIClient", null);
                        IntPtr Form3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(cccc, IntPtr.Zero, "ThunderRT6FormDC", null);
                        IntPtr Form2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form3, IntPtr.Zero, "SSTabCtlWndClass", null);
                        IntPtr ResualtForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form2
                            , IntPtr.Zero, "ThunderRT6PictureBoxDC", null);
                        while (ResualtForm == IntPtr.Zero)
                        {
                            cccc = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Rule_MainForm, IntPtr.Zero, "MDIClient", null);
                            Form3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(cccc, IntPtr.Zero, "ThunderRT6FormDC", null);
                            Form2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form3, IntPtr.Zero, "SSTabCtlWndClass", null);
                            ResualtForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form2
                            , IntPtr.Zero, "ThunderRT6PictureBoxDC", null);
                        }

                        RTUIIntegration.RtWndContal.SetForegroundWindow(Rule_MainForm);
                        //生成计算结果
                        {
                            if (!System.IO.Directory.Exists(OutFolderFullPath))
                                System.IO.Directory.CreateDirectory(OutFolderFullPath);
                            OutFileNameList = new List<string>();
                            //{
                            //    string OutFileName = "FID_MarsInputFile_Midship section_Strake.txt";
                            //    OutFileNameList.Add(OutFileName);
                            //    string OutFileFullPathName = OutFileFullPath + "\\" + OutFileName;
                            //    if(System.IO.Directory.Exists(OutFileFullPathName))
                            //        System.IO.Directory.Delete(OutFileFullPathName);
                            //    //"FID_MarsInputFile_Midship section_Strake.txt"
                            //    RTUIIntegration.RtWndContal.SetForegroundWindow(Rule_MainForm);
                            //    System.Windows.Forms.SendKeys.SendWait("{F2}");
                            //    System.Windows.Forms.SendKeys.SendWait("{E}");
                            //    IntPtr SaveAsForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Save as");
                            //    IntPtr Save = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "Button", "保存(&S)");
                            //    IntPtr Form4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "DUIViewWndClassName", null);
                            //    IntPtr FormCom3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form4, IntPtr.Zero, "DirectUIHWND", null);
                            //    IntPtr FormCom2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom3, IntPtr.Zero, "FloatNotifySink", null);
                            //    IntPtr FormCom1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom2, IntPtr.Zero, "ComboBox", null);
                            //    IntPtr EditForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom1, IntPtr.Zero, "Edit", null);
                            //    RTUIIntegration.WinAPIMethod.SendMessage(EditForm, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, OutFileName);
                            //    //System.Threading.Thread.Sleep(500);
                            //    RTUIIntegration.WinAPIMethod.PostMessage(Save, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                            //    //RTUIIntegration.RtWndContal.SetForegroundWindow(Save);
                            //    //Rule_MainForm = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", "Mars Rule 2000 - MarsInputFile.ma2 - Midship section - (n°1)                  OFFSHORE BV RULES - ON SITE - SELECTED");
                            //    IntPtr RuleSaveForm = RTUIIntegration.RtWndContal.WaitAndFindWindow( @"#32770", "Mars Rule 2000");
                            //    IntPtr Yes = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(RuleSaveForm, IntPtr.Zero, "Button", "确定");
                            //    RTUIIntegration.WinAPIMethod.SendMessage(Yes, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                            //}
                            //保存骨材结果
                            {
                                string OutFileName = "FID_MarsInputFile_Midship section_Longi.txt";
                                OutFileNameList.Add(OutFileName);
                                string OutFileFullPathName = OutFolderFullPath + "\\" + OutFileName;
                                if (System.IO.Directory.Exists(OutFileFullPathName))
                                    System.IO.Directory.Delete(OutFileFullPathName);

                                //RTUIIntegration.RtWndContal.SetForegroundWindow(Rule_MainForm);
                                //bool setFor =
                                //RTUIIntegration.RtWndContal.SetForegroundWindow(ThunderRT6PictureBoxDC);
                                //RTUIIntegration.WinAPIMethod.PostMessage(ThunderRT6PictureBoxDC, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                                //System.Threading.Thread.Sleep(500);
                                System.Windows.Forms.SendKeys.SendWait("{F2}");
                                System.Windows.Forms.SendKeys.SendWait("{L}");
                                IntPtr SaveAsForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Save as");
                                IntPtr Save = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "Button", "保存(&S)");
                                IntPtr Form4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "DUIViewWndClassName", null);
                                IntPtr FormCom3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form4, IntPtr.Zero, "DirectUIHWND", null);
                                IntPtr FormCom2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom3, IntPtr.Zero, "FloatNotifySink", null);
                                IntPtr FormCom1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom2, IntPtr.Zero, "ComboBox", null);
                                IntPtr EditForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom1, IntPtr.Zero, "Edit", null);
                                RTUIIntegration.WinAPIMethod.SendMessage(EditForm, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, OutFileName);


                                RTUIIntegration.WinAPIMethod.PostMessage(Save, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                                //RTUIIntegration.RtWndContal.SetForegroundWindow(Save);
                                //Rule_MainForm = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", "Mars Rule 2000 - MarsInputFile.ma2 - Midship section - (n°1)                  OFFSHORE BV RULES - ON SITE - SELECTED");
                                IntPtr RuleSaveForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Mars Rule 2000");
                                IntPtr Yes = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(RuleSaveForm, IntPtr.Zero, "Button", "确定");
                                RTUIIntegration.WinAPIMethod.SendMessage(Yes, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                            }
                            //保存板材结果
                            {
                                string OutFileName = "FID_MarsInputFile_Midship section_Strake.txt";
                                OutFileNameList.Add(OutFileName);
                                string OutFileFullPathName = OutFolderFullPath + "\\" + OutFileName;
                                if (System.IO.Directory.Exists(OutFileFullPathName))
                                    System.IO.Directory.Delete(OutFileFullPathName);
                                //"FID_MarsInputFile_Midship section_Strake.txt"
                                RTUIIntegration.RtWndContal.SetForegroundWindow(Rule_MainForm);
                                System.Windows.Forms.SendKeys.SendWait("%{T}");
                                System.Windows.Forms.SendKeys.SendWait("{T}");
                                System.Windows.Forms.SendKeys.SendWait("{E}");
                                IntPtr SaveAsForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Save as");
                                IntPtr Save = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "Button", "保存(&S)");
                                IntPtr Form4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "DUIViewWndClassName", null);
                                IntPtr FormCom3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form4, IntPtr.Zero, "DirectUIHWND", null);
                                IntPtr FormCom2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom3, IntPtr.Zero, "FloatNotifySink", null);
                                IntPtr FormCom1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom2, IntPtr.Zero, "ComboBox", null);
                                IntPtr EditForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom1, IntPtr.Zero, "Edit", null);
                                RTUIIntegration.WinAPIMethod.SendMessage(EditForm, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, OutFileName);
                                //System.Threading.Thread.Sleep(500);
                                RTUIIntegration.WinAPIMethod.PostMessage(Save, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                                //RTUIIntegration.RtWndContal.SetForegroundWindow(Save);
                                //Rule_MainForm = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", "Mars Rule 2000 - MarsInputFile.ma2 - Midship section - (n°1)                  OFFSHORE BV RULES - ON SITE - SELECTED");
                                IntPtr RuleSaveForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Mars Rule 2000");
                                IntPtr Yes = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(RuleSaveForm, IntPtr.Zero, "Button", "确定");
                                RTUIIntegration.WinAPIMethod.SendMessage(Yes, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                            }
                            //保存疲劳操作
                            {
                                string OutFileName = "FID_MarsInputFile_Midship section_FatB.txt";
                                OutFileNameList.Add(OutFileName);
                                string OutFileFullPathName = OutFolderFullPath + "\\" + OutFileName;
                                if (System.IO.Directory.Exists(OutFileFullPathName))
                                    System.IO.Directory.Delete(OutFileFullPathName);
                                //"FID_MarsInputFile_Midship section_Strake.txt"
                                System.Windows.Forms.SendKeys.SendWait("%{T}");
                                System.Windows.Forms.SendKeys.SendWait("{T}");
                                System.Windows.Forms.SendKeys.SendWait("{F}");

                                IntPtr OutputFatigue = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6FormDC", "Output of Fatigue intermediate results");
                                IntPtr OK_Fatigue = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(OutputFatigue, IntPtr.Zero, "ThunderRT6CommandButton", @"&OK");

                                RTUIIntegration.WinAPIMethod.SendMessage(OK_Fatigue, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                                IntPtr SaveAsForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Save as");
                                IntPtr Save = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "Button", "保存(&S)");
                                IntPtr Form4 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(SaveAsForm, IntPtr.Zero, "DUIViewWndClassName", null);
                                IntPtr FormCom3 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(Form4, IntPtr.Zero, "DirectUIHWND", null);
                                IntPtr FormCom2 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom3, IntPtr.Zero, "FloatNotifySink", null);
                                IntPtr FormCom1 = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom2, IntPtr.Zero, "ComboBox", null);
                                IntPtr EditForm = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(FormCom1, IntPtr.Zero, "Edit", null);
                                RTUIIntegration.WinAPIMethod.SendMessage(EditForm, RTUIIntegration.APICode.WM_SETTEXT, IntPtr.Zero, OutFileName);
                                //System.Threading.Thread.Sleep(500);
                                RTUIIntegration.WinAPIMethod.PostMessage(Save, RTUIIntegration.APICode.WM_CLICK, 0, 0);
                                //RTUIIntegration.RtWndContal.SetForegroundWindow(Save);
                                //Rule_MainForm = RTUIIntegration.RtWndContal.WaitAndFindWindow("ThunderRT6MDIForm", "Mars Rule 2000 - MarsInputFile.ma2 - Midship section - (n°1)                  OFFSHORE BV RULES - ON SITE - SELECTED");
                                IntPtr RuleSaveForm = RTUIIntegration.RtWndContal.WaitAndFindWindow(@"#32770", "Mars Rule 2000");
                                IntPtr Yes = RTUIIntegration.RtWndContal.WaitAndFindWindowEx(RuleSaveForm, IntPtr.Zero, "Button", "确定");
                                RTUIIntegration.WinAPIMethod.SendMessage(Yes, RTUIIntegration.APICode.WM_CLICK, 0, 0);

                            }

                        }
                        //RTUIIntegration.WinAPIMethod.SendKeydown("{F2}");
                        //RTUIIntegration.WinAPIMethod.keybd_event(
                        RTUIIntegration.WinAPIMethod.SendMessage(Rule_MainForm, RTUIIntegration.APICode.WM_CLOSE, 0, 0);
                        //System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            MarsP.Kill();
            MarsP.WaitForExit();
            return true;
            #endregion
        }
    }
```

### 启动一个外部调用软件

#### 使用shell方式启动

```c#
System.Diagnostics.Process p = new System.Diagnostics.Process();
p.StartInfo.FileName = "cmd.exe";
p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
//p.StartInfo.CreateNoWindow = false;//不显示程序窗口
bool CreatWindowBool = p.StartInfo.CreateNoWindow;

p.Start();//启动程序

//向cmd窗口发送输入信息
string CmdStr = @"C:";
p.StandardInput.WriteLine(CmdStr);
p.StandardInput.AutoFlush = true;

CmdStr = @"C:\BVeritas\Mars2000\Mars2000.exe";
p.StandardInput.WriteLine(CmdStr);
p.StandardInput.AutoFlush = true;

```

#### 直接在进程中启动EXE

```c#
System.Diagnostics.Process P = new System.Diagnostics.Process();
p.StartInfo.FileName = @"C:\BVeritas\Mars2000\Mars2000.exe";
p.Start();
p.WaitForInputIdle();//等待窗口可以响应输入
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

### C#中Unicode转换成ANSI

实现从一个Unicode编码的文件改写成一个ANSI编码的文件。

+ 从Unicode编码文件中读取文件
+ 将文件转换成为ANSI编码方式的byte[]数组
+ 将文件ANSI编码方式的byte数据流写入文件

```c#
char[] uC =new char[]{ 'a','s'};//原Unicode
byte[] buf=System.Text.Encoding.Unicode.GetBytes(uC, 0, uC.Length);
char[] aC=System.Text.Encoding.GetEncoding(1252).GetChars(buf,0,buf.Length);//转换为Ansi
/////////以下为文件读写方式实现
string UnicodeString = System.IO.File.ReadAllText(UnicodeFileDir);
byte[] buf = System.Text.Encoding.Default.GetBytes(UnicodeString);
System.IO.FileStream af = new System.IO.FileStream(AnsiFileDir, System.IO.FileMode.Creat);
af.Write(buf, 0, buf.Length);
af.Flush();
af.Close();
```