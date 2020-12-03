using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurdusingLinq
{
    public partial class Form1 : Form
    {

        RestaurantDBDataContext db;

        Restaurant r;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindgridview();
        }


        public void bindgridview()
        {
            db = new RestaurantDBDataContext();
            dataGridView1.DataSource = db.Restaurants;

        }


        private void insert_Click(object sender, EventArgs e)
        {

            db = new RestaurantDBDataContext();

            r = new Restaurant();

            r.id = int.Parse(idbox.Text);
            r.name = namebox.Text;
            r.rooms = int.Parse(roombox.Text);
            r.city = citybox.Text;

            db.Restaurants.InsertOnSubmit(r);
            db.SubmitChanges();
            bindgridview();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            idbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            namebox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            roombox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            citybox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count >0)
            {

                RestaurantDBDataContext rb = new RestaurantDBDataContext();

                int id = Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[0].Value);

                Restaurant rr = rb.Restaurants.FirstOrDefault(s => s.id == id);

                rr.id = int.Parse(idbox.Text.ToString());
                rr.name = namebox.Text.ToString();
                rr.city = citybox.Text.ToString();
                rr.rooms = int.Parse(roombox.Text.ToString());

                rb.SubmitChanges();

                bindgridview();



            }
            else
            {
                MessageBox.Show(" SELECT SOMETHING BUDDY ");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            RestaurantDBDataContext rb = new RestaurantDBDataContext();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Restaurant r = rb.Restaurants.FirstOrDefault(s => s.id == id);

            rb.Restaurants.DeleteOnSubmit(r);

            rb.SubmitChanges();

            bindgridview();



        }
    }
}
