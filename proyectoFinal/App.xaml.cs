﻿using proyectoFinal.Vistas;

namespace proyectoFinal;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Vistas.Principal());
	}
}
