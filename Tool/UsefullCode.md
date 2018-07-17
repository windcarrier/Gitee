# Usefull Code

## FID用到的

### 调用软件进行计算

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