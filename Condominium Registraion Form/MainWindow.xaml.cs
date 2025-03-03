using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace CondominiumRegistrationForm
{
    public partial class MainWindow : Window
    {
        private string? CurrentFilePath = null;
        private List<Resident> Residents = new List<Resident>();
        private Resident? SelectedResident = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Create a new resident
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var newResident = new Resident
            {
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Gender = MaleRadioButton.IsChecked == true ? "Male" : "Female",
                DateOfBirth = DateOfBirthPicker.SelectedDate,
                PhoneNumber = PhoneNumberTextBox.Text,
                HomeNumber = HomeNumberTextBox.Text
            };

            Residents.Add(newResident);
            RefreshGrid();
            ClearForm();
        }

        // Update an existing resident
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedResident != null)
            {
                SelectedResident.FirstName = FirstNameTextBox.Text;
                SelectedResident.MiddleName = MiddleNameTextBox.Text;
                SelectedResident.LastName = LastNameTextBox.Text;
                SelectedResident.Gender = MaleRadioButton.IsChecked == true ? "Male" : "Female";
                SelectedResident.DateOfBirth = DateOfBirthPicker.SelectedDate;
                SelectedResident.PhoneNumber = PhoneNumberTextBox.Text;
                SelectedResident.HomeNumber = HomeNumberTextBox.Text;

                RefreshGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("No resident selected for update.");
            }
        }

        // Delete a resident
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedResident != null)
            {
                Residents.Remove(SelectedResident);
                RefreshGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("No resident selected for deletion.");
            }
        }

        // Save to the current file
        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            if (CurrentFilePath == null)
            {
                MessageBox.Show("No file path specified. Please use 'Save As' to specify a file path.");
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(CurrentFilePath))
                {
                    foreach (var resident in Residents)
                    {
                        writer.WriteLine($"{resident.FirstName},{resident.MiddleName},{resident.LastName},{resident.Gender},{resident.DateOfBirth},{resident.PhoneNumber},{resident.HomeNumber}");
                    }
                }
                MessageBox.Show("Data saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }

        // Save As functionality
        private void SaveAsToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Save Residents Data As"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                CurrentFilePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(CurrentFilePath))
                    {
                        foreach (var resident in Residents)
                        {
                            writer.WriteLine($"{resident.FirstName},{resident.MiddleName},{resident.LastName},{resident.Gender},{resident.DateOfBirth},{resident.PhoneNumber},{resident.HomeNumber}");
                        }
                    }
                    MessageBox.Show("Data saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}");
                }
            }
        }

        // Open and load residents from a text file
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open Residents Data"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Residents.Clear();
                    CurrentFilePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var data = line.Split(',');

                            if (data.Length == 7)
                            {
                                var resident = new Resident
                                {
                                    FirstName = data[0],
                                    MiddleName = data[1],
                                    LastName = data[2],
                                    Gender = data[3],
                                    DateOfBirth = DateTime.TryParse(data[4], out DateTime dob) ? (DateTime?)dob : null,
                                    PhoneNumber = data[5],
                                    HomeNumber = data[6]
                                };

                                Residents.Add(resident);
                            }
                        }
                    }
                    RefreshGrid();
                    MessageBox.Show("Data loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        // Refresh the data grid
        private void RefreshGrid()
        {
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = Residents;
        }

        // Clear the form
        private void ClearForm()
        {
            FirstNameTextBox.Text = "";
            MiddleNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            MaleRadioButton.IsChecked = false;
            FemaleRadioButton.IsChecked = false;
            DateOfBirthPicker.SelectedDate = null;
            PhoneNumberTextBox.Text = "";
            HomeNumberTextBox.Text = "";
            SelectedResident = null;
        }

        // Handle grid selection change
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedResident = (Resident)DataGrid.SelectedItem;
            if (SelectedResident != null)
            {
                FirstNameTextBox.Text = SelectedResident.FirstName;
                MiddleNameTextBox.Text = SelectedResident.MiddleName;
                LastNameTextBox.Text = SelectedResident.LastName;
                MaleRadioButton.IsChecked = SelectedResident.Gender == "Male";
                FemaleRadioButton.IsChecked = SelectedResident.Gender == "Female";
                DateOfBirthPicker.SelectedDate = SelectedResident.DateOfBirth;
                PhoneNumberTextBox.Text = SelectedResident.PhoneNumber;
                HomeNumberTextBox.Text = SelectedResident.HomeNumber;
            }
        }
    }

    // Resident
    public class Resident
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
    }
}
