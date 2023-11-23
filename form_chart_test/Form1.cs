using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace form_chart_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string connectionString = "Data Source=AMAZE\\SQLEXPRESS;Initial Catalog=countries;Integrated Security=True";

            // Replace the SQL query with your SELECT statement
            string query = "SELECT * FROM country";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Create a DataTable to hold the result of the query
                    DataTable dataTable = new DataTable();

                    // Execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Create a series
                    Series series = new Series("YourSeries");
                    series.ChartType = SeriesChartType.Column; // Choose the chart type (Column, Bar, Line, etc.)

                    // Bind the series to the data table
                    series.Points.DataBind(dataTable.AsEnumerable(), "country", "population", "");

                    // Add the series to the chart
                    chart1.Series.Add(series);

                    // Customize chart appearance if needed
                    chart1.ChartAreas[0].AxisX.Title = "Category";
                    chart1.ChartAreas[0].AxisY.Title = "Value";
                }
            }

        }
    }
}
