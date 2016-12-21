using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace TOP_3
{
    public partial class MainWindow : Form
    {
        VartotojuValdymas vv;
        PrekiuValdymas pv;
        TransakcijuValdymas tv;
        string cString;
        public MainWindow()
        {
            InitializeComponent();
            cString = ConfigurationManager.ConnectionStrings["TOP_3.Properties.Settings.dbConnectionString"].ConnectionString;
            RefershStats();
            
           

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            vv = new VartotojuValdymas();
            vv.ShowDialog();
            RefershStats();
        }
        private void RefreshStats()
        {
            using (SqlConnection connection = new SqlConnection(cString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Vartotojas", connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable x = new DataTable();
                adapter.Fill(x);
                var userCount = x.Rows[0][0];
                cntUser.Text = userCount.ToString();
                command.CommandText = "SELECT COUNT(*) FROM Kategorija";
                x = new DataTable();
                adapter.Fill(x);
                var catCount = x.Rows[0][0];
                cntCategory.Text = catCount.ToString();
                command.CommandText = "SELECT COUNT(*) FROM Preke";
                x = new DataTable();
                adapter.Fill(x);
                var productCount = x.Rows[0][0];
                cntProduct.Text = productCount.ToString();
                command.CommandText = "SELECT COUNT(*) FROM Transakcijos";
                x = new DataTable();
                adapter.Fill(x);
                var transactionCount = x.Rows[0][0];
                cntTransactions.Text = transactionCount.ToString();

            }
        }
        void RefershStats()
        {
            dbEntities1 context = new dbEntities1();
            cntUser.Text = context.Vartotojas.Count().ToString();
            cntCategory.Text = context.Kategorija.Count().ToString();
            cntProduct.Text = context.Preke.Count().ToString();
            cntTransactions.Text = context.Transakcijos.Count().ToString();
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            pv = new PrekiuValdymas();
            pv.ShowDialog();
            RefershStats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tv = new TransakcijuValdymas();
            tv.ShowDialog();
            RefershStats();
        }
    }
}
