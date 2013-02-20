using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace StockService
{
    public partial class Main : Form
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["StockService"].ToString();
        public static Main main = null;
        
        public Main()
        {
            InitializeComponent();
            UpdateList();
            main = this;
        }

        public void UpdateList()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateList));
                return;
            }

            // Clean previous list
            transactionsList.Items.Clear();
           
            // Query database
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Transaction]", sqlConnection);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    Console.WriteLine("ID = " + sqlReader["ID"]);

                    ListViewItem item = new ListViewItem(new string[] {
                        ((int)sqlReader["ID"]).ToString(),
                        sqlReader["ClientName"] as string,
                        sqlReader["StockType"] as string,
                        ((Server.TransactionType)Enum.ToObject(typeof(Server.TransactionType), Convert.ToInt32((bool)sqlReader["Type"]))).ToString(),
                        ((double)sqlReader["Quantity"]).ToString()
                    });
                    transactionsList.Items.Add(item);
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void transactionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = transactionsList.SelectedIndices;
            if (indexes.Count != 1) return; // There can't be more than one item selected

            foreach (int index in indexes)
            {
                ListViewItem item = transactionsList.Items[index];
                string id = item.SubItems[0].Text;
                string clientName = item.SubItems[1].Text;
                string stockType = item.SubItems[2].Text;
                string quantity = item.SubItems[3].Text;

                // TODO: if state is OK, then do nothing

                // Put values in labels
                textBoxID.Text = id;
                textBoxClientName.Text = clientName;
                textBoxStockType.Text = stockType;
                textBoxQuantity.Text = quantity;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get values
            if (textBoxStockValue.Text.Length == 0) return;
            if (textBoxID.Text.Length == 0) return;

            int id = int.Parse(textBoxID.Text);
            double stockValue = 0.0;

            try
            {
                stockValue = double.Parse(textBoxStockValue.Text);
                textBoxStockValue.BackColor = Color.White;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
                textBoxStockValue.BackColor = Color.Pink;
                return;
            }

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try {
                // Send to WCF server
                Program.client.PerformTransaction(id, stockValue);

                // Change database
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM [Transaction] WHERE ID = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();

                // Erase values
                textBoxID.Text = "";
                textBoxClientName.Text = "";
                textBoxStockType.Text = "";
                textBoxQuantity.Text = "";
                textBoxStockValue.Text = "";
                
            } finally {
                sqlConnection.Close();
                UpdateList();
            }
        }

    }
}
