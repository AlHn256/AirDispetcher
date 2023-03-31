using AirDispetcher.Model;
using Microsoft.Office.Interop;
using System.Collections.Generic;

namespace AirDispetcher
{
    public partial class Form1 : Form
    {
        private FileWork FileWork = new FileWork();
        public Form1()
        {
            InitializeComponent();
            ReloadDataGrid();
        }
        private void ReloadDataGrid()
        {
            var PassengersList = FileWork.GetPassengersList();
            if (PassengersList.Count == 0)
            {
                RTB.Text += "\nСписок пассажиров пустой!";
            }
            else
            {
                BindingSource bind = new BindingSource { DataSource = PassengersList };
                PassenerDataGridView.DataSource = bind;
                //dataGreedRefresh();
            }
        }

        private void dataGreedRefresh()
        {
            PassenerDataGridView.Invalidate(true);
            PassenerDataGridView.Update();
            PassenerDataGridView.Refresh();
        }


        private void AddPassenger_Click(object sender, EventArgs e)
        {
            AddPassenger addPassenger = new AddPassenger();
            addPassenger.ShowDialog();
            if (addPassenger.passenger!=null)
            {
                FileWork.AddPassenger(addPassenger.passenger.FIO, addPassenger.passenger.Passport);
                RTB.Text += addPassenger.passenger.FIO + " добавлен\n";
                ReloadDataGrid();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileWork.SaveData();
        }
    }
}