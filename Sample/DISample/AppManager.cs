﻿using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Autofac;
using System;

namespace Xablu.ScreenObjectXUI.Samples.DISample
{
	public class AppManager : ScreenObjectInitialize
	{
		static string AndroidPath = "";
		static string IOSPath = "";

		public override AndroidApp ConfigureAndroid(bool clearData)
		{
			if (TestEnvironment.IsTestCloud)
			{
				return ConfigureApp
					.Android
					.StartApp(clearData ? AppDataMode.Auto : AppDataMode.DoNotClear);
			}
			else
			{
				return ConfigureApp
					.Android
					//.PreferIdeSettings()
					.ApkFile(AndroidPath)
					.StartApp(clearData ? AppDataMode.Auto : AppDataMode.DoNotClear);
			}
		}

		public override iOSApp ConfigureIOS(bool clearData)
		{
			if (TestEnvironment.IsTestCloud)
			{
				return ConfigureApp
					.iOS
					.StartApp(clearData ? AppDataMode.Auto : AppDataMode.DoNotClear);
			}
			else
			{
				return ConfigureApp
					.iOS
					//.PreferIdeSettings()
					//.AppBundle(IOSPath)
					//.InstalledApp()
					//.DeviceIdentifier (DeviceHelper.getDeviceIdentifier (Emulator.iPhone4s))
					.StartApp(clearData ? AppDataMode.Auto : AppDataMode.DoNotClear);
			}
		}

		protected override void RegisterAndroidScreens(ContainerBuilder builder)
		{
			builder.RegisterType<LoginScreenAndroid>().As<ILoginScreen>().SingleInstance();
		}

		protected override void RegisterIosScreens(ContainerBuilder builder)
		{ 
			builder.RegisterType<LoginScreenIos>().As<ILoginScreen>().SingleInstance();
		}
	}
}