using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TestingSomeShit
{
    public partial class Form1 : Form
    {
        static MongoClient client = new MongoClient("mongodb+srv://root:root@cluster0-uzqko.gcp.mongodb.net/test?retryWrites=true&w=majority");
        static IMongoDatabase db = client.GetDatabase("movies");
        static IMongoCollection<Movie> collection = db.GetCollection<Movie>("fantasy");

        public void ReadAllDocuments()
        {
            List<Movie> list = collection.AsQueryable().ToList<Movie>();
            dataGridView1.DataSource = list;
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            this.dataGridView1.Columns["ID"].Visible = false;
        }
        public Form1()
        {
            

            

            InitializeComponent();
            ReadAllDocuments();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Movie s = new Movie(textBox2.Text, Double.Parse(comboBox1.Text),textBox3.Text,textBox4.Text);
            collection.InsertOne(s);
            ReadAllDocuments();
            /* var client = new MongoClient("mongodb://root:root@cluster0-uzqko.gcp.mongodb.net");*/
            //var client = new MongoClient();




        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var updateDef = Builders<Movie>.Update.Set("name", textBox2.Text).Set("type", textBox3.Text).Set("rate", comboBox1.Text).Set("description", textBox4.Text);
            collection.UpdateOne(s => s.Id == ObjectId.Parse(textBox1.Text), updateDef);
            ReadAllDocuments();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(textBox1.Text));
            ReadAllDocuments();
        }
    }
}
