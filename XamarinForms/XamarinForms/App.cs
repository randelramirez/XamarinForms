using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class App : Application
    {


        public App()
        {
            // The root page of your application
            //MainPage = new GreetingsPage();
            //MainPage = new BaskervillesPage();
            //MainPage = new VariableFormattedTextPage();
            //MainPage = new VariableFormattedParagraphPage();
            //MainPage = new NamedFontSizesPage();
            //MainPage = new ColorLoopPage();
            //MainPage = new ReflectedColorsPage();
            //MainPage = new ReflectedColorsHorizontalPage();
            //MainPage = new VerticalOptionsDemoPage();
            //MainPage = new FramedTextPage();
            //MainPage = new SizedBoxViewPage();
            //MainPage = new ColorBlocksPage();
            //MainPage = new BlackCatPage();
            //MainPage = new WhatSizePage();
            //MainPage = new FontSizesPage();
            //MainPage = new EstimatedFontSizePage();
            //MainPage = new FontSizesPage();
            //MainPage = new FitToSizeClockPage();
            //MainPage = new AccessibilityTestPage();
            //MainPage = new EmpiricalFontSizePage();
            //MainPage = new ButtonLoggerPage();
            //MainPage = new TwoButtonsPage();
            //MainPage = new ButtonLambdasPage();
            //MainPage = new SimplestKeypadPage();
            //MainPage = new CodePlusXamlPage();
            //MainPage = new ScaryColorListPage();
            //MainPage = new TextVariationsPage();
            //MainPage = new ColorViewListPage();
            //MainPage = new MonkeyTapPage();
            //MainPage = new MonkeyTapUsingCodePage();
            //MainPage = new DisplayPlatformInfoPage();
            //MainPage = new MonkeyTapWithSoundPage();
            MainPage = new ParameteredConstructorDemoPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
