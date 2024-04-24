using FirstWindowsApp.Helper.ApiUrlHelper;
using FirstWindowsApp.Helper.CachingService;
using FirstWindowsApp.Helper.Helper;
using FirstWindowsApp.Model.ApiResponse;
using FirstWindowsApp.Model.Login;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FirstDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
          

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click_1(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if(Email.Text.Length ==0 || Email.Text.Trim() == "")
            {
                Email.BackColor = Color.LightPink;
                panel1.BackColor = Color.LightPink;
                MessageBox.Show("Email field is required." ,"Error" , MessageBoxButtons.OK ,MessageBoxIcon.Error);
                Email.Focus();
                return;
            }
            else if(password.Text.Length == 0 || password.Text.Trim() == "")
            {
                password.BackColor = Color.LightPink;
                panel2.BackColor = Color.LightPink;
                MessageBox.Show("Password field is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Focus();
                return;
            }
            bool isEmailValid = IsValidEmail(Email.Text);
            if (!isEmailValid)
            {
                Email.BackColor = Color.LightPink;
                panel1.BackColor = Color.LightPink;
                MessageBox.Show("Email is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Email.Focus();
                return;
            }
            else
            {
                password.BackColor = System.Drawing.SystemColors.Control;
                panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            }

            LoginRequestModel loginModel = new LoginRequestModel();
            loginModel.EmailId = Email.Text;
            loginModel.Password = password.Text;
            var apiUrl = new RestClient(FirstWindowsApp.Helper.ApiUrlHelper.Environment.BaseApiAdmin);
            var request = new RestRequest(ApiHelper.Login, Method.Post);
            request.AddJsonBody(loginModel);
            var data = apiUrl.Execute(request);
            var response = JsonConvert.DeserializeObject<ApiResponseModel>(data.Content);
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseModel>(response.Data.ToString());

            if (loginResponse.JWTToken != null)
            {
                MessageBox.Show("Login succesfully.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dash = new Dashboard();
                dash.Show();
                GlobalCachingProvider.Instance.AddItem(Constants.JWToken, "Bearer " + loginResponse.JWTToken);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password." , "Invalid Credentials" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }





        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            Email.BackColor = System.Drawing.SystemColors.Control;
            panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.BackColor = System.Drawing.SystemColors.Control;
            panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
