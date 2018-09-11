using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace CustomSpinner
{
	[Activity(Label = "CustomSpinner", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private CustomSpinnerAdapter spinnerAdapter;
		private Spinner spinner;

		List<string> data = new List<string> { "E", "A", "B", "C", "D" };

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			spinner = FindViewById<Spinner>(Resource.Id.spinner1);

			spinnerAdapter = new CustomSpinnerAdapter(this, Resource.Array.planets_array, data);
			spinner.Adapter = spinnerAdapter;
			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
		}

		protected override void OnResume()
		{
			base.OnResume();
		}

		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Console.WriteLine("Total Count is " + spinnerAdapter.Count);
			string toast = string.Format("The selected item is {0}", spinnerAdapter.GetItemData(e.Position) + "Pos " + e.Position);
			Toast.MakeText(this, toast, ToastLength.Long).Show();
			spinnerAdapter.setItemToHide(e.Position);
		}

		private List<string> CompareLists(string searchTerm)
		{
			//List<string> data1 = data;
			List<string> newList = data.GetRange(0, data.Count);

			newList.Remove(searchTerm);
			return newList;

		}
	}
}

