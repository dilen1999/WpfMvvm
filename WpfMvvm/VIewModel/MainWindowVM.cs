using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMvvm.Model;
using WpfMvvm.View;

namespace WpfMvvm.VIewModel
{
    public partial class MainWindowVM:ObservableObject
    {
        private Database dbcontext;
        [ObservableProperty]
        public ObservableCollection<student> students;
        [ObservableProperty]
        public student selectedStudent;

        public MainWindowVM()
        {
            dbcontext = new Database();
            students = new ObservableCollection<student>(dbcontext.Students);
          
      //      LoadData();
        }

        [RelayCommand]
        public void New_widnow()
        {
            var vm=new AddWindowVM();
            AddWindow objAddWindow = new AddWindow(vm);
            objAddWindow.Show();


        }


        [RelayCommand]
        public void DeleteStudent()
        {
            if(SelectedStudent != null)
            {
                dbcontext.Students.Remove(SelectedStudent);
                dbcontext.SaveChanges();
                Students.Remove(SelectedStudent);

            }
            else
            {
                MessageBox.Show("Select a Student");
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {
                var editstudent = SelectedStudent;
                var vm = new AddWindowVM(editstudent);
                AddWindow objAddWindow = new AddWindow(vm);
                dbcontext.Students.Remove(editstudent);
                dbcontext.SaveChanges();

                Students.Remove(editstudent);
                objAddWindow.Show();
            }
            else
            {
                MessageBox.Show("Select a Student");
            }
        }
    }
}
