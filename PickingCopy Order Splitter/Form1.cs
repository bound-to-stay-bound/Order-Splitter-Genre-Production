using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace PickingCopy_Order_Splitter
{
    public partial class Form1 : Form
    {
        public const string ServerName = "SQLSERVER";
        public const string UserName = "OnlineUser";
        public const string Password = "btsb";
        SqlConnection cn = new SqlConnection("user id=" + UserName + ";" +
                                      "password=" + Password + ";server=" + ServerName + ";" +
                                      "Trusted_Connection=no;" +
                                      "connection timeout=30");
        string Customer,Order;
        private int linesPrinted;
        private string[] lines;
        string DBDate;

        public Form1()
        {
            InitializeComponent();
            cn.Open();
        }

        private void FetchTitles_Click(object sender, EventArgs e)
        {
            GetTitleBreakdown();
        }

        private Boolean CheckForSplitOrders()
        {
            string SQL;
            SQL = "select distinct Customerno, Orderno from orders.dbo.titles where ispicked is null";
            SqlDataReader DR = FetchReader(SQL);
            if (DR.HasRows)
            {                
                while (DR.Read())
                {
                    MessageBox.Show("Unable to close, there is still a split order in the system:" + DR["Customer"] + " " + DR["Orderno"]);
                    CustomerOrderNumber.Text=DR["Customer"].ToString() + DR["Orderno"].ToString();
                }
                DR.Close();
                return true;
            }
            DR.Close();
            return false;
        }

        private void GetTitleBreakdown()
        {
            if (CustomerOrderNumber.Text.Length == 13)
            {
                Customer = CustomerOrderNumber.Text.Substring(0, 8);
                Order = CustomerOrderNumber.Text.Substring(8, 5);

                string SQL;
                //SQL = "SELECT DISTINCT t.customerno, t.orderno, DatePicked, CASE CollectionCode1 WHEN '' THEN substring(Classification,1,1) ELSE Genre END as SplitGroup, count(1) as SplitCount, IsPicked FROM orders.dbo.titles t, orders.dbo.headers h WHERE t.customerno=h.customerno and t.orderno=h.orderno and (IsPicked IS NULL OR IsPicked = '1') and CancelCode IS NULL " +
                // " and t.customerno = '" + Customer + "' and h.orderno ='" + Order + "'" +
                // " GROUP BY t.customerno, t.orderno, DatePicked, CASE CollectionCode1 WHEN '' THEN substring(Classification,1,1) ELSE Genre END, IsPicked" +
                //    " ORDER BY t.customerno, t.orderno, SplitGroup";
                SQL = "SELECT DISTINCT t.customerno, t.orderno, DatePicked, CASE Genre WHEN '' THEN substring(Classification,1,1) ELSE Genre END as SplitGroup, count(1) as SplitCount, IsPicked FROM orders.dbo.titles t, orders.dbo.headers h WHERE t.customerno=h.customerno and t.orderno=h.orderno and (IsPicked IS NULL OR IsPicked = '1') and CancelCode IS NULL " +
                 " and t.customerno = '" + Customer + "' and h.orderno ='" + Order + "'" +
                 " GROUP BY t.customerno, t.orderno, DatePicked, CASE Genre WHEN '' THEN substring(Classification,1,1) ELSE Genre END, IsPicked" +
                    " ORDER BY t.customerno, t.orderno, SplitGroup";
                Console.WriteLine(SQL);
                SqlDataReader DR = FetchReader(SQL);

                OrderSplitterChoice.Items.Clear();
                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        //OrderDetails.Text += DR["Customer"] + " " + DR["OrderNo"] + "\t" + DR["GenreGroup"] + "\t" + DR["GenreCount"] + System.Environment.NewLine;
                        OrderSplitterChoice.Items.Add(DR["SplitGroup"] + "\t" + DR["SplitCount"]);
                        if (DR["IsPicked"].ToString() == "1")
                        {
                            OrderSplitterChoice.SetItemChecked(OrderSplitterChoice.Items.Count - 1, true);
                        }
                        var str = Convert.ToDateTime(DR["DatePicked"].ToString());
                        OriginalPickDate.Text = str.ToString("MM/dd/yyyy");
                    }
                }
                else
                {
                    MessageBox.Show(Customer + " " + Order + " doesn't have any titles on picking copy.");
                }
                DR.Close();
            }
            else
            {
                MessageBox.Show("Invalid Customer + Order number");
            }           
        }

        public SqlDataReader FetchReader(string inQuery)
        {
            SqlCommand myCommand = new SqlCommand(inQuery, cn);
            SqlDataReader AReader = null;
            AReader = myCommand.ExecuteReader();

            return AReader;
        }

        private void CustomerOrderNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                GetTitleBreakdown();   
            }
        }

        private void RunSQL(string SQL)
        {
            SqlCommand CMD = new SqlCommand(SQL, cn);
            CMD.ExecuteNonQuery();
            CMD.Dispose();
        }

        private void UpdateOrder_Click(object sender, EventArgs e)
        {
            DBDate = FakePickDate.Value.Year.ToString("00") + "-";
            DBDate += FakePickDate.Value.Month.ToString("00") + "-";
            DBDate += FakePickDate.Value.Day.ToString("00");
            if (MessageBox.Show("Update order " + Customer + " " + Order + "?  This will flag/unflag titles and change the pickdate to " + DBDate, "Update Order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string SQL;
                DBDate = FakePickDate.Value.Year.ToString("00") + "-";
                DBDate += FakePickDate.Value.Month.ToString("00") + "-";
                DBDate += FakePickDate.Value.Day.ToString("00");
                SQL = "UPDATE Orders.dbo.Headers SET DatePicked='" + DBDate + "' WHERE customerno = '" + Customer + "' and orderno = '" + Order + "'";
                //MessageBox.Show(SQL);
                RunSQL(SQL);
                SQL = "UPDATE Orders.dbo.Titles SET IsPicked = NULL WHERE customerno = '" + Customer + "' and orderno = '" + Order + "' and IsPicked = 1";
                //MessageBox.Show(SQL);
                RunSQL(SQL);
                foreach (int indexChecked in OrderSplitterChoice.CheckedIndices)
                {
                    string formatItem = OrderSplitterChoice.Items[indexChecked].ToString();
                    char[] delimiterChars = { '\t' };
                    string[] words = formatItem.Split(delimiterChars); 
                    formatItem = words[0];

                    if (formatItem.Length == 1)
                    {
                        // 2020-12-23 - Hank Lane - need to handle empty classifications when they occur.
                        // 2021-01-21 - Hank Lane - added addition check to make sure Genre is blank when pulling classifications
                        // 2021-02-19 - Hank Lane - removed CollectionCode1 being blank as a requirement
                        var classChoice = OrderSplitterChoice.Items[indexChecked].ToString().Substring(0, 1).Trim();
                        SQL = "UPDATE Orders.dbo.Titles SET IsPicked = 1 WHERE customerno = '" + Customer + "' AND orderno = '" + Order + "' AND IsPicked IS NULL" +
                            " AND substring(Classification,1,1) = '" + classChoice + "' AND LTRIM(RTRIM(Genre)) =''";
                        //" AND CollectionCode1 = '' AND substring(Classification,1,1) = '" + OrderSplitterChoice.Items[indexChecked].ToString().Substring(0, 1) + "'";
                    }
                    else
                    {
                        // 2020-12-23 - Hank Lane - need to handle empty genres when they occur.
                        var genreChoice = OrderSplitterChoice.Items[indexChecked].ToString().Trim();
                        var gArray = genreChoice.Split('\t');
                        genreChoice = gArray[0];
                        SQL = "UPDATE Orders.dbo.Titles SET IsPicked = 1 WHERE customerno = '" + Customer + "' AND orderno = '" + Order + "' AND IsPicked IS NULL" +
                          " AND LTRIM(RTRIM(Genre)) = '" + genreChoice + "'";
                        //" AND Genre = '" + OrderSplitterChoice.Items[indexChecked].ToString() + "'";
                    }
                    //MessageBox.Show(SQL);
                    RunSQL(SQL);
                }
                MessageBox.Show(Customer + " " + Order + " updated.","Done");
            }
        }

        private void PrintSummary_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int i = 0;
            
            lines=new string[OrderSplitterChoice.Items.Count+6];
            lines[i++] = "Order Split " + DateTime.Now;
            lines[i++] = "Customer: " + Customer;
            lines[i++] = "Order: " + Order;
            lines[i++] = "Current Picking Date:" + OriginalPickDate.Text;
            lines[i++] = "Modified Picking Date:" + FakePickDate.Value.ToShortDateString();
                //OriginalPickDate.Value.ToString();
            lines[i++] = "";      
            foreach (string s in OrderSplitterChoice.Items)
            {
                lines[i++] = s;
            }
            
            
            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(System.Drawing.Color.Black);

            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    OrderSplitterChoice.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderSplitterChoice.Items.Count; i++)
            {
                OrderSplitterChoice.SetItemChecked(i, true);
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderSplitterChoice.Items.Count; i++)
            {
                OrderSplitterChoice.SetItemChecked(i, false);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CheckForSplitOrders();
        }
    }
}