using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Model;

namespace WpfApp2.View
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Home.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//로그인 버튼 
        {
            //id password 모두 입력할 시 로그인 되게
            if (string.IsNullOrEmpty(textbox1.Text))
            {
                MessageBox.Show("Id를 입력해주세요");
                this.textbox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passwordbox.Password))
            {
                MessageBox.Show("password를 입력해주세요");
                this.passwordbox.Focus();
                return;
            }

            string uId = textbox1.Text;
            string uPwd = passwordbox.Password;

            //user -> list화해서 입력한 아이디와 비밀번호와 일치하는지 
            string connectionString = "Server=localhost;Database=musicr;UId=root;Password=1234;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from user", connection);
            connection.Open();
            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            List<user> Users = dt.DataTableToList<user>();


            try
            {
                user user1 = Users.Single((x) => x.uId.Equals(uId));


                if (user1.uPwd.Equals(uPwd))
                {
                    Application.Current.Properties["loginID"] = user1.uId;
                    MessageBox.Show("로그인 되었습니다.");
                    NavigationService.Navigate(new Uri("/view/Choice.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("비밀번호가 틀렸습니다.");
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("존재하지 않는 아이디입니다.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Join.xaml", UriKind.Relative));
        }
    }
}
