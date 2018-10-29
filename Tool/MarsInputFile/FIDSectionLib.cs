using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RTMaterialSectionLib;
using FIDLibData;


namespace FIDOceaneeringDB
{
    public class FIDSectionLib
    {
        public enum StiffSectionType
        {
            BulbFlatBar,
            AngleBar,
            T_Bar,
            H_Bar,
            C_Bar,
            I_Bar,
            FlatBar,
            NotFound
        }

     


        public static StiffSectionType ConfirmProfile(RTMaterialSectionLib.RTAnySection Station)
        {
            if ((Station is RTMaterialSectionLib.RTSecitonFlatbulbBarSection) == true)
                return StiffSectionType.BulbFlatBar;
            else if ((Station is RTMaterialSectionLib.RTSecitonAngleBarSection) == true)
                return StiffSectionType.AngleBar;
            else if ((Station is RTMaterialSectionLib.RTSecitonFlatBARSection) == true)
                return StiffSectionType.FlatBar;
            else if ((Station is RTMaterialSectionLib.RTSecitonTBARSection) == true)
                return StiffSectionType.T_Bar;
            else if ((Station is RTMaterialSectionLib.RTSecitonHBARSection) == true)
                return StiffSectionType.H_Bar;
            else if ((Station is RTMaterialSectionLib.RTSecitonCBARSection) == true)
                return StiffSectionType.C_Bar;
            else if ((Station is RTMaterialSectionLib.RTSecitonIBARSection) == true)
                return StiffSectionType.I_Bar;
            else
                return StiffSectionType.NotFound;
        }

        /// <summary>单例对象</summary>
        private static FIDSectionLib SectionLib;

        /// <summary>私有化构造</summary>
        private FIDSectionLib() { }

        /// <summary>获取FIDSectionLib单例对象</summary>
        /// <returns></returns>
        public static FIDSectionLib GetSectionLib()
        {
            if (SectionLib == null)
            {
                SectionLib = new FIDSectionLib();
                if (SectionLib.IntrialFromDB())
                    return SectionLib;
                else
                    return null;
            }
            else
            {
                return SectionLib;
            }
        }

        RTMaterialSectionLib.AllSectionType m_Sections = new RTMaterialSectionLib.AllSectionType();
        public RTMaterialSectionLib.AllSectionType Sections
        {
            get { return m_Sections; }
        }

        /// <summary>更新对象</summary>
        /// <param name="Obj">修改过的对象</param>
        /// <returns>更新成功与否</returns>
        public bool Update(object Obj)
        {
            if (FIDLibDataHelp.GetFIDLibDataHelpObj() != null)
                return FIDLibDataHelp.GetFIDLibDataHelpObj().UpdateData(Obj);
            return false;
        }

        /// <summary>获取所有截面</summary>
        /// <returns></returns>
        public List<RTAnySection> GetAllSection()
        {
            List<RTAnySection> SectList = new List<RTAnySection>();
            m_Sections.AngleBarSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.CBARSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.FlatbulbBarSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.HBARSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.IBARSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.ShellList.ForEach((Sect) => { SectList.Add(Sect); });
            m_Sections.TBARSectionList.ForEach((Sect) => { SectList.Add(Sect); });
            return SectList;
        }

        /// <summary>通过截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTAnySection GetSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.ShellList.Count == 0)
                IntrialFromDB();
            RTAnySection Sect = null;
            Sect = m_Sections.AngleBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.CBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.FlatbulbBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.HBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.IBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.ShellList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            if (Sect == null)
                Sect = m_Sections.TBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过AngleBar截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonAngleBarSection GetAngleBarSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.AngleBarSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonAngleBarSection Sect = null;
            Sect = m_Sections.AngleBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过CBAR截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonCBARSection GetCBARSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.CBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonCBARSection Sect = null;
            Sect = m_Sections.CBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过FlatbulbBar截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonFlatbulbBarSection GetFlatbulbBarSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.FlatbulbBarSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonFlatbulbBarSection Sect = null;
            Sect = m_Sections.FlatbulbBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过HBAR截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonHBARSection GetHBARSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.HBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonHBARSection Sect = null;
            Sect = m_Sections.HBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过IBAR截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonIBARSection GetIBARSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.IBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonIBARSection Sect = null;
            Sect = m_Sections.IBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过Shell截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonShell GetShellSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.ShellList.Count == 0)
                IntrialFromDB();
            RTSecitonShell Sect = null;
            Sect = m_Sections.ShellList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>通过TBAR截面名字获得截面对象</summary>
        /// <param name="Name">名字</param>
        /// <returns>截面对象</returns>
        public RTSecitonTBARSection GetTBARSection(string Name)
        {
            // 保证仅读取数据库一次
            if (m_Sections.TBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonTBARSection Sect = null;
            Sect = m_Sections.TBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>读取数据库更新数据列表</summary>
        /// <returns></returns>
        public bool IntrialFromDB()
        {
            m_Sections.AngleBarSectionList.Clear();
            m_Sections.FlatBarSectionList.Clear();
            m_Sections.CBARSectionList.Clear();
            m_Sections.FlatbulbBarSectionList.Clear();
            m_Sections.HBARSectionList.Clear();
            m_Sections.IBARSectionList.Clear();
            m_Sections.ShellList.Clear();
            m_Sections.TBARSectionList.Clear();
            System.Reflection.Assembly Assem = System.Reflection.Assembly.GetExecutingAssembly();
            string FIDPath = System.IO.Path.GetDirectoryName(Assem.Location);
            // 获得TShell对象的列表
            List<RTSecitonShell> TShellObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TShell.xml").
                Cast<RTSecitonShell>().ToList();
            // 为目标列表赋值
            m_Sections.ShellList.AddRange(TShellObjList);

            // 获得TAngleBarSection对象的列表
            List<RTSecitonAngleBarSection> TAngleBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TAngleBarSection.xml").
                Cast<RTSecitonAngleBarSection>().ToList();
            // 为目标列表赋值
            m_Sections.AngleBarSectionList.AddRange(TAngleBarSectionObjList);
            List<RTSecitonFlatBARSection> TFlatBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().GetListFromMapping(FIDPath + @"\Mapping\Mapping_TFlatBarSection.xml").Cast<RTSecitonFlatBARSection>().ToList();
            // 为目标列表赋值
            m_Sections.FlatBarSectionList.AddRange(TFlatBarSectionObjList);
            // 获得TFlatbulbBarSection对象的列表
            List<RTSecitonFlatbulbBarSection> TFlatbulbBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TFlatbulbBarSection.xml").
                Cast<RTSecitonFlatbulbBarSection>().ToList();
            // 为目标列表赋值
            m_Sections.FlatbulbBarSectionList.AddRange(TFlatbulbBarSectionObjList);

            // 获得THBARSection对象的列表
            List<RTSecitonHBARSection> THBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_THBARSection.xml").
                Cast<RTSecitonHBARSection>().ToList();
            // 为目标列表赋值
            m_Sections.HBARSectionList.AddRange(THBARSectionObjList);

            // 获得TCBARSection对象的列表
            List<RTSecitonCBARSection> TCBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TCBARSection.xml").
                Cast<RTSecitonCBARSection>().ToList();
            // 为目标列表赋值
            m_Sections.CBARSectionList.AddRange(TCBARSectionObjList);

            // 获得TIBARSection对象的列表
            List<RTSecitonIBARSection> TIBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TIBARSection.xml").
                Cast<RTSecitonIBARSection>().ToList();
            // 为目标列表赋值
            m_Sections.IBARSectionList.AddRange(TIBARSectionObjList);

            // 获得TTBARSection对象的列表
            List<RTSecitonTBARSection> TTBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TTBARSection.xml").
                Cast<RTSecitonTBARSection>().ToList();
            // 为目标列表赋值
            m_Sections.TBARSectionList.AddRange(TTBARSectionObjList);
            
            return true;
        }
    }
}
