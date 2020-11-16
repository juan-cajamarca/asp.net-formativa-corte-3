using FormativaFinalJC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace FormativaFinalJC
{
    public partial class index : System.Web.UI.Page
    {
        int idCar = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int op = DropDownList1.SelectedIndex;

            switch (op)
            {
                case 1: 
                    MultiViewOptions.SetActiveView(ViewCars);
                    break;
                case 2:
                    MultiViewOptions.SetActiveView(ViewRental);
                    break;
                default:
                    MultiViewOptions.ActiveViewIndex = -1;
                    break;
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null)
            {
                Vehiculo car = new Vehiculo();
                car.marca = TextBox1.Text;
                car.modelo = TextBox2.Text;
                using (var context = new DBFormativaEntities1())
                {                    
                    context.Vehiculo.Add(car);                    
                    context.SaveChanges();
                }
                
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int op = DropDownList2.SelectedIndex;

            switch (op)
            {
                case 1:
                    MultiViewCars.SetActiveView(ViewRegisterCars);
                    break;
                case 2:
                    MultiViewCars.SetActiveView(ViewEditCars);
                    ActualizarLista(DropDownList3);                    
                    break;
                case 3:
                    MultiViewCars.SetActiveView(ViewListCars);
                    using (var context = new DBFormativaEntities1())
                    {
                        var data = context.Vehiculo.ToList();
                        GridView1.DataSource = data;
                        GridView1.DataBind();
                    }
                    break;
                default :
                    MultiViewCars.ActiveViewIndex = -1;
                    break;
            }
        }

        protected void ButtonCreate_Click1(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null)
            {
                Vehiculo car = new Vehiculo();
                car.marca = TextBox1.Text;
                car.modelo = TextBox2.Text;
                using (var context = new DBFormativaEntities1())
                {
                    context.Vehiculo.Add(car);
                    context.SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("Campos Imcompletos");

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new DBFormativaEntities1())
            {
                var data = context.Vehiculo.ToList();
                GridView1.DataSource = data;
            }
            
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = DropDownList3.SelectedValue;
            Vehiculo car = new Vehiculo();

            string[] words = name.Split(',');
            using (var context = new DBFormativaEntities1())
            {
                car = context.Vehiculo.Find(int.Parse(words[0]));                
                TextBox3.Text = car.marca;
                TextBox4.Text = car.modelo;                
            }

        }

        protected void ButtonEditCar_Click(object sender, EventArgs e)
        {
            
            String name = DropDownList3.SelectedValue;
            Vehiculo car = new Vehiculo();
            string[] words = name.Split(',');
            if (TextBox3.Text != null && TextBox4.Text != null)
            {
                using (var context = new DBFormativaEntities1())
                {
                    car = context.Vehiculo.Find(int.Parse(words[0]));
                    car.marca = TextBox3.Text;
                    car.modelo = TextBox4.Text;
                    context.SaveChanges();
                    ActualizarLista(DropDownList3);
                }   

                    
            }
        }

        private void ActualizarLista(DropDownList drop)
        {
            drop.Items.Clear();
            drop.Items.Add(new ListItem("Opciones"));
            using (var cars = new DBFormativaEntities1())
            {
                foreach (var car in cars.Vehiculo.ToList())
                {
                    drop.Items.Add(new ListItem(car.Id+","+car.marca + "," + car.modelo));
                }
            }
        }
        private void ActualizarListaAlquiler(DropDownList drop)
        {
            drop.Items.Clear();
            drop.Items.Add(new ListItem("Opciones"));
            using (var rentals = new DBFormativaEntities1())
            {
                foreach (var rental in rentals.Alquiler.ToList())
                {
                    drop.Items.Add(new ListItem(rental.Id + "," + rental.cliente ));
                }
            }
        }

        

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int op = DropDownList5.SelectedIndex;

            switch (op)
            {
                case 1:
                    MultiViewRental.SetActiveView(ViewCreateRental);
                    ActualizarLista(DropDownList6);
                    break;
                case 2:
                    MultiViewRental.SetActiveView(ViewListRental);
                    //usshshs
                    using (var context = new DBFormativaEntities1())
                    {
                        var data = context.Vehiculo.ToList();
                        GridView3.DataSource = data;
                        GridView3.DataBind();
                    }
                    using (var context = new DBFormativaEntities1())
                    {
                        var data = context.Alquiler.ToList();
                        GridView2.DataSource = data;
                        GridView2.DataBind();
                    }
                    break;
                case 3:
                    MultiViewRental.SetActiveView(ViewDeleteRental);
                    ActualizarListaAlquiler(DropDownList7);
                    break;
                default:
                    MultiViewRental.ActiveViewIndex = -1;
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text != null && DropDownList6.SelectedIndex != 0 && TextBox6.Text != null && TextBox7.Text != null)
            {
                String name = DropDownList6.SelectedValue;
                string[] words = name.Split(',');
                Alquiler rental = new Alquiler();

                rental.cliente = TextBox5.Text;
                rental.vehiculo = int.Parse(words[0]);
                rental.precio = int.Parse(TextBox6.Text);
                rental.dias = int.Parse(TextBox7.Text);

                using (var context = new DBFormativaEntities1())
                {
                    context.Alquiler.Add(rental);
                    context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Campos Imcompletos");
            }
        }

        protected void ButtonDeleteRental_Click(object sender, EventArgs e)
        {
            if (DropDownList7.SelectedIndex != 0)
            {
                String name = DropDownList7.SelectedValue;
                string[] words = name.Split(',');
                Alquiler rental = new Alquiler();
                using (var context = new DBFormativaEntities1())
                {
                    rental = context.Alquiler.Find(int.Parse(words[0]));
                    context.Alquiler.Remove(rental);
                    context.SaveChanges();
                    ActualizarListaAlquiler(DropDownList7);
                }
            }
        }
    }
}