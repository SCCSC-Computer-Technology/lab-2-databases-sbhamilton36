//Stephanie Hamilton
//CPT-206-A80H
//Lab-2 Databases

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shamilton_CPT206A80H_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

        //sort ascending
        private void btnASCPopulation_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortASCPopulation(this.cityDBDataSet.City);
        }

        //sort decending
        private void btnDESCPopulation_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortDESCPopulation(this.cityDBDataSet.City);
        }

        //sort by city name
        private void btnByCityName_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortCityName(this.cityDBDataSet.City);
        }







        //get population calculations
        private void btnGetTotal_Click(object sender, EventArgs e)
        {
            try
            {
                //total
                double total = (double)this.cityTableAdapter.TotalPopulation();
                txtTotal.Text = total.ToString("N0");
            }
            catch
            {
                MessageBox.Show("Error finding solutions.");
            }
        }
        private void btnGetAvg_Click(object sender, EventArgs e)
        {
            try
            {
                //average
                double avg = (double)this.cityTableAdapter.AveragePopulation();
                txtAvg.Text = avg.ToString("N0");
            }
            catch
            {
                MessageBox.Show("Error finding solutions.");
            }
            
        }
        private void btnGetHighest_Click(object sender, EventArgs e)
        {
            try
            {
                //highest
                double highest = (double)this.cityTableAdapter.HighestPopulation();
                txtHighest.Text = highest.ToString("N0");
            }
            catch
            {
                MessageBox.Show("Error finding solutions.");
            }
        }
        private void btnGetLowest_Click(object sender, EventArgs e)
        {
            try
            {
                //lowest
                double lowest = (double)this.cityTableAdapter.LowestPopulation();
                txtLowest.Text = lowest.ToString("N0");
            }
            catch
            {
                MessageBox.Show("Error finding solutions.");
            }
        }






        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //reset datagrid
                this.cityTableAdapter.Fill(this.cityDBDataSet.City);

                //reset texts
                txtTotal.Clear();
                txtAvg.Clear();
                txtHighest.Clear();
                txtLowest.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data load error");
            }
        }
    }
}
