﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TP_Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabPage4.Name = "1";
            tabPage4.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            this.chart1.Titles.Clear();
            this.chart2.Titles.Clear();
            this.chart3.Titles.Clear();

            this.chart1.Titles.Add("Вариант 41");
            this.chart2.Titles.Add("Вариант 41");
            this.chart3.Titles.Add("Вариант 41");

            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart2.ChartAreas[0].AxisX.Title = "X";
            chart2.ChartAreas[0].AxisY.Title = "Y";
            chart3.ChartAreas[0].AxisX.Title = "X";
            chart3.ChartAreas[0].AxisY.Title = "Y";

            foreach (TabPage page in tabControl2.TabPages)
            {
                foreach (DataGridView data in page.Controls)
                {
                    int k = Convert.ToInt32(page.Text) - 1;
                    for (int i = 0; i < data.Rows.Count - 1; i++)
                    {
                        int x = Convert.ToInt32(data.Rows[i].Cells[0].Value); //double
                        int y = Convert.ToInt32(data.Rows[i].Cells[1].Value);
                        chart1.Series[k].Points.AddXY(x, y);



                        //chart1.Legends["Legend"].DockedToChartArea = "Default";
                    }
                    for (int i = 0; i < data.Rows.Count - 1; i++)
                    {
                        int x = Convert.ToInt32(data.Rows[i].Cells[0].Value);
                        int y = Convert.ToInt32(data.Rows[i].Cells[1].Value);
                        chart2.Series[k].Points.AddXY(x, y);
                    }
                    for (int i = 0; i < data.Rows.Count - 1; i++)
                    {
                        int x = Convert.ToInt32(data.Rows[i].Cells[0].Value);
                        int y = Convert.ToInt32(data.Rows[i].Cells[1].Value);
                        chart3.Series[k].Points.AddXY(x, y);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = tabControl2.TabCount;
            chart1.Series.Add(Convert.ToString(count));
            chart2.Series.Add(Convert.ToString(count));
            chart3.Series.Add(Convert.ToString(count));
            chart1.Series[count].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[count].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart3.Series[count].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


            TabPage page = new TabPage((tabControl2.TabCount + 1).ToString());
            tabControl2.TabPages.Add(page);
            DataGridView dgv = new DataGridView();
            dgv.ColumnCount = 2;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].HeaderText = "X";
            dgv.Columns[1].HeaderText = "Y";
            dgv.Dock = DockStyle.Fill;
            page.Controls.Add(dgv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
                chart1.Series[tabControl2.SelectedIndex].MarkerColor = MyDialog.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            int number_of_chart = tabControl1.SelectedIndex;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                if (number_of_chart == 0)
                {
                    chart1.ChartAreas[0].AxisX.LineColor = MyDialog.Color;
                    chart1.ChartAreas[0].AxisY.LineColor = MyDialog.Color;
                }
                if (number_of_chart == 1)
                {
                    chart2.ChartAreas[0].AxisX.LineColor = MyDialog.Color;
                    chart2.ChartAreas[0].AxisY.LineColor = MyDialog.Color;
                }
                if (number_of_chart == 2)
                {
                    chart3.ChartAreas[0].AxisX.LineColor = MyDialog.Color;
                    chart3.ChartAreas[0].AxisY.LineColor = MyDialog.Color;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            int number_of_chart = tabControl1.SelectedIndex;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                if (number_of_chart == 0)
                {
                    chart1.ChartAreas[0].BackColor = MyDialog.Color;
                }
                if (number_of_chart == 1)
                {
                    chart2.ChartAreas[0].BackColor = MyDialog.Color;
                }
                if (number_of_chart == 2)
                {
                    chart3.ChartAreas[0].BackColor = MyDialog.Color;
                }
            }
        }
    }
}
