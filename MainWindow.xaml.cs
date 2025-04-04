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

namespace ilinasp_var2
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string CalculateGrade(int dbScore, int psScore, int soScore)
        {
            try
            {
                if (dbScore < 0 || dbScore > 22)
                    throw new Exception("Баллы за модуль 'Разработка, администрирование и защита БД' должны быть от 0 до 22");
                if (psScore < 0 || psScore > 38)
                    throw new Exception("Баллы за модуль 'Разработка модулей ПО' должны быть от 0 до 38");
                if (soScore < 0 || soScore > 20)
                    throw new Exception("Баллы за модуль 'Сопровождение ПО' должны быть от 0 до 20");

                int totalScore = dbScore + psScore + soScore;

                string grade;
                if (totalScore >= 56)
                    grade = "5 (отлично)";
                else if (totalScore >= 32)
                    grade = "4 (хорошо)";
                else if (totalScore >= 16)
                    grade = "3 (удовлетворительно)";
                else
                    grade = "2 (неудовлетворительно)";

                return grade;
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            int dbScore = Convert.ToInt32(textBoxDB.Text);
            int psScore = Convert.ToInt32(textBoxPS.Text);
            int soScore = Convert.ToInt32(textBoxSO.Text);

            string grade = CalculateGrade(dbScore, psScore, soScore);

            labelResult.Text = grade;
        }
    }
}
