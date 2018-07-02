# MESSION LOG  
  
日期          	| 工作内容                                                  	|时长|备注
----------------|---------------------------------------------------------------|---|----------
20180131	| 增加对FPSO内各对象增加的方法，以及修改各FPSO对象容器接口	| 1 |
20180131	| 修改由结构边界组成的对凸多边形各点及各边进行排序的方法。	| 2 |
20180131	| 纵向强框架-底部纵桁                                        	| 5 |
 | | |
20180201	| 增加几个可变载荷（重量）类                               	| 2 |
20180201	| 修复水平强框架Bug                                     	| 1 |
20180201	| 增加船长计算方式L、Loa、Lpp、Lwl    				| 2 |
20180201	| 纵向强框架-底部纵桁外轮廓绘制及测试-有bug              	| 3 |
 | | |
20180202	| 修复水平强框架、横向强框架绘制错误bug                       	| 2 |
20180202	| 修复底部纵桁外轮廓绘制bug                                  	| 2 | 造数据使用的舱壁位置定义有问题，**格子线的坐标位置为三维坐标系下位置**  
20180202	| 修复横向强框架右侧上部骨材绘制不出来的bug                 	| 3 |  
20180202	| 增加纵桁面板类                                           	| 1 |  
 | | | 
20180205	| 完善桁材面板类的方法，能够转换生成成stiffener类          	| 3 | 
20180205	| 与唐总讨论项目目前状态及风险点                             	| 1 | CCS进度较慢，可能无法按时完成，外高桥疑似无合作意向。估价方法可能要自己实现
20180205	| 测试完善后的纵桁类，边界计算又出现问题bug，并进行修复       	| 1 | 问题出现在FreeEdge中的AddWebStructure()方法中，增加SetWebEdgeStructure()方法
20180205	| 分析总纵强度计算书，及相关资料查阅                        	| 2 | 在参考计算书中拖航工况中的最大吃水与最小吃水值是从哪里得到的  
 | | |  
20180206	| 研究总纵强度计算书中静水载荷部分内容                      	| 1 | 1、静水剪力在Fr56位置大于包络线设计值。2、Draft具体指那个形态的Draft。
20180206	| 部门例会                                                    	| 1 | 
20180206	| 年会排练                                                 	| 1 | 
20180206	| 设计曲面骨材数据结构，实现曲面骨材类,ShellLongitudinal类	| 2 |   
20180206	| 年会排练							| 2 |
20180206	| 曲面骨材类的问题，并尝试修改					| 1 | 
 | | |  
20180207	| 讨论求船壳上一点法向方向的实现方法                      	| 1 | 可以将船壳分解为离散的单元面然后求其法向方向
20180207	| 准备年会相关事宜                                           	| 2 | 
20180207	| 构建求外板纵骨的方法，修改原stiffener类，使其支持三维曲面	| 3 | 
20180207	| 年会准备                                                    	| 2 | 
 | | |  	
20180208	| 测试CShipLine中的GetSideLine()方法，发现距离太大会出现bug	| 3 | 当使用甲板边线作为参考线时，距离大于8时就无法得出所求的线  
20180208	| 年会相关准备                                               	| 2 | 年会流程熟悉   
 | | |  
20180209	| 年会彩排，准备等                                              | 8 | 修改主持稿，熟悉最新流程
 | | | 
20180223	| 看待处理事项，处理春节假期期间需填写表格及工作会议等		| 1 | 
20180223	| 修复TransPanel类中的一部分骨材起点终点一致的bug		| 2 | TransPanel类中GetEdge()方法中没有形成闭合区域
20180223	| 修改LongiBeamPanel类中的趾端定义方法				| 2 | BasiceData中增加描述趾端结构的 StructToe类
20180223	| 研究船舶报价方法						| 2 | 初步了解船舶报价方法
 | | | 
20180224	| 修改纵向框架绘制过程中Bug					| 2 | 	
20180224	| 为实现板材的板缝协调数据结构寻找合适的设计模式		| 4 | 
20180224	| 修复垂向强框架中无法根据修改移动的bug				| 2 | 
 | | | 
20180226	| 设计外板纵骨被截断的情况   					| 1 | 
20180226	| 部门项目例会及会后讨论，需要完成外板业务，板材分区，骨材分区	| 2 | 水动力长期分析技术路线尚未清晰，短期预报->长期分析具体计算方法需要研究
20180226	| 修改强框架定义手段，实现强框架的控制类			| 5 |
 | | | 
20180227	| 项目会议，对项目状态进行讨论，并做出相应调整			| 3 | 
20180227	| 内部讨论，确定修改内容及负责人				| 1 | 
20180227	| 分舱读取bug，确定问题，对FPSO分舱数据保存位置进行修改	  	| 2 |
 | | | 
20180814	|

Z
-----------------------------------
## 尚未解决的问题
+ 板材分区
+ 骨材端部肘板
+ 骨材间断 
+ 开孔 
+ 