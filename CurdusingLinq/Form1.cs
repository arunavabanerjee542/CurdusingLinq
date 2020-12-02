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


        }
    }
}
