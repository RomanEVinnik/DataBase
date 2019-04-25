using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADODB;

namespace WindowsFormsDataBase
{
    public partial class Form1 : Form
    {
        object parms = null;
        object recs = null;
        public ADODB.Connection m_connDB = new ADODB.Connection();
        public ADODB.Recordset rs = new ADODB.Recordset();
        public ADODB.Command cmdDB = new ADODB.Command();
        public string cnStr;
        public string query;
        public string sErrorString;

        public enum enumDBStatus
        {
            OK,
            EmptyRecordset,
            FatalError,
        }
        public struct tStoreProc
        {
            public string Name { get; set; }
            public ADODB.DataTypeEnum Type { get; set; }
            public ADODB.ParameterDirectionEnum Directional { get; set; }
            public int Size { get; set; }
            public string Value { get; set; }

        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {

            //Label label1 = new Label();
            var breturn = OpenDB();

            if (breturn == enumDBStatus.OK)
            {
                label1.Text = "Data Base Connected";
            }
            else
            {
                label1.Text = "Data Base Not Connected";
            }


        }

        public enumDBStatus OpenDB()
        {
            //Connection string.
            cnStr = "Provider=SQLOLEDB;Initial Catalog=ATEP;Data Source=ACGB1AP23;User ID=StationATE;Password=maate";//ACGB1AP23

            //Connection via ConnectionString Property.
            m_connDB.ConnectionString = cnStr;
            try
            {
                // Do not initialize this variable here.
                if (m_connDB.State == 0)
                {
                    m_connDB.Open(null, null, null, 0);
                    m_connDB.Close();
                    return enumDBStatus.OK;
                }
                else
                {
                    return enumDBStatus.FatalError;
                }
            }
            catch (Exception message)
            {
                MessageBox.Show("Unable to open database.\r\n" + message, "(DB) Error");
                return enumDBStatus.FatalError;
            }
        }

        public enumDBStatus ExecuteSQL(string sQuery)
        {
            try
            {
                if (m_connDB.State == 0)
                {
                    //Set command active connection
                    cmdDB.ActiveConnection = m_connDB;
                    //Set SQL query statement
                    cmdDB.CommandText = sQuery;
                    //Execute
                    cmdDB.Execute(out recs, ref parms, 0);
                    return (enumDBStatus.OK);
                }
                else
                {
                    return (enumDBStatus.FatalError);
                }
            }
            catch (Exception message)
            {
                MessageBox.Show("Unable to execute SQL statement.\r\n" + message, "(DB) Error");
                return (enumDBStatus.FatalError);
            }
        }
        public enumDBStatus QueryRecordCount(string sQuery, int p_lCount)
        {
            p_lCount = 0;
            try
            {
                if (m_connDB.State == 0)
                {
                    rs.Open(sQuery, m_connDB, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockReadOnly);
                    p_lCount = rs.RecordCount;
                    rs.Close();
                    return (enumDBStatus.OK);
                }
                else
                {
                    return (enumDBStatus.FatalError);
                }
            }
            catch (Exception message)
            {
                MessageBox.Show("Unable to execute SQL statement.\r\n" + message, "(DB) Error");
                return (enumDBStatus.FatalError);
            }
        }

        public enumDBStatus CloseDB()
        {
            try
            {
                //Close the connection

                if (m_connDB.State == 1)
                {
                    m_connDB.Close();
                    return (enumDBStatus.OK);
                }
                else
                {
                    return enumDBStatus.FatalError;
                }

            }
            catch (Exception message)
            {
                MessageBox.Show("Unable to close database.\r\n" + message, "(DB) Error");
                return (enumDBStatus.FatalError);
            }
        }

        public enumDBStatus QueryStoredProcValue(string sStoreProcName, tStoreProc[] Parameters, tStoreProc[] ParametersOut)

        {
            //Create ADODB Recordset instance
            object ParameterDB = null;
            try
            {
                cmdDB.ActiveConnection = m_connDB;
                cmdDB.CommandText = sStoreProcName;
                cmdDB.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc;

                for (int i = 0; i < Parameters.Length; i++)
                {
                    ParameterDB = cmdDB.CreateParameter(Parameters[i].Name, Parameters[i].Type, Parameters[i].Directional, Parameters[i].Size, Parameters[i].Value);

                    cmdDB.Parameters.Append(ParameterDB);
                }

                cmdDB.Execute(out recs, ref parms, 0);

                int c = 0;

                for (int i = 0; i < Parameters.Length; i++)
                {
                    if (Parameters[i].Directional == ADODB.ParameterDirectionEnum.adParamOutput) ;
                    {

                        ParametersOut[c].Name = Parameters[i].Name;
                        //ParametersOut[c].Value = cmdDB.Parameters.Item(i).Value;
                        //ParametersOut[c].Size = cmdDB.Parameters.Item(i).Size;
                        c++;
                    }
                }
                return (enumDBStatus.OK);
            }
            catch (Exception message)
            {
                sErrorString = "";

                for (int i = 0; i < m_connDB.Errors.Count; i++)
                {
                    //sErrorString = sErrorString + m_connDB.Errors.Item(i).Description + "\r\n";
                }

                MessageBox.Show("Unable to get recordset from data base.\r\n" + message, "(DB) Error");

                return (enumDBStatus.FatalError);
            }


        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string _psvalue = "";
            DBSQL_GetDataBaseVer( _psvalue);
        }

        public int DBSQL_GetDataBaseVer(string psvalue)//sStationType, sProductName, sProfileName, psvalue): Long Public
        {
            String sStationType = "MiniATE";
            String sProductName = "RHU";
            String sProfileName = "3.15_RHU_WMTS";
            tStoreProc[] Parametersout = new tStoreProc[1];
            tStoreProc[] ParametersIn = new tStoreProc[4];
            //var private vTemp = null;

            enumDBStatus lStatus;


            ParametersIn[0].Name = "@StationType";
            ParametersIn[0].Type = ADODB.DataTypeEnum.adVarChar;
            ParametersIn[0].Directional = ADODB.ParameterDirectionEnum.adParamInput;
            ParametersIn[0].Size = 255;
            ParametersIn[0].Value = sStationType;

            ParametersIn[1].Name = "@Product";
            ParametersIn[1].Type = ADODB.DataTypeEnum.adVarChar;
            ParametersIn[1].Directional = ADODB.ParameterDirectionEnum.adParamInput;
            ParametersIn[1].Size = 255;
            ParametersIn[1].Value = sProductName;

            ParametersIn[2].Name = "@Profile";
            ParametersIn[2].Type = ADODB.DataTypeEnum.adVarChar;
            ParametersIn[2].Directional = ADODB.ParameterDirectionEnum.adParamInput;
            ParametersIn[2].Size = 255;
            ParametersIn[2].Value = sProfileName;

            ParametersIn[3].Name = "@Rev";
            ParametersIn[3].Type = ADODB.DataTypeEnum.adVarChar;
            ParametersIn[3].Directional = ADODB.ParameterDirectionEnum.adParamOutput;
            ParametersIn[3].Size = 50;
            ParametersIn[3].Value = "--";


            psvalue = "";

            lStatus = QueryStoredProcValue("prcATEGetProfileProductionRev", ParametersIn, Parametersout);

            if (lStatus == enumDBStatus.OK) 
            { 
                if (Parametersout[0].Value != "")
                {
                    psvalue = Parametersout[0].Value;
                }
                    
                else
                {
                    psvalue = "";
                    lStatus = enumDBStatus.EmptyRecordset;
                }

            }
            return (Convert.ToInt32 (lStatus));
           }
        
    }

}


    
