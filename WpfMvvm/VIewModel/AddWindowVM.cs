using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfMvvm.Model;
using WpfMvvm.View;

namespace WpfMvvm.VIewModel
{
    public partial class AddWindowVM : ObservableObject
    {
        private Database _dbcontext;
        [ObservableProperty]
        public string imagePath;
        [ObservableProperty]
        public string? firstName;
        [ObservableProperty]
        public string? lastName;
        [ObservableProperty]
        public String dob;
        [ObservableProperty]
        public int? studentID;
        [ObservableProperty]
        public float gpa;
        [ObservableProperty]
        public string gender;
       
        [ObservableProperty]
        
        public int age;
        [ObservableProperty]
        public ObservableCollection<student> students;
        [ObservableProperty]
        public student student;

        [RelayCommand]
        public void UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.gif; *.png)| *.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                string img_path = openFileDialog.FileName;
                //string trg_path = Path.Combine(Environment.CurrentDirectory, "Image", Path.GetFileName(img_path));
                //File.Copy(img_path, trg_path, true);

                ImagePath = img_path;

            }
        }


        public AddWindowVM()
        { 
            Age = 0; 
            _dbcontext= new Database();
            students = new ObservableCollection<student>(_dbcontext.Students);
            //LoadData();

        }

        public AddWindowVM(student newStudent)
        {
            student = newStudent;
            FirstName=newStudent.FirstName;
            LastName=newStudent.LastName;
            Dob=newStudent.Dob;
            Gender =newStudent.Gender;
            Age =newStudent.Age;
            Gpa=(float)newStudent.Gpa;
            ImagePath= newStudent.ImagePath;
           
            _dbcontext = new Database();
            students = new ObservableCollection<student>(_dbcontext.Students);
            //LoadData();

        }

        [RelayCommand]
        public void IncreaseAge()
        {
            Age += 1;
        }
        [RelayCommand]
        public void DecreaseAge()
        {
            Age -= 1;
        }

        //private void LoadData()
        //{
        //    Students.Clear();
        //    var students = _dbcontext.Students.ToList();
        //    foreach (var student in students)
        //    {
        //        Students.Add(student);
        //        _dbcontext.Students.Add(student);
        //        _dbcontext.SaveChanges();
        //    }
        //}
        public BitmapImage ConvertByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                memoryStream.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }
            bitmapImage.Freeze(); // Optional, but recommended to improve performance and allow cross-thread access
            return bitmapImage;
        }

        //[RelayCommand]
        //public void UploadImage()
        //{
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
        //    if (dialog.ShowDialog() == true)
        //    {
        //        var _imageFilePath = dialog.FileName;
        //        BitmapImage image = new BitmapImage(new Uri(_imageFilePath));
        //        Img = image;
        //    }
        //}

        [RelayCommand]
        public void AddStudent()
        {
           
            
                if (FirstName != null && LastName != null)
                {
                    student NewStudent = new student()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Dob = Dob,
                        Gpa = Gpa,
                        Gender = Gender,
                        Age = Age,
                        ImagePath = ImagePath
                      

                    };
                    Students.Add(NewStudent);
                    _dbcontext.Students.Add(NewStudent);
                    _dbcontext.SaveChanges();
                }



           
           var window=Application.Current.Windows.OfType<Window>().FirstOrDefault(w=>w.IsActive);
            window.Visibility=Visibility.Collapsed;
            var window1 = new MainWindow();
            window1.Show();
        }

        

        
    }
}
