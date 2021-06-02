using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace WpfApp2.View
{
    /// <summary>
    /// Join.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Join : Page
    {
        public Join()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/Home.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//회원가입 -- 로그인
        {


            //모든정보입력하도록
            if (string.IsNullOrEmpty(textbox1.Text))
            {
                MessageBox.Show("ID를 입력해주세요");
                this.textbox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox2.Text))
            {
                MessageBox.Show("PWD을 입력해주세요");
                this.textbox2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textbox3.Text))
            {
                MessageBox.Show("닉네임을 입력해주세요");
                this.textbox3.Focus();
                return;
            }


            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=musicr;UId=root;Password=1234;");
                MySqlCommand comm = new MySqlCommand();
                conn.Open();


                comm.CommandText = "INSERT INTO USER(uId, uPwd, uNname) VALUES (@uId, @uPwd, @uNname)";

                comm.Parameters.Add("@uId", MySqlDbType.Text).Value = textbox1.Text;
                comm.Parameters.Add("@uPwd", MySqlDbType.Text).Value = textbox2.Text;
                comm.Parameters.Add("@uNname", MySqlDbType.Text).Value = textbox3.Text;
              

                comm.Connection = conn;

                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("회원가입 되었습니다.");
                NavigationService.Navigate(new Uri("/view/Login.xaml", UriKind.Relative));
            }
            catch (Exception ex) { MessageBox.Show("아이디가 중복 되었습니다."); }
        }
    }
}
