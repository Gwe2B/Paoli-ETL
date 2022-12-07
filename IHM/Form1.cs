using Flurl.Http;
using System.Data;
using System.Drawing;
using System.IO;

namespace IHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Create a new ListView control.

            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 400));
            
            listView1.View = View.Details;            
            listView1.LabelEdit = true;           
            listView1.AllowColumnReorder = true;          
            listView1.CheckBoxes = true;            
            listView1.FullRowSelect = true;            
            listView1.GridLines = true;           
            listView1.Sorting = SortOrder.Ascending;

            listView1.Columns.Add("Entetes", -2, HorizontalAlignment.Left);
            


            ListViewItem item1 = new ListViewItem("col1", 0);

            ListViewItem item2 = new ListViewItem("col2", 0);

            ListViewItem item3 = new ListViewItem("col3", 0);
            ListViewItem item4 = new ListViewItem("col4", 0);



            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4 });
        }



        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Access files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                var url = "http://localhost:5229/Upload";

                url.PostMultipartAsync(mp => mp 
                    .AddFile("file", path)
                    );



            }
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}