using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : Window
    {
        public GridView()
        {
            InitializeComponent();
            getData();
        }
        SqlDataAdapter sda;
        DataTable dt;
        void getData()
        {
            //Northwind database download path:http://download.csdn.net/down/845087/beyondchina123
            //init sqlconnection
            SqlConnectionStringBuilder connbuilder = new SqlConnectionStringBuilder();
            connbuilder.DataSource = ".";//本地服务器
            connbuilder.IntegratedSecurity = true;//Windows集成验证
            connbuilder.InitialCatalog = "TestDB";//数据库为Northwind
            SqlConnection conn = new SqlConnection(connbuilder.ConnectionString);
            sda = new SqlDataAdapter("select EmployeeID,FirstName,LastName,Address from Employees ", conn);
            SqlCommandBuilder commbuilder = new SqlCommandBuilder(sda);
            //sda.UpdateCommand = commbuilder.GetUpdateCommand();
            dt = new DataTable();
            //sda.AcceptChangesDuringUpdate = true;
            sda.Fill(dt);
            listview1.ItemsSource = dt.DefaultView;
        }
    }
}
