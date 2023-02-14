using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbms_project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection connection = new NpgsqlConnection("server= localhost;port=5432;UserId=postgres; password=12345; database= hw;");



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into show (categoryid, countryid, director_id, languageid, movie_company_id, name, platformid, show_type ) values(@category, @country, @director, @language, @movie_company, @name, @platform, @show_type)", connection);
            
            char show_type;
            if (comboBox5.Text == "Movie")
            {
                show_type = 'S';
            }
            else show_type = 'M';
            int language = int.Parse(comboBox1.Text.Split('|')[0]);
            int platform = int.Parse(comboBox2.Text.Split('|')[0]);
            int country = int.Parse(comboBox3.Text.Split('|')[0]);
            int category = int.Parse(comboBox4.Text.Split('|')[0]);
            int director = int.Parse(comboBox6.Text.Split('|')[0]);
            int movie_comp = int.Parse(comboBox10.Text.Split('|')[0]);

            command1.Parameters.AddWithValue("@category", category);
            command1.Parameters.AddWithValue("@country", country);
            command1.Parameters.AddWithValue("@director", director);
            command1.Parameters.AddWithValue("@language", language);
            command1.Parameters.AddWithValue("@movie_company", movie_comp);
            command1.Parameters.AddWithValue("@name", textBox1.Text);
            command1.Parameters.AddWithValue("@platform", platform);
            command1.Parameters.AddWithValue("@show_type", show_type);
            

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "select * from show";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            string Language = "select * from Language";
          
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(Language, connection);
            NpgsqlCommand cmd = new NpgsqlCommand(Language, connection);
            NpgsqlDataReader DR = cmd.ExecuteReader();
            
            while (DR.Read())
            {
                comboBox1.Items.Add(String.Format("{0} | {1}", DR[0], DR[1]));
            }
            string platform = "select * from Digital_Platform";
            connection.Close();

            connection.Open();
            NpgsqlDataAdapter adapt1 = new NpgsqlDataAdapter(platform, connection);
            NpgsqlCommand cmd1 = new NpgsqlCommand(platform, connection);
            NpgsqlDataReader DR1 = cmd1.ExecuteReader();
            while (DR1.Read())
            {
                comboBox2.Items.Add(String.Format("{0} | {1}", DR1[0], DR1[1]));
            }
            connection.Close();
                
            connection.Open();
            string country = "select * from Country";
            NpgsqlDataAdapter adapt2 = new NpgsqlDataAdapter(country, connection);
            NpgsqlCommand cmd2 = new NpgsqlCommand(country, connection);
            NpgsqlDataReader DR2 = cmd2.ExecuteReader();
            while (DR2.Read())
            {
                comboBox3.Items.Add(String.Format("{0} | {1}", DR2[0], DR2[1]));
            }
            connection.Close();

            connection.Open();
            string category = "select * from Category";
            NpgsqlDataAdapter adapt3 = new NpgsqlDataAdapter(category, connection);
            NpgsqlCommand cmd3 = new NpgsqlCommand(category, connection);
            NpgsqlDataReader DR3 = cmd3.ExecuteReader();
            while (DR3.Read())
            {
                comboBox4.Items.Add(String.Format("{0} | {1}", DR3[0], DR3[1]));
            }
            connection.Close();

            connection.Open();
            string director = "select * from Director";

            NpgsqlDataAdapter adapt4 = new NpgsqlDataAdapter(director, connection);
            NpgsqlCommand cmd4 = new NpgsqlCommand(director, connection);
            NpgsqlDataReader DR4 = cmd4.ExecuteReader();

            while (DR4.Read())
            {
                comboBox6.Items.Add(String.Format("{0} | {1}", DR4[0], DR4[1]));
            }
            connection.Close();

            connection.Open();
            string comp = "select * from movie_company";

            NpgsqlDataAdapter adapt5 = new NpgsqlDataAdapter(comp, connection);
            NpgsqlCommand cmd5 = new NpgsqlCommand(comp, connection);
            NpgsqlDataReader DR5 = cmd5.ExecuteReader();

            while (DR5.Read())
            {
                comboBox10.Items.Add(String.Format("{0} | {1}", DR5[0], DR5[3]));
            }
            connection.Close();

            connection.Open();
            string production_comp = "select * from production_company";
            NpgsqlDataAdapter adapt0 = new NpgsqlDataAdapter(production_comp, connection);
            NpgsqlCommand cmd0 = new NpgsqlCommand(production_comp, connection);
            NpgsqlDataReader DR0 = cmd0.ExecuteReader();
            while (DR0.Read())
            {
                comboBox11.Items.Add(String.Format("{0} | {1}", DR0[0], DR0[2]));
            }
            connection.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into actor (birth_date, gender, name, surname) values(@birth_date,@gender, @name, @surname)", connection);
            char gender;
            if (comboBox7.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';
            DateTime enteredDate = DateTime.Parse(textBox17.Text).Date;
            command1.Parameters.AddWithValue("@birth_date", enteredDate);
            command1.Parameters.AddWithValue("@gender", gender);
            command1.Parameters.AddWithValue("@name", textBox2.Text);
            command1.Parameters.AddWithValue("@surname", textBox3.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from actor";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["show_type"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["languageid"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["platformid"].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["countryid"].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["categoryid"].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["director_id"].Value.ToString();
                comboBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["movie_company_id"].Value.ToString();
                label25.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from show where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label25.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update show set \"categoryid\"=@categoryid , \"countryid\"=@countryid , \"director_id\"=@director_id , \"languageid\"=@languageid , \"movie_company_id\"=@movie_company_id , \"name\"=@name , \"platformid\"=@platformid , \"show_type\"=@show_type   where \"id\"=@id", connection);
          
            int language = int.Parse(comboBox1.Text.Split('|')[0]);
            int platform = int.Parse(comboBox2.Text.Split('|')[0]);
            int country = int.Parse(comboBox3.Text.Split('|')[0]);
            int category = int.Parse(comboBox4.Text.Split('|')[0]);
            int director = int.Parse(comboBox6.Text.Split('|')[0]);
            int movie_comp = int.Parse(comboBox10.Text.Split('|')[0]);
            char show_type;
            if (comboBox5.Text == "Movie")
            {
                show_type = 'M';
            }
            else show_type = 'S';

            command2.Parameters.AddWithValue("@id", int.Parse(label25.Text));
            command2.Parameters.AddWithValue("@categoryid", category);
            command2.Parameters.AddWithValue("@countryid", country);
            command2.Parameters.AddWithValue("@director_id", director);
            command2.Parameters.AddWithValue("@languageid", language);
            command2.Parameters.AddWithValue("@movie_company_id", movie_comp);
            command2.Parameters.AddWithValue("@name", textBox1.Text);
            command2.Parameters.AddWithValue("@platformid", platform);
            command2.Parameters.AddWithValue("@show_type", show_type);

            command2.ExecuteNonQuery();
            MessageBox.Show("data has been updated");
            connection.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var birth_Date = (dataGridView2.Rows[e.RowIndex].Cells["birth_date"].Value.ToString().Split(' ')[0]);

                dataGridView2.CurrentRow.Selected = true;
                textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                comboBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                textBox17.Text = birth_Date;
                label26.Text = dataGridView2.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from actor where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label26.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update actor set \"birth_date\"=@birth_date , \"gender\"=@gender , \"name\"=@name , \"surname\"=@surname  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label26.Text));
            
            DateTime enteredDate = DateTime.Parse(textBox17.Text).Date;
            char gender;

            if (comboBox7.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';

            command2.Parameters.AddWithValue("@birth_Date", enteredDate);
            command2.Parameters.AddWithValue("@gender", gender);
            command2.Parameters.AddWithValue("@name", textBox2.Text);
            command2.Parameters.AddWithValue("@surname", textBox3.Text);

            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into production_company (name) values(@name)", connection);

            command1.Parameters.AddWithValue("@name", textBox4.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from production_company where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label30.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update production_company set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label30.Text));
            command2.Parameters.AddWithValue("@name", textBox4.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "select * from production_company";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void button16_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into movie_company (name, production_company_id) values(@name, @production_company_id)", connection);
            
            int production_company_id = int.Parse(comboBox11.Text.Split('|')[0]);

            command1.Parameters.AddWithValue("@name", textBox5.Text);
            command1.Parameters.AddWithValue("@production_company_id", production_company_id);
            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from movie_company where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label32.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update movie_company set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", label32);
            command2.Parameters.AddWithValue("@name", textBox5.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string query = "select * from movie_company";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView6.DataSource = ds.Tables[0];
        }

        private void button20_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into director (birth_date, gender, name, surname) values(@birth_date,@gender, @name, @surname)", connection);
            char gender;
            if (comboBox8.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';
            DateTime enteredDate = DateTime.Parse(textBox18.Text).Date;
            command1.Parameters.AddWithValue("@birth_date", enteredDate);
            command1.Parameters.AddWithValue("@gender", gender);
            command1.Parameters.AddWithValue("@name", textBox7.Text);
            command1.Parameters.AddWithValue("@surname", textBox6.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from director where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label34.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView3.CurrentRow.Selected = true;
                textBox4.Text = dataGridView3.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label30.Text = dataGridView3.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView6.CurrentRow.Selected = true;
                textBox5.Text = dataGridView6.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label32.Text = dataGridView6.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update director set  \"birth_date\"=@birth_date, \"gender\"=@gender, \"name\"=@name, \"surname\"=@surname  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label34.Text));
            char gender;
            if (comboBox8.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';
            command2.Parameters.AddWithValue("@name", textBox7.Text);
            command2.Parameters.AddWithValue("@surname", textBox6.Text);
            command2.Parameters.AddWithValue("@gender", gender);
            DateTime enteredDate = DateTime.Parse(textBox18.Text).Date;
            command2.Parameters.AddWithValue("@birth_date", enteredDate);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string query = "select * from director";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
        }

        private void button24_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into critic (birth_date, gender, name, surname) values(@birth_date,@gender, @name, @surname)", connection);
            char gender;
            if (comboBox8.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';
            DateTime enteredDate = DateTime.Parse(textBox18.Text).Date;

            command1.Parameters.AddWithValue("@birth_date", enteredDate);
            command1.Parameters.AddWithValue("@gender", gender);
            command1.Parameters.AddWithValue("@name", textBox9.Text);
            command1.Parameters.AddWithValue("@surname", textBox8.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from critic where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label36.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update critic set  \"birth_date\"=@birth_date, \"gender\"=@gender, \"name\"=@name, \"surname\"=@surname  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label36.Text));
            char gender;
            if (comboBox9.Text == "Male")
            {
                gender = 'M';
            }
            else gender = 'F';
            command2.Parameters.AddWithValue("@name", textBox9.Text);
            command2.Parameters.AddWithValue("@surname", textBox8.Text);
            command2.Parameters.AddWithValue("@gender", gender);
            DateTime enteredDate = DateTime.Parse(textBox19.Text).Date;
            command2.Parameters.AddWithValue("@birth_date", enteredDate);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "select * from critic";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView4.CurrentRow.Selected = true;
                var birth_Date = (dataGridView4.Rows[e.RowIndex].Cells["birth_date"].Value.ToString().Split(' ')[0]);
                textBox7.Text = dataGridView4.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label34.Text = dataGridView4.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox6.Text = dataGridView4.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                comboBox8.Text = dataGridView4.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                textBox18.Text = birth_Date;
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView5.CurrentRow.Selected = true;
                var birth_Date = (dataGridView5.Rows[e.RowIndex].Cells["birth_date"].Value.ToString().Split(' ')[0]);
                textBox9.Text = dataGridView5.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label36.Text = dataGridView5.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox8.Text = dataGridView5.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                comboBox9.Text = dataGridView5.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                textBox19.Text = birth_Date;
            }

        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView7.CurrentRow.Selected = true;
                textBox11.Text = dataGridView7.Rows[e.RowIndex].Cells["critic_id"].Value.ToString();
                label38.Text = dataGridView7.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBox10.Text = dataGridView7.Rows[e.RowIndex].Cells["show_id"].Value.ToString();
                textBox12.Text = dataGridView7.Rows[e.RowIndex].Cells["criticism_text"].Value.ToString();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into criticism (critic_id, criticism_text, show_id) values(@critic_id,@criticism_text, @show_id)", connection);

            command1.Parameters.AddWithValue("@critic_id", int.Parse(textBox11.Text));
            command1.Parameters.AddWithValue("@criticism_text", textBox12.Text);
            command1.Parameters.AddWithValue("@show_id", int.Parse(textBox10.Text));

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from criticism where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label38.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update criticism set  \"critic_id\"=@critic_id, \"criticism_text\"=@criticism_text, \"show_id\"=@show_id, where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", label38);
            command2.Parameters.AddWithValue("@critic_id", textBox11.Text);
            command2.Parameters.AddWithValue("@criticism_text", textBox10.Text);
            command2.Parameters.AddWithValue("@show_id", textBox12.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string query = "select * from criticism";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView7.DataSource = ds.Tables[0];
        }

        private void button32_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into language (name) values(@name)", connection);

            command1.Parameters.AddWithValue("@name", textBox13.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from language where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label40.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update language set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label40.Text));
            command2.Parameters.AddWithValue("@name", textBox13.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView8.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView8.CurrentRow.Selected = true;
                textBox13.Text = dataGridView8.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label40.Text = dataGridView8.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string query = "select * from language";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView8.DataSource = ds.Tables[0];
        }

        private void button36_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into category (name) values(@name)", connection);

            command1.Parameters.AddWithValue("@name", textBox14.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button35_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from category where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label43.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update category set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label43.Text));
            command2.Parameters.AddWithValue("@name", textBox14.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into country (name) values(@name)", connection);

            command1.Parameters.AddWithValue("@name", textBox15.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView9.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView9.CurrentRow.Selected = true;
                textBox14.Text = dataGridView9.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label43.Text = dataGridView9.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void dataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView10.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView10.CurrentRow.Selected = true;
                textBox15.Text = dataGridView10.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label46.Text = dataGridView10.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {

            connection.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into digital_platform (name) values(@name)", connection);

            command1.Parameters.AddWithValue("@name", textBox16.Text);

            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been saved");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from country where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label46.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update country set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label46.Text));
            command2.Parameters.AddWithValue("@name", textBox15.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string query = "select * from category";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView9.DataSource = ds.Tables[0];
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string query = "select * from country";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView10.DataSource = ds.Tables[0];
        }

        private void button43_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("Delete from country where \"id\"=@id", connection);
            command3.Parameters.AddWithValue("@id", int.Parse(label49.Text));
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("data has been deleted");
        }

        private void button42_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update digital_platform set  \"name\"=@name  where \"id\"=@id", connection);
            command2.Parameters.AddWithValue("@id", int.Parse(label49.Text));
            command2.Parameters.AddWithValue("@name", textBox16.Text);


            command2.ExecuteNonQuery();
            MessageBox.Show("data has been update");
            connection.Close();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string query = "select * from digital_platform";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView11.DataSource = ds.Tables[0];
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView11.CurrentRow.Selected = true;
                textBox16.Text = dataGridView11.Rows[e.RowIndex].Cells["name"].Value.ToString();
                label49.Text = dataGridView11.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from digital_platform where id=@id", connection);
            cmd1.Parameters.AddWithValue("@id", int.Parse(textBox20.Text));
            NpgsqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {

                label59.Text = reader["name"].ToString();
                label60.Text = reader["id"].ToString();
            }
            else
            {
                MessageBox.Show("No data found");
            }

            connection.Close();

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }
    }
}
