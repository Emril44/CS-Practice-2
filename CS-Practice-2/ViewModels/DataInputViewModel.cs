﻿using CS_Practice_2.Models;
using CS_Practice_2.Tools;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CS_Practice_2.ViewModels
{
    internal class DataInputViewModel
    {
        private Person _person = new Person();
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;

        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        public string Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }

        public string Surname
        {
            get { return _person.Surname; }
            set { _person.Surname = value; }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _person.DateOfBirth ?? DateTime.Today; }
            set { _person.DateOfBirth = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            private set { _isAdult = value; }
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set { _sunSign = value; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set { _chineseSign = value; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            private set { _isBirthday = value; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get { return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute); }
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0)); }
        }

        private void Proceed()
        {
            if (IsItBirthday())
                MessageBox.Show(":D");

            _isBirthday = IsItBirthday();

            _isAdult = (CalculateAge() >= 18);

            _sunSign = GetSunSign();
            _chineseSign = GetChineseSign();

            MessageBox.Show($"{Name} {Surname}, {Email}, {DateOfBirth.ToShortDateString()},\n {SunSign}, {ChineseSign}");
        }

        private bool IsItBirthday()
        {
            var today = DateTime.Today;
            return (DateOfBirth.Day == today.Day) && (DateOfBirth.Month == today.Month);
        }

        private int CalculateAge()
        {
            var today = DateTime.Today;

            int age = (int)((today - DateOfBirth).TotalDays / 365.242199);
            if (age > 0 && age < 135)
            {
                return age;
            }

            MessageBox.Show("Invalid age! (Below 0 or above 135)");
            return 0;
        }

        private string GetSunSign()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";

                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";

                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";

                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";

                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";

                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";

                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";

                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";

                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";

                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";

                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";

                default:
                    return "";
            }
        }

        private string GetChineseSign()
        {
            return (DateOfBirth.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                11 => "Goat",
                _ => "",
            };
        }

        private bool CanExecute(object obj)
        {
            return
                !String.IsNullOrWhiteSpace(Name) &&
                !String.IsNullOrWhiteSpace(Surname) &&
                !String.IsNullOrWhiteSpace(Email) &&
                !DateOfBirth.Equals(null);
        }
    }
}


