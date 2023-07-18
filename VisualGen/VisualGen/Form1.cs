using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualGen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int[] nums = new int[10];
			Array.Clear(nums, 0, nums.Length);

			for (long i = 0; i < 100000; i++)
			{
				ulong rand = RandGen.MagicRandom();
				nums[rand % 10]++;
			}

			// Clear any existing series from the chart (optional)
			chart1.Series.Clear();

			// Add a new series for the columns
			Series columnSeries = new Series("ColumnSeries");
			columnSeries.Color = Color.Turquoise;
			// Set the chart type to columns (vertical columns)
			columnSeries.ChartType = SeriesChartType.Column;

			for (int i = 0; i < nums.Length; i++)
			{
				columnSeries.Points.AddXY(i.ToString(), nums[i]);
			}

			// Add the series to the chart
			chart1.Series.Add(columnSeries);
			

			return;
		}
	}
}
