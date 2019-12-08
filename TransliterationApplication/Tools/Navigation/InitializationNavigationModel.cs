﻿using System;
using Transliteration.Views.Authentication;
using MainView = Transliteration.Views.MainView;
using SignUpView = Transliteration.Views.Authentication.SignUpView;

namespace Transliteration.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType,new SignInView());
                    break;
                case ViewType.SignUp:
                    ViewsDictionary.Add(viewType, new SignUpView());
                    break;
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
