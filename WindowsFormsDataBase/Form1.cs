using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsDataBase
{
    public partial class Form1 : Form
    {
        public string cnStr = "Initial Catalog=ATEP;Data Source=ACGB1AP23;User ID=StationATE;Password=maate";//ACGB1AP23
        public string query;
        public string sErrorString;
        public string sRev;

        public enum enumDBStatus
        {
            OK,
            EmptyRecordset,
            FatalError,
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
            label1.Text = OpenDB();
        }

        public string OpenDB()
        {
            //Connection string.
            
            string sconnection = "Data Base Not Connected";
            SqlConnection conn = new SqlConnection(cnStr);
            try
            {
                conn.Open();
                sconnection = "ServerVersion:"+Convert.ToString(conn.ServerVersion)+" State: "+ Convert.ToString(conn.State);
                conn.Close();
                return sconnection;
            }
            catch
            {
                return sconnection;
            }
        }
        public  string dBATEGetProfileProductionRev(String sStationType, String sProductName, String sProfileName)
        {
            // 1. Create a new instance of the generated OpenAccessContext.
            SqlConnection conn = new SqlConnection(cnStr);

            //StationType = "MiniATE";
            //sProductName = "RHU";
            //sProfileName = "7.2_RHU_2K_Cell_PCSE_H_NewPA";


            // 2. Get connection.
            using (IDbConnection dbConnection = conn)
                {
                    // 3. Initialize and execute OACommand.
                    using (IDbCommand spCommand = dbConnection.CreateCommand())
                    {
                    conn.Open();
                    spCommand.CommandText = "prcATEGetProfileProductionRev";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    // 4. Initialize parameters.
                    
                        IDbDataParameter StationType = spCommand.CreateParameter();
                        StationType.ParameterName = "@StationType";
                        StationType.DbType = System.Data.DbType.String;
                        StationType.Direction = System.Data.ParameterDirection.Input;
                        StationType.Value = sStationType;
                        spCommand.Parameters.Add(StationType);


                        IDbDataParameter Product = spCommand.CreateParameter();
                        Product.ParameterName = "@Product";
                        Product.Direction = System.Data.ParameterDirection.Input;
                        Product.DbType = System.Data.DbType.String;
                        Product.Size = 255;
                        Product.Value = sProductName;
                        spCommand.Parameters.Add(Product);

                        IDbDataParameter Profile = spCommand.CreateParameter();
                        Profile.ParameterName = "@Profile";
                        Profile.Direction = System.Data.ParameterDirection.Input;
                        Profile.DbType = System.Data.DbType.String;
                        Profile.Size = 255;
                        Profile.Value = sProfileName;
                        spCommand.Parameters.Add(Profile);


                        IDbDataParameter Rev = spCommand.CreateParameter();
                        Rev.ParameterName = "@Rev";
                        Rev.Direction = System.Data.ParameterDirection.Output;
                        Rev.DbType = System.Data.DbType.String;
                        Rev.Size = 50;
                        Rev.Value = "--";
                        spCommand.Parameters.Add(Rev);
        
                        spCommand.ExecuteNonQuery();

                    // 5. Consume the out parameters and the return value.
                    Console.WriteLine(Rev.Value);
                        return Convert.ToString(Rev.Value);
                    }
                }
            
        }
        public string dBGetValueString(String sStationType, String sProductName, String sProfileName, String sTaskName, String sIniFile, String sKey, String sRev)
        {
            // 1. Create a new instance of the generated OpenAccessContext.
            SqlConnection conn = new SqlConnection(cnStr);
                // 2. Get connection.
                using (IDbConnection dbConnection = conn)
            {
                // 3. Initialize and execute OACommand.
                using (IDbCommand spCommand = dbConnection.CreateCommand())
                {
                    conn.Open();
                    spCommand.CommandText = "prcATEGetParameterValueUnit";
                    spCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    // 4. Initialize parameters.

                    IDbDataParameter StationType = spCommand.CreateParameter();
                    StationType.ParameterName = "@StationType";
                    StationType.DbType = System.Data.DbType.String;
                    StationType.Direction = System.Data.ParameterDirection.Input;
                    StationType.Value = sStationType;
                    spCommand.Parameters.Add(StationType);


                    IDbDataParameter Product = spCommand.CreateParameter();
                    Product.ParameterName = "@Product";
                    Product.Direction = System.Data.ParameterDirection.Input;
                    Product.DbType = System.Data.DbType.String;
                    Product.Size = 255;
                    Product.Value = sProductName;
                    spCommand.Parameters.Add(Product);

                    IDbDataParameter Profile = spCommand.CreateParameter();
                    Profile.ParameterName = "@Profile";
                    Profile.Direction = System.Data.ParameterDirection.Input;
                    Profile.DbType = System.Data.DbType.String;
                    Profile.Size = 255;
                    Profile.Value = sProfileName;
                    spCommand.Parameters.Add(Profile);


                   IDbDataParameter Task = spCommand.CreateParameter();
                   Task.ParameterName = "@Task";
                   Task.Direction = System.Data.ParameterDirection.Input;
                   Task.DbType = System.Data.DbType.String;
                   Task.Size = 255;
                   Task.Value = sTaskName;
                   spCommand.Parameters.Add(Task);



                        IDbDataParameter IniFile = spCommand.CreateParameter();
                        IniFile.ParameterName = "@IniFile";
                        IniFile.Direction = System.Data.ParameterDirection.Input;
                        IniFile.DbType = System.Data.DbType.String;
                        IniFile.Size = 255;
                        IniFile.Value = sIniFile;
                        spCommand.Parameters.Add(IniFile);




                        IDbDataParameter Parameter = spCommand.CreateParameter();
                        Parameter.ParameterName = "@Parameter";
                        Parameter.Direction = System.Data.ParameterDirection.Input;
                        Parameter.DbType = System.Data.DbType.String;
                        Parameter.Size = 255;
                        Parameter.Value = sKey;
                        spCommand.Parameters.Add(Parameter);

                    IDbDataParameter Rev = spCommand.CreateParameter();
                    Rev.ParameterName = "@Rev";
                    Rev.Direction = System.Data.ParameterDirection.Input;
                    Rev.DbType = System.Data.DbType.String;
                    Rev.Size = 50;
                    Rev.Value = sRev;
                    spCommand.Parameters.Add(Rev);

                        IDbDataParameter Value = spCommand.CreateParameter();
                        Value.ParameterName = "@Value";
                        Value.Direction = System.Data.ParameterDirection.Output;
                        Value.DbType = System.Data.DbType.String;
                        Value.Size = 50;
                        Value.Value = "_";
                        spCommand.Parameters.Add(Value);

                        IDbDataParameter Unit = spCommand.CreateParameter();
                        Unit.ParameterName = "@Unit";
                        Unit.Direction = System.Data.ParameterDirection.Output;
                        Unit.DbType = System.Data.DbType.String;
                        Unit.Size = 50;
                        Unit.Value = "--";
                        spCommand.Parameters.Add(Unit);

                        spCommand.ExecuteNonQuery();

                    // 5. Consume the out parameters and the return value.
                    Console.WriteLine(Value.Value);
                    return Convert.ToString(Value.Value);
                }
            }

        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            StationName.Text = "MiniATE";
            ProductName.Text = "RHU";
            ProfileName.Text = "7.2_RHU_2K_Cell_PCSE_H_NewPA";

            sRev = dBATEGetProfileProductionRev(StationName.Text, ProductName.Text, ProfileName.Text);

            Ver.Text = sRev;
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            StationName.Text = "MiniATE";
            ProductName.Text = "RHU";
            ProfileName.Text = "7.2_RHU_2K_Cell_PCSE_H_NewPA";

            string svalue = "";
            svalue = dBGetValueString(StationName.Text, ProductName.Text, ProfileName.Text, "Gain & Ripple DL_HB", "TestData.ini", "Required_Gain", sRev);
            Console.WriteLine(svalue);
            sValue.Text = svalue;

        }
    }

}


    
