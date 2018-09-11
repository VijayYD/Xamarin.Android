
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CustomSpinner
{
	public class CustomSpinnerAdapter : BaseAdapter, ISpinnerAdapter
	{

		private List<string> dates;
		private int hideItemPostion;
		private string hideItemText;
		private Activity context;
		string selectedItem = "";

		public CustomSpinnerAdapter(Activity context, int resource, List<string> dates)
		{
			//this.dates = dates;
			this.context = context;
		}

		public void setItemToHide(int itemToHide)
		{
			this.hideItemPostion = itemToHide;
		}

		public void setItemTextToHide(string itemTextToHide)
		{
			this.hideItemText = itemTextToHide;
		}

		public override int Count
		{
			get
			{
				return dates.Count;
			}
		}

		public void SetListData(List<string> data)
		{
			dates = data;
		}

		public override long GetItemId(int position)
		{
			return position;

		}

		public string GetItemData(int position)
		{
			return dates[position];

		}

		public override View GetDropDownView(int position, View convertView, ViewGroup parent)
		{
			return GetCustomView(position, convertView, parent);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		public View GetCustomView(int position, View convertView, ViewGroup parent)
		{
			View view = null;
			//if (position == hideItemPostion)
			//{
			//TextView tv = new TextView(context);
			//tv.Visibility = ViewStates.Gone;
			//tv.SetHeight(0);
			//view = tv;
			//view.Visibility = ViewStates.Gone;
			//}
			//else 
			//view =  base.GetDropDownView(position, convertView, parent);


			view = convertView;
			if (view == null) // otherwise create a new one
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleSpinnerDropDownItem, null);
			}
			//if (!GetViewCalled)
			{
				TextView checkedTextView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
				LinearLayout.LayoutParams LayoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
				LayoutParams.SetMargins(15, 15, 15, 15);
				checkedTextView.Text = dates[position];
				checkedTextView.LayoutParameters = LayoutParams;
				//if (!hideItemText.Equals(dates[position]) && position == hideItemPostion)
				{
					Console.WriteLine("Text is " + dates[position]);
					Console.WriteLine("Selected Text is " + hideItemText);
					Console.WriteLine("Position " + hideItemPostion);
					//checkedTextView.Visibility = ViewStates.Gone;
					//view.Visibility = ViewStates.Gone;
					//NotifyDataSetChanged();
				}
				//NotifyDataSetChanged();

			}
		

			return view;
		}


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			return GetCustomView(position, convertView, parent);
			//return base.GetView(position, convertView, parent);

		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}
	}
}
