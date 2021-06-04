using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace phsycologyForm
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
            rebackRB.Enabled = false;
            saveNewBackupRB.Checked = true;
            dateLabel.Enabled = false;
            backupDateComboBox.Enabled = false;
        }

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["psychologyDBConnectionString"].ConnectionString;

        /*
        public class DatabaseFileList
        {
            public string DataName { get; set; }
            public string LogName { get; set; }
        }


        private DatabaseFileList GetDatabaseFileList(string localDatabasePath)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["psychologyDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = @"RESTORE FILELISTONLY FROM DISK = @localDatabasePath";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@localDatabasePath", localDatabasePath);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var fileList = new DatabaseFileList();
                        while (reader.Read())
                        {
                            string type = reader["Type"].ToString();
                            switch (type)
                            {
                                case "D":
                                    fileList.DataName = reader["LogicalName"].ToString();
                                    break;
                                case "L":
                                    fileList.LogName = reader["LogicalName"].ToString();
                                    break;
                            }
                        }
                        return fileList;
                    }
                }
            }
        }

       private void RestoreDatabase(string localDatabasePath, string fileListDataName, string fileListLogName)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["psychologyDBConnectionString"].ConnectionString;

            string localDownloadFilePath = $"C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\Backup\";
    Console.WriteLine(string.Format("Restoring database {0}...", localDatabasePath));
            string fileListDataPath = Directory.GetParent(localDownloadFilePath).Parent.FullName + @"\DATA\" + fileListDataName + ".mdf";
            string fileListLogPath = Directory.GetParent(localDownloadFilePath).Parent.FullName + @"\DATA\" + fileListLogName + ".ldf";

            string sql = @"RESTORE DATABASE @dbName FROM DISK = @path WITH RECOVERY,
        MOVE @fileListDataName TO @fileListDataPath,
        MOVE @fileListLogName TO @fileListLogPath";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 7200;
                    command.Parameters.AddWithValue("@dbName", fileListDataName);
                    command.Parameters.AddWithValue("@path", localDatabasePath);
                    command.Parameters.AddWithValue("@fileListDataName", fileListDataName);
                    command.Parameters.AddWithValue("@fileListDataPath", fileListDataPath);
                    command.Parameters.AddWithValue("@fileListLogName", fileListLogName);
                    command.Parameters.AddWithValue("@fileListLogPath", fileListLogPath);

                    command.ExecuteNonQuery();
                }
            }
        }*/



        /* private void CloseAllConnection()
         {
             string script = File.ReadAllText("closesCons.sql");
             // split script on GO command
             IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
             SqlConnection _connection = new SqlConnection(constring);
             _connection.Open();
             foreach (string commandString in commandStrings)
             {
                 if (commandString.Trim() != "")
                 {
                     using (var command = new SqlCommand(commandString, _connection))
                     {
                         command.ExecuteNonQuery();
                     }
                 }
             }
             _connection.Close();
             _connection.Dispose();
         }*/


        private void BackupButton_Click(object sender, EventArgs e)
        {
            try
            {

                string path = $"C:\\Softer\\BackupDB\\{DateTime.Now.ToString("dd-MM-yyyy__hh-mm-ss")}";
                Directory.CreateDirectory(path);
                string mdf = "C:\\Softer\\psychologyDB\\psychologyDB.mdf";
                string ldf = "C:\\Softer\\psychologyDB\\psychologyDB_log.ldf";
                string distMdf = $"{path}\\psychologyDB.mdf";
                string distLdf = $"{path}\\psychologyDB_log.ldf";


                File.Copy(mdf, distMdf);
                File.Copy(ldf, distLdf);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
            if (rebackRB.Checked)
            {


                try
                {
                    string path = $"C:\\Softer\\BackupDB\\{backupDateComboBox.Text}";
                    if (Directory.Exists(path))
                    {

                        BackupButton.Enabled = false; // disable button restore till restoration completed 
                        CloseAllConnection(); // Calling Function to close any open database session .

                        string BackupdataBasePath = $"{path}\\psychology.bak";

                Server dbServer = new Server(new ServerConnection("Your server name",
                   "Your Server User Name ", "Your Server Password"));
                        Restore _Restore = new Restore()
                        {
                            Database = "Name of Database to be restored",
                            Action = RestoreActionType.Database,
                            ReplaceDatabase = true,
                            NoRecovery = false
                        };
                        _Restore.Devices.AddDevice(, DeviceType.File);

                        _Restore.PercentComplete += DB_Restore_PersentComplete;
                        _Restore.Complete += DB_Restore_Complete;
                        _Restore.SqlRestoreAsync(dbServer);

                    }
                catch (Exception ex)
                {
                    btn_restore.Enabled = true;
                    MessageBox.Show(ex.Message);
                }
            }
            

            //restoring
            try
                {
                    string path = $"C:\\Softer\\BackupDB\\{backupDateComboBox.Text}";
                    if (Directory.Exists(path))
                    {

                        using (SqlConnection restoreConn = new SqlConnection())
                        {
                            restoreConn.ConnectionString = constring;
                            restoreConn.Open();
                            using (SqlCommand restoredb_executioncomm = new SqlCommand())
                            {
                                restoredb_executioncomm.Connection = restoreConn;
                                restoredb_executioncomm.CommandText = $"RESTORE DATABASE [C:\\SOFTER\\PSYCHOLOGYDB\\PSYCHOLOGYDB.MDF] FROM DISK='path\\psychologyDB.bak'";

                                restoredb_executioncomm.ExecuteNonQuery();
                            }
                            restoreConn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }*/
        }


        private void rebackRB_CheckedChanged(object sender, EventArgs e)
        {
            if (rebackRB.Checked)
            {
                dateLabel.Enabled = true;
                backupDateComboBox.Enabled = true;
                BackupButton.Text = "استرجاع";
                string directory = $"C:\\Softer\\BackupDB";

                if (Directory.Exists(directory))
                {
                    backupDateComboBox.Items.Clear();
                    string[] files = Directory.GetDirectories(directory);
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileName(file);
                        backupDateComboBox.Items.Add(fileName);
                    }
                    backupDateComboBox.Text = backupDateComboBox.Items[0].ToString();
                }
            }
            else
            {
                BackupButton.Text = "حفظ";
                dateLabel.Enabled = false;
                backupDateComboBox.Enabled = false;

            }
        }
    }
}
