﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Transliteration.DBModels;
using Transliteration.Tools;
using Transliteration.Tools.Managers;
using Transliteration.Tools.Navigation;
using Transliteration.TransliterationApplication.Models;
using Transliteration.TransliterationApplication.Tools;

namespace Transliteration.ViewModels.Authentication
{
    internal class SignUpViewModel:BaseViewModel
    {
        #region Fields
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;

        #region Commands
        private ICommand _signUpCommand;
        private ICommand _toSignInCommand;
        private ICommand _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #region Commands

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand =
                           new RelayCommand<object>(SignUpImplementation, CanSignUpExecute));
            }
        }

        public ICommand ToSignInCommand
        {
            get
            {
                return _toSignInCommand ?? (_toSignInCommand = new RelayCommand<object>(ToSignInImplementation));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));
            }
        }

        #endregion
        #endregion
        private bool CanSignUpExecute(object obj)
        {
            return !String.IsNullOrEmpty(_login) &&
                   !String.IsNullOrEmpty(_password) &&
                   !String.IsNullOrEmpty(_firstName) &&
                   !String.IsNullOrEmpty(_lastName) &&
                   !String.IsNullOrEmpty(_email);
        }

        private async void SignUpImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        LoggingUtil.WriteToLog($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} Email {_email} is not valid.");
                        MessageBox.Show($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} Email {_email} is not valid.");
                        Email = "";
                        return false;
                    }
                    if (StationManager.Client.UserExists(_login))
                    {
                        LoggingUtil.WriteToLog($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} User with such login already exists.");
                        MessageBox.Show($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} User with such login already exists.");
                        Login = "";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    LoggingUtil.WriteToLog($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} {ex.Message}");
                    MessageBox.Show($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} {ex.Message}");
                    Login = "";
                    Password = "";
                    FirstName = "";
                    LastName = "";
                    Email = "";
                    return false;
                }
                try
                {
                    var user = new User(_firstName, _lastName, _email, _login, _password);
                    StationManager.Client.AddUser(user);
                    StationManager.CurrentUser = user;
                    StationManager.CurrentLocalUser = new UserLocal(_login, _password); 
                }
                catch (Exception ex)
                {
                    LoggingUtil.WriteToLog($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} {ex.Message}");
                    MessageBox.Show($"Sign Up failed for user {_login}. Reason:{Environment.NewLine} {ex.Message}");
                    Login = "";
                    Password = "";
                    FirstName = "";
                    LastName = "";
                    Email = "";
                    return false;
                }
                LoggingUtil.WriteToLog($"User {_login} was successfully created.");
                MessageBox.Show($"User {_login} was successfully created.");
                Login = "";
                Password = "";
                FirstName = "";
                LastName = "";
                Email = "";
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private void ToSignInImplementation(object obj)
        {
            Login = "";
            Password = "";
            FirstName = "";
            LastName = "";
            Email = "";
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private void CloseImplementation(object obj)
        {
            Login = "";
            Password = "";
            FirstName = "";
            LastName = "";
            Email = "";
            StationManager.CloseApp();
        }



    }
}
