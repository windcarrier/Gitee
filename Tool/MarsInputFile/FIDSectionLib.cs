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

        /// <summary>��������</summary>
        private static FIDSectionLib SectionLib;

        /// <summary>˽�л�����</summary>
        private FIDSectionLib() { }

        /// <summary>��ȡFIDSectionLib��������</summary>
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

        /// <summary>���¶���</summary>
        /// <param name="Obj">�޸Ĺ��Ķ���</param>
        /// <returns>���³ɹ����</returns>
        public bool Update(object Obj)
        {
            if (FIDLibDataHelp.GetFIDLibDataHelpObj() != null)
                return FIDLibDataHelp.GetFIDLibDataHelpObj().UpdateData(Obj);
            return false;
        }

        /// <summary>��ȡ���н���</summary>
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

        /// <summary>ͨ���������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTAnySection GetSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
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

        /// <summary>ͨ��AngleBar�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonAngleBarSection GetAngleBarSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.AngleBarSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonAngleBarSection Sect = null;
            Sect = m_Sections.AngleBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��CBAR�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonCBARSection GetCBARSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.CBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonCBARSection Sect = null;
            Sect = m_Sections.CBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��FlatbulbBar�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonFlatbulbBarSection GetFlatbulbBarSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.FlatbulbBarSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonFlatbulbBarSection Sect = null;
            Sect = m_Sections.FlatbulbBarSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��HBAR�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonHBARSection GetHBARSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.HBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonHBARSection Sect = null;
            Sect = m_Sections.HBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��IBAR�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonIBARSection GetIBARSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.IBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonIBARSection Sect = null;
            Sect = m_Sections.IBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��Shell�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonShell GetShellSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.ShellList.Count == 0)
                IntrialFromDB();
            RTSecitonShell Sect = null;
            Sect = m_Sections.ShellList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>ͨ��TBAR�������ֻ�ý������</summary>
        /// <param name="Name">����</param>
        /// <returns>�������</returns>
        public RTSecitonTBARSection GetTBARSection(string Name)
        {
            // ��֤����ȡ���ݿ�һ��
            if (m_Sections.TBARSectionList.Count == 0)
                IntrialFromDB();
            RTSecitonTBARSection Sect = null;
            Sect = m_Sections.TBARSectionList.Where(p => p.Name.Equals(Name)).FirstOrDefault();
            return Sect;
        }

        /// <summary>��ȡ���ݿ���������б�</summary>
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
            // ���TShell������б�
            List<RTSecitonShell> TShellObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TShell.xml").
                Cast<RTSecitonShell>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.ShellList.AddRange(TShellObjList);

            // ���TAngleBarSection������б�
            List<RTSecitonAngleBarSection> TAngleBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TAngleBarSection.xml").
                Cast<RTSecitonAngleBarSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.AngleBarSectionList.AddRange(TAngleBarSectionObjList);
            List<RTSecitonFlatBARSection> TFlatBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().GetListFromMapping(FIDPath + @"\Mapping\Mapping_TFlatBarSection.xml").Cast<RTSecitonFlatBARSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.FlatBarSectionList.AddRange(TFlatBarSectionObjList);
            // ���TFlatbulbBarSection������б�
            List<RTSecitonFlatbulbBarSection> TFlatbulbBarSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TFlatbulbBarSection.xml").
                Cast<RTSecitonFlatbulbBarSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.FlatbulbBarSectionList.AddRange(TFlatbulbBarSectionObjList);

            // ���THBARSection������б�
            List<RTSecitonHBARSection> THBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_THBARSection.xml").
                Cast<RTSecitonHBARSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.HBARSectionList.AddRange(THBARSectionObjList);

            // ���TCBARSection������б�
            List<RTSecitonCBARSection> TCBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TCBARSection.xml").
                Cast<RTSecitonCBARSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.CBARSectionList.AddRange(TCBARSectionObjList);

            // ���TIBARSection������б�
            List<RTSecitonIBARSection> TIBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TIBARSection.xml").
                Cast<RTSecitonIBARSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.IBARSectionList.AddRange(TIBARSectionObjList);

            // ���TTBARSection������б�
            List<RTSecitonTBARSection> TTBARSectionObjList = FIDLibDataHelp.GetFIDLibDataHelpObj().
                GetListFromMapping(FIDPath + @"\Mapping\Mapping_TTBARSection.xml").
                Cast<RTSecitonTBARSection>().ToList();
            // ΪĿ���б�ֵ
            m_Sections.TBARSectionList.AddRange(TTBARSectionObjList);
            
            return true;
        }
    }
}
