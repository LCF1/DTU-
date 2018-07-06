using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections;
namespace DTU模块测试软件
{
   

    namespace InFile
    {
        /// <summary>
        /// 文件读写操作类
        /// </summary>
        class IniFile
        {
            /// <summary>
            /// 存储文件名,包含路径
            /// </summary>
            string IniFileName;//存储文件名,包含路径
            /// <summary>
                               /// 文件读写时移除的字符,空格和换行
                               /// </summary>
            char[] TrimChar = { ' ', '\t' };
            /// <summary>
            /// 构造函数0,固定文件路径
            /// </summary>
            public IniFile()
            {

            }
            /// <summary>
            /// 文件读写操作类构造函数1,传入文件路径参数
            /// </summary>
            /// <param name="IniF">指定读写文件路径</param>
            public IniFile(string IniF)
            {
                IniFileName = IniF;
            }
            /// <summary>
            /// 返回文件中所有"[]"(中括号)括起来的元素
            /// </summary>
            /// <returns></returns>
            public string[] GetSects()//
            {
                string[] Sects = null;

                if (File.Exists(IniFileName))//判断文件是否存在
                {
                    string str;
                    ArrayList ls = new ArrayList();//动态数组,
                    TextReader tr = File.OpenText(IniFileName);//读取整个文件内容
                    while ((str = tr.ReadLine()) != null)//
                    {
                        str = str.Trim();//去掉字符串前后空格
                        if ((str.StartsWith("[")) && (str.EndsWith("]")))
                            ls.Add(str);
                    }
                    tr.Close();
                    if (ls.Count > 0)
                    {
                        Sects = new string[ls.Count];
                        for (int i = 0; i < ls.Count; i++)
                        {
                            Sects[i] = ls[i].ToString();
                        }
                    }
                }
                return Sects;
            }
            /// <summary>
            /// 写入字符串
            /// </summary>
            /// <param name="sect">区域标记</param>
            /// <param name="keystr">关键字标记</param>
            /// <param name="valuestr">待写入的string</param>
            /// <returns></returns>
            public int WriteString(string sect, string keystr, string valuestr)
            {
                ArrayList ls = new ArrayList();
                bool SectOK = false;
                bool SetOK = false;
                if (File.Exists(IniFileName))
                {
                    int pos1;
                    string substr;
                    string str;
                    TextReader tr = File.OpenText(IniFileName);
                    while ((str = tr.ReadLine()) != null)
                    {
                        ls.Add(str);
                    }
                    tr.Close();
                    //开始寻找关键字，如果找不到，则在这段的最后一行插入，然后再整体的保存一下INI文件。
                    for (int i = 0; i < ls.Count; i++)
                    {
                        str = ls[i].ToString();
                        if (str.StartsWith("[") && SectOK) //先判断是否到下一段中了,如果本来就是最后一段，那就有可能永远也不会发生了。
                        {
                            SetOK = true;
                            //如果在这一段中没有找到，并且已经要进入下一段了，就直接在这一段末添加了。
                            ls.Insert(i, keystr.Trim() + "=" + valuestr);
                            break;//如果到下一段了，则直接退出就好。
                        }
                        if (SectOK)
                        {
                            pos1 = str.IndexOf("=");
                            if (pos1 > 1)
                            {
                                substr = str.Substring(0, pos1);
                                substr.Trim(TrimChar);
                                //如果在这一段中找到KEY了，直接修改就好了。
                                if (substr.Equals(keystr, StringComparison.OrdinalIgnoreCase) && SectOK) //是在此段中，并且KEYSTR前段也能匹配上。
                                {
                                    SetOK = true;
                                    ls[i] = keystr.Trim() + "=" + valuestr;
                                    break;
                                }
                            }
                        }
                        if (str.StartsWith("[" + sect + "]")) //判断是否到需要的段中了。
                            SectOK = true;
                    }
                    if (SetOK == false)
                    {
                        SetOK = true;
                        if (!SectOK) //如果没有找到段，则需要再添加段。
                        {
                            ls.Add("[" + sect + "]");
                        }
                        ls.Add(keystr.Trim() + "=" + valuestr);
                    }
                } //如果文件不存在，则需要建立文件。
                else
                {
                    ls.Clear();
                    ls.Add("##CreatTime:" + DateTime.Now.ToString() + "##");
                    ls.Add("[" + sect + "]");
                    ls.Add(keystr.Trim() + "=" + valuestr);
                }
                if (File.Exists(IniFileName)) //删除源文件。
                {
                    File.Delete(IniFileName);
                }
                TextWriter tw = File.CreateText(IniFileName);
                //string[] strList = new string[ls.Count];
                for (int i = 0; i < ls.Count; i++)
                {
                    //strList[i] = ls[i].ToString();
                    tw.WriteLine(ls[i].ToString());
                }
                tw.Flush();
                tw.Close();
                //File.WriteAllLines(IniFileName, strList);
                return 0;
            }
            /// <summary>
            /// 读取字符串,如果查找不到返回默认值
            /// </summary>
            /// <param name="sect">区域标记</param>
            /// <param name="keystr">关键字标记</param>
            /// <param name="defaultstr">默认值</param>
            /// <returns></returns>
            public string ReadString(string sect, string keystr, string defaultstr)
            {
                string retstr = defaultstr;
                if (File.Exists(IniFileName))
                {
                    bool SectOK = false;
                    int pos1;
                    string substr;
                    string str;
                    ArrayList ls = new ArrayList();
                    TextReader tr = File.OpenText(IniFileName);
                    while ((str = tr.ReadLine()) != null)
                    {
                        str = str.Trim();
                        if (str.StartsWith("[") && SectOK) //先判断是否到下一段中了。
                        {
                            break;//如果到下一段了，则直接退出就好。
                        }
                        if (SectOK)
                        {
                            pos1 = str.IndexOf("=");
                            if (pos1 >= 1)   //宝强修改
                            {
                                substr = str.Substring(0, pos1);
                                substr.Trim(TrimChar);
                                if (substr.Equals(keystr, StringComparison.OrdinalIgnoreCase)) //是在此段中，并且KEYSTR前段也能匹配上。
                                {
                                    retstr = str.Substring(pos1 + 1).Trim(TrimChar);
                                    break;
                                }
                            }
                        }
                        if (str.StartsWith("[" + sect + "]")) //判断是否到需要的段中了。
                            SectOK = true;
                    }
                    tr.Close();
                }
                return retstr;
            }
            /// <summary>
            /// 读取整数数据,如果查找不到返回默认值
            /// </summary>
            /// <param name="Section">区域标记</param>
            /// <param name="Ident">关键字标记</param>
            /// <param name="Default">默认值</param>
            /// <returns></returns>
            public int ReadInteger(string Section, string Ident, int Default)
            {
                string intStr = ReadString(Section, Ident, Convert.ToString(Default));
                try
                {
                    return Convert.ToInt32(intStr);
                }
                catch
                {
                    return Default;
                }
            }
            /// <summary>
            /// 写入整数数据
            /// </summary>
            /// <param name="Section">区域标记</param>
            /// <param name="Ident">关键字标记</param>
            /// <param name="Value">待写入的int数据</param>
            public void WriteInteger(string Section, string Ident, int Value)
            {
                WriteString(Section, Ident, Value.ToString());
            }
            /// <summary>
            /// 读取布尔类型数据,如果查找不到返回默认值
            /// </summary>
            /// <param name="Section">区域标记</param>
            /// <param name="Ident">关键字标记</param>
            /// <param name="Default">默认值</param>
            /// <returns></returns>
            public bool ReadBool(string Section, string Ident, bool Default)
            {
                try
                {
                    return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
                }
                catch
                {
                    return Default;
                }
            }
            /// <summary>
            /// 写入布尔类型数据
            /// </summary>
            /// <param name="Section">区域标记</param>
            /// <param name="Ident">关键字标记</param>
            /// <param name="Value">待写入的bool数据</param>
            public void WriteBool(string Section, string Ident, bool Value)
            {
                WriteString(Section, Ident, Convert.ToString(Value));
            }
            /// <summary>
            /// 指定文件,指定行位置添加一行数据,用于log记录
            /// </summary>
            /// <param name="line">待写入的数据</param>
            public void Writeline(string line)//
            {
                ArrayList ls = new ArrayList();
                //ls.Add(line);//写在这里向文首添加数据
                string str;
                if (File.Exists(IniFileName))
                {
                    TextReader tr = File.OpenText(IniFileName);
                    for (int i = 0; i < 3; i++)//前三行固定格式
                    {
                        if((str = tr.ReadLine()) != null)
                        { ls.Add(str); }
                        else { ls.Add("**********");}
                    }
                    ls.Add(line);//从指定行开始添加数据
                    while ((str = tr.ReadLine()) != null)
                    { ls.Add(str); }
                    tr.Close();
                    //ls.Add(line);//写在这里向文尾添加数据
                }
                else
                {
                    ls.Clear();
                    ls.Add("##" + DateTime.Now.ToString() + "##");
                    ls.Add(line);
                }
                if (File.Exists(IniFileName)) //删除源文件。
                {
                    File.Delete(IniFileName);
                }
                TextWriter tw = File.CreateText(IniFileName);
                for (int i = 0; i < ls.Count; i++)
                { tw.WriteLine(ls[i].ToString()); }
                tw.Flush();
                tw.Close();
            }
            /// <summary>
            /// 将数据写入指定工程文件
            /// </summary>
            /// <param name="i">工程编号</param>
            public void SaveProject(int i)//保存工程文件
            {
                //Project.PdataInt(0);
                //#region[写入工程基本信息]
                //WriteString("info", "name", Project.project[i].info.name);
                //WriteString("info", "path", Project.project[i].info.path);
                //WriteString("info", "logName", Project.project[i].info.logName);
                //WriteString("info", "logPath", Project.project[i].info.logPath);
                //WriteString("info", "ctime", Project.project[i].info.ctime);
                //WriteString("info", "atime", Project.project[i].info.atime);
                //WriteString("info", "stime", Project.project[i].info.stime);
                //WriteString("info", "owner", Project.project[i].info.name);
                //WriteString("info", "machineID", Project.project[i].info.machineID);
                //WriteString("info", "MKBID", Project.project[i].info.MKBID);
                //WriteInteger("info", "DBsum", Project.project[i].info.DBsum);
                //WriteInteger("info", "Sensum", Project.project[i].info.Sensum);
                //WriteInteger("info", "IOsum", Project.project[i].info.IOsum);
                //#endregion[写入工程基本信息]
                //#region[写入感应器信息]            
                //int x;
                //x = Project.project[i].info.Sensum;//感应器数量
                //for (int a = 0; a < x; a++)
                //{
                //    WriteString("SenIF", "SenName" + a.ToString(), Project.project[i].SenIF[a].SenName);
                //    WriteInteger("SenIF", "SenNum" + a.ToString(), Project.project[i].SenIF[a].SenNum);
                //}
                //#endregion[写入感应器信息]
                //#region[写入IO口信息]            
                ////int d;
                //x = Project.project[i].info.IOsum;//IO口数量
                //for (int a = 0; a < x; a++)
                //{
                //    WriteString("IOIF", "IOName" + a.ToString(), Project.project[i].IOIF[a].IOName);
                //    WriteInteger("IOIF", "IONum" + a.ToString(), Project.project[i].IOIF[a].IONum);
                //}
                //#endregion[写入IO口信息]
                //#region[写入运动轴信息]               
                //x = Project.project[i].info.DBsum;//运动轴数量
                //for (int a = 0; a < x; a++)
                //{
                //    WriteString("AxleIF" + a.ToString(), "AxleName", Project.project[i].AxleIF[a].AxleName);
                //    WriteInteger("AxleIF" + a.ToString(), "AxleNum", Project.project[i].AxleIF[a].AxleNum);
                //    WriteInteger("AxleIF" + a.ToString(), "HomeSpeed", Project.project[i].AxleIF[a].HomeSpeed);
                //    WriteInteger("AxleIF" + a.ToString(), "HomeSpeed1", Project.project[i].AxleIF[a].HomeSpeed1);
                //    WriteInteger("AxleIF" + a.ToString(), "SpeedH", Project.project[i].AxleIF[a].SpeedH);
                //    WriteInteger("AxleIF" + a.ToString(), "SpeedH1", Project.project[i].AxleIF[a].SpeedH1);
                //    WriteInteger("AxleIF" + a.ToString(), "SpeedL", Project.project[i].AxleIF[a].SpeedL);
                //    WriteInteger("AxleIF" + a.ToString(), "SpeedL1", Project.project[i].AxleIF[a].SpeedL1);
                //    WriteInteger("AxleIF" + a.ToString(), "length", Project.project[i].AxleIF[a].length);
                //    WriteInteger("AxleIF" + a.ToString(), "length1", Project.project[i].AxleIF[a].length1);

                //    WriteInteger("AxleIF" + a.ToString(), "SenNum0", Project.project[i].AxleIF[a].SenNum[0]);
                //    WriteInteger("AxleIF" + a.ToString(), "SenNum1", Project.project[i].AxleIF[a].SenNum[1]);
                //    WriteInteger("AxleIF" + a.ToString(), "SenNum2", Project.project[i].AxleIF[a].SenNum[2]);
                //    WriteInteger("AxleIF" + a.ToString(), "SenNum3", Project.project[i].AxleIF[a].SenNum[3]);
                //    WriteInteger("AxleIF" + a.ToString(), "SenNum4", Project.project[i].AxleIF[a].SenNum[4]);
                //    WriteInteger("AxleIF" + a.ToString(), "PosSum", Project.project[i].AxleIF[a].PosSum);
                //    //WriteInteger("AxleIF" + a.ToString(), "HomeSpeed", Project.project[i].AxleIF[a].HomeSpeed);
                //    //WriteInteger("AxleIF" + a.ToString(), "HomeSpeed", Project.project[i].AxleIF[a].HomeSpeed);
                //    int y = Project.project[i].AxleIF[a].PosSum;
                //    for (int b = 0; b < y; b++)
                //    {
                //        WriteString("AxleIF" + a.ToString(), "name" + b.ToString(), Project.project[i].AxleIF[a].AxlePos[b].name);
                //        WriteInteger("AxleIF" + a.ToString(), "Pos" + b.ToString(), Project.project[i].AxleIF[a].AxlePos[b].Pos);
                //        WriteInteger("AxleIF" + a.ToString(), "num" + b.ToString(), Project.project[i].AxleIF[a].AxlePos[b].num);
                //    }
                //}
                //#endregion[加载运动轴信息]
                //#region[写入设备设置信息]
                //WriteInteger("Mset", "DrawCleanT", Project.project[i].Mset.DrawCleanT);
                //WriteInteger("Mset", "StirCleanT", Project.project[i].Mset.StirCleanT);
                //WriteInteger("Mset", "Timer1", Project.project[i].Mset.Timer1);
                //WriteInteger("Mset", "Timer2", Project.project[i].Mset.Timer2);
                //WriteInteger("Mset", "Timer3", Project.project[i].Mset.Timer3);
                //WriteInteger("Mset", "Timer4", Project.project[i].Mset.Timer4);
                //WriteInteger("Mset", "Timer5", Project.project[i].Mset.Timer5);
                //WriteInteger("Mset", "Glassdraw", Project.project[i].Mset.Glassdraw);
                //WriteInteger("Mset", "GlassdrawPre", Project.project[i].Mset.GlassdrawPre);
                //WriteInteger("Mset", "Carddraw", Project.project[i].Mset.Carddraw);
                //WriteInteger("Mset", "CarddrawPre", Project.project[i].Mset.CarddrawPre);
                //WriteInteger("Mset", "pNum", Project.project[i].Mset.pNum);
                //WriteInteger("Mset", "incTime", Project.project[i].Mset.incTime);
                //for (int b = 0; b < 10; b++)
                //{//暂时屏蔽RunSet设置
                //    WriteInteger("Mset", "RunSet" + b.ToString(), Project.project[i].Mset.RunSet[b]);
                //}
                //#endregion[写入设备设置信息]
            }
            /// <summary>
            /// 新建工程用,读取默认工程模板,写新建的工程中
            /// </summary>
            /// <param name="path">新建工程存储路径</param>
            public void newProject(string path)
            {
                //ArrayList ls = new ArrayList();
                //string str;
                //if (File.Exists(IniFileName))//读取默认工程参数文件
                //{
                //    TextReader tr = File.OpenText(IniFileName);
                //    while ((str = tr.ReadLine()) != null)
                //    { ls.Add(str); }
                //    tr.Close();
                //    //ls.Add(line);
                //}
                //else
                //{
                //    //ls.Clear();
                //    //ls.Add("##" + DateTime.Now.ToString() + "##");
                //    //ls.Add(line);
                //    MessageBox.Show("工程模板丢失,请重新添加工程模板", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //if (File.Exists(path)) //删除源文件。
                //{
                //    File.Delete(path);
                //}
                //TextWriter tw = File.CreateText(path);
                //for (int i = 0; i < ls.Count; i++)
                //{ tw.WriteLine(ls[i].ToString()); }
                //tw.Flush();
                //tw.Close();
            }

            public void SaveAs(string path1, string path)
            {
                //ArrayList ls = new ArrayList();
                //string str;
                //if (File.Exists(path1))//读取原工程文件
                //{
                //    TextReader tr = File.OpenText(path1);
                //    while ((str = tr.ReadLine()) != null)
                //    { ls.Add(str); }
                //    tr.Close();
                //    //ls.Add(line);
                //}
                //else
                //{
                //    //ls.Clear();
                //    //ls.Add("##" + DateTime.Now.ToString() + "##");
                //    //ls.Add(line);
                //    // MessageBox.Show("当前工程文件丢失,请重新加载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //if (File.Exists(path))
                //{
                //    MessageBox.Show("当前路径存在同名文件,请更改后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //TextWriter tw = File.CreateText(path);
                //for (int i = 0; i < ls.Count; i++)
                //{ tw.WriteLine(ls[i].ToString()); }
                //tw.Flush();
                //tw.Close();
                //if (File.Exists(path1)) //删除源文件。
                //{
                //    File.Delete(path1);
                //}
            }

            /////////////////////////////////////////////////////////////////////////
            //使用此INI文件的特例（自己使用）
            public string GetParam(string KeyStr, string Default)
            {
                string str;
                str = this.ReadString("Params", KeyStr, "???");
                if (str == "???")
                {
                    this.WriteString("Params", KeyStr, Default);
                    str = Default;
                }
                return str;
            }
            public void UpdateParam(string KeyStr, string ValueStr)
            {
                this.WriteString("Params", KeyStr, ValueStr);
            }

        }
    }

}
